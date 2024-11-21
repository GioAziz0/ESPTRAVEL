'''
Il programma, data una mappa (grafo) di punti, partenza A e destinazione B, fornisce il percorso minimo da A a B.

La mappa di punti deve contenente una lista di dizionari. Ogni dizionario corrisponde a un punto e contiene i seguenti dati:
[
    {
        Name: identificatore del punto
        NearPoints: [lista di identificatori delle strade adiacienti e peso dell'arco che li collega:
                        {
                            name:
                            weight:
                        }
                    ]
    }
    ...
]

Il programma restituira' una lista di identificatori dei punti da percorrere (in ordine) per arrivare a destinazione.

'''

import json
import Point as Pt
import networkx as nx

map = []
GMap = nx.DiGraph()
Departure = None
Destination = None

def MakeMap(data): #Genera una mappa da una lista di punti (data)
    for point in data:
        P = Pt.Point(point['Name'])
        P.AddNearPoints(point["NearPoints"])
        map.append(P)

    #GMap.add_nodes_from([p.Name for p in map])

    for point in map:
        for p in point.NearPoints:
            GMap.add_edge(point.Name, p['name'], weight = p['weight'])
    
    print(GMap)

def loadMapJson(file): #Carica i dati della mappa da un file JSON
    global map
    with open(file, 'r') as file:
        data = json.load(file)
    MakeMap(data)  

def viewMap():
    print("Nodi del grafo:", GMap.nodes())
    print("Archi del grafo:", GMap.edges(data=True))

    for u, v, data in GMap.edges(data=True):
        print(f"Arco tra {u} e {v} con peso {data['weight']}")

def setDeparture(departure): #Imposta la partenza
    global Departure
    Departure = departure
    print(departure)

def setDestination(destination): #Imposta la destinazione
    global Destination
    Destination = destination
    print(destination)

def Travel():
    return ShortestPath(GMap, Departure, Destination)

def ShortestPath(graph, start, end):
    try:
        # Calcola il percorso minimo e il suo costo utilizzando Dijkstra
        path = nx.dijkstra_path(graph, source=start, target=end, weight='weight')
        return path
    except nx.NetworkXNoPath:
        return "No path found"
    except nx.NodeNotFound:
        return f"Departure {start} or Destination {end} not found"




        
        

