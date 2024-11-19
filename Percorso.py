'''
Il programma, data una mappa di strade e 2 strade A e B, fornisce il percorso minimo da strada A a strada B.

La mappa di strade deve essere un file JSON contenente una lista di dizionari. Ogni dizionario corrisponde a una strada e contiene i seguenti dati:
[
    {
        Name: identificatore strada
        Lenght: lunghezza della strada
        NearStreets: [lista di identificatori delle strade adiacienti]
    }
    ...
]

Il programma restituirà una lista di identificatori delle strade da percorrere (ordinate) per arrivare a destinazione.

'''

import json
import Street as St

map = []

Departure = None
Destination = None

def loadMap(file):
    global map
    with open(file, 'r') as file:
        data = json.load(file)

    for s in data:
        S = St.Street(s['Name'], s['Lenght'])
        S.AddNearStreets(s["NearStreets"])
        map.append(S)

def setDeparture(departure):
    Departure = departure
def setDestination(destination):
    Destination = destination




        
        

