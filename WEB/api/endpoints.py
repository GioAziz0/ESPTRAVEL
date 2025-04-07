from fastapi import FastAPI, File, UploadFile, HTTPException
from fastapi.responses import HTMLResponse, FileResponse
from fastapi.staticfiles import StaticFiles
import json
from PIL import Image
import sys
import os
import sqlite3
import base64
from io import BytesIO

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../core')))
import travel
from models import user

app = FastAPI()

imgsDir = 'images'
os.makedirs(imgsDir, exist_ok=True)

app.mount("/static", StaticFiles(directory="static"), name="static")

# Endpoint per la visualizzazione dell'immagine della mappa
@app.get("/map_image/")
def show_map(id: str, floor: int):
    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()
    cursor.execute(
        "SELECT imgPath FROM floors WHERE mapID = ? AND floor = ?",
        (id, floor)
    )
    result = cursor.fetchone()
    conn.close()
    
    if not result:
        raise HTTPException(status_code=404, detail="Image not found")
    
    image_path = result[0]
    if not os.path.exists(image_path):
        raise HTTPException(status_code=404, detail="Image file not found")
    
    return FileResponse(image_path)

@app.get("/floorsJson/")
def get_floors(id: str):
    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()
    cursor.execute(
        "SELECT floor, name FROM floors WHERE mapID = ? ORDER BY floor",
        (id,)
    )
    floors = [{'floor': row[0], 'name': row[1]} for row in cursor.fetchall()]
    conn.close()
    return floors

# Endpoint per ottenere gli archi
@app.get("/arcsJson/")
def get_arcs(id: str):
    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()
    cursor.execute(
        """SELECT labelA, labelB, weight, floorA, floorB 
        FROM arcs WHERE mapIDA = ? AND mapIDB = ?""",
        (id, id)
    )
    arcs = [
        {
            'labelA': labelA,
            'labelB': labelB,
            'weight': weight,
            'floorA': floorA,
            'floorB': floorB
        }
        for labelA, labelB, weight, floorA, floorB in cursor.fetchall()
    ]
    conn.close()
    return arcs

# Endpoint per ottenere i punti
@app.get("/pointsJson/")
def get_points(id: str):
    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()
    cursor.execute(
        "SELECT point, label, floor FROM points WHERE mapID = ?",
        (id,)
    )
    points = [
        {
            'name': label,
            'cordinatepunti': point,
            'floor': floor
        }
        for point, label, floor in cursor.fetchall()
    ]
    conn.close()
    return points

# Endpoint per il caricamento della mappa
@app.post("/load/")
async def load_json(id: str, file: UploadFile = File(...)):
    content = await file.read()
    try:
        floors = json.loads(content)
        floors = floors["piani"]
    except json.JSONDecodeError:
        raise HTTPException(status_code=400, detail="Invalid JSON format")

    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()

    try:
        cursor.execute("DELETE FROM maps WHERE ID = ?", (id,))
        cursor.execute("DELETE FROM floors WHERE mapID = ?", (id,))
        cursor.execute("DELETE FROM points WHERE mapID = ?", (id,))
        cursor.execute("DELETE FROM arcs WHERE mapIDA = ? OR mapIDB = ?", (id, id))
        # Pulizia dati esistenti

        # Inserimento nuova mappa
        cursor.execute(
            "INSERT INTO maps (ID, Name, Floors) VALUES (?, ?, ?)",
            (id, id, int(len(floors))))
        
        for floor in floors:
            level = floor['Level']
            name_floor = floor['Name']
            arcs = floor['arcs']
            points = floor['points']
            image_base64 = floor['image']

            # Inserimento archi
            for arc in arcs:
                if len(arc) != 3:
                    continue
                labelA, labelB, weight = arc
                cursor.execute(
                    """INSERT INTO arcs 
                    (labelA, labelB, weight, mapIDA, mapIDB, floorA, floorB) 
                    VALUES (?, ?, ?, ?, ?, ?, ?)""",
                    (labelA, labelB, weight, id, id, level, level))

            # Inserimento punti
            for point in points:
                label = point['Name']
                coord = point['CordinatePunti']
                cursor.execute(
                    "INSERT INTO points (point, label, mapID, floor) VALUES (?, ?, ?, ?)",
                    (coord, label, id, level)
                )

            # Salvataggio immagine
            image_data = base64.b64decode(image_base64)
            img = Image.open(BytesIO(image_data))
            map_image_dir = os.path.join(imgsDir, f"map_{id}")
            os.makedirs(map_image_dir, exist_ok=True)
            image_path = os.path.join(map_image_dir, f"floor_{level}.png")
            img.save(image_path, "PNG")

            # Inserimento piano
            cursor.execute(
                "INSERT INTO floors (mapID, floor, name, imgPath) VALUES (?, ?, ?, ?)",
                (id, level, name_floor, image_path)
            )

        conn.commit()
    except Exception as e:
        conn.rollback()
        raise HTTPException(status_code=500, detail=str(e))
    finally:
        conn.close()

    return {"message": f"Map {id} loaded successfully"}

# Altri endpoint rimangono invariati
@app.get("/")
def read_root():
    return {"message": "Hello, World!"}

@app.get("/loadMap")
def load_GUI():
    return HTMLResponse(content=open("static/load_webapp.html").read(), status_code=200)

@app.get("/travelMap/")
def travel_map():
    return HTMLResponse(content=open("static/travel2.ejs").read(), status_code=200)

@app.get("/graph/")
def show_graph(id: str):
    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()
    cursor.execute("SELECT labelA, labelB, weight FROM arcs WHERE mapIDA = ? AND mapIDB = ?", (id, id))
    arcs = cursor.fetchall()
    conn.close()
   
    m = travel.Graph()
    for arc in arcs:
        labelA, labelB, weight = arc
        m.addArc(labelA, labelB, weight)  # Assumendo che esista questo metodo
   
    return str(m)

@app.get("/travel/")
def trv(IDmap: str = None, start: str = None, end: str = None):
    conn = sqlite3.connect('maps.db')
    cursor = conn.cursor()
    cursor.execute("SELECT labelA, labelB, weight FROM arcs WHERE mapIDA = ? AND mapIDB = ?", (IDmap, IDmap))
    arcs = cursor.fetchall()
    conn.close()
   
    m = travel.Graph()
    for arc in arcs:
        labelA, labelB, weight = arc
        m.addArc(labelA, labelB, weight)
   
    return m.Travel(start, end)