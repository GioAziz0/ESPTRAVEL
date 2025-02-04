from fastapi import FastAPI, File, UploadFile, HTTPException
from fastapi.responses import HTMLResponse, FileResponse
from fastapi.staticfiles import StaticFiles
import json
from PIL import Image
import sys
import os
from io import BytesIO
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../core')))
import travel
from models import user

app = FastAPI()

arcsDir = 'arcs'
pointsDir = 'points'
imgsDir = 'images'
os.makedirs(arcsDir, exist_ok=True)
os.makedirs(imgsDir, exist_ok=True)

# Configurazione per servire file statici (come HTML, CSS, JS, immagini)
app.mount("/static", StaticFiles(directory="static"), name="static")

'''
@app.get("/")
def read_root():
    return {"message": "Hello, World!"}
'''


@app.get("/loadMap")
def load_GUI():
    return HTMLResponse(content=open("static/load_webapp.html").read(), status_code=200)

@app.get("/travelMap/")
def travel_map():
    return HTMLResponse(content=open("static/travel2.ejs").read(), status_code=200)
    
@app.get("/graph/")
def show_graph(id: str):
    mapDir = os.path.join(arcsDir, id)
    m = travel.Graph()
    #with open(mapDir, 'r') as file:
    #    data = json.load(file)
    m.loadMapJson(mapDir)
    return(m.__str__()) #.replace('\n', '<br>')

@app.get("/map_image/")
def show_map(id: str):
    mapDir = os.path.join(imgsDir, id)
    image_path = os.path.join(imgsDir, f"{id}.png")
    
    if os.path.exists(image_path):
        return FileResponse(image_path)
    else:
        # Solleva un'eccezione HTTP 404 se l'immagine non esiste
        raise HTTPException(status_code=404, detail="Immagine non trovata")

@app.get("/arcsJson/")
def get_arcs(id: str):
    t = os.path.join(arcsDir, id)
    with open(t, 'r') as file:
         arcs = json.load(file)
         return arcs

@app.get("/pointsJson/")
def get_arcs(id: str):
    t = os.path.join(pointsDir, id)
    with open(t, 'r') as file:
         points = json.load(file)
         return points



@app.post("/load/")
async def load_json(id: str, fileArcs: UploadFile = File(...), filePoints: UploadFile = File(...), image: UploadFile = File(...)):
    
    content1 = await fileArcs.read()
    content2 = await filePoints.read()
    
    try:
        data = json.loads(content1)
        mapDir = os.path.join(arcsDir, id)
        with open(mapDir, 'w') as file:
            json.dump(data, file, indent=4)
    except json.JSONDecodeError:
        return {"message": "Errore nel parsing del file JSON"}
    
    try:
        data = json.loads(content2)
        mapDir = os.path.join(pointsDir, id)
        with open(mapDir, 'w') as file:
            json.dump(data, file, indent=4)
    except json.JSONDecodeError:
        return {"message": "Errore nel parsing del file JSON"}
    
    try:
        img_content = await image.read()
        img = Image.open(BytesIO(img_content))
        img.save(os.path.join(imgsDir, f'{id}.png'))  # Salvataggio come PNG
    except Exception as e:
        return {"message": f"Errore nel salvataggio dell'immagine: {str(e)}"}
    
    return {"message" : f"Mappa {id} salvata correttamente \n {show_graph(id)}"}   
          
    
@app.get("/travel/")
def trv(IDmap: str = None, start: str = None, end: str = None):
    mapDir = os.path.join(arcsDir, IDmap)
    m = travel.Graph()
    m.loadMapJson(mapDir)
    return m.Travel(start, end)