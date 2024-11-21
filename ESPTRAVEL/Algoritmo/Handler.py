import Percorso as Prcs
import Point as pt

data = [
    {
        'Name' : 'punto1',
        'NearPoints' : [
            {
                'name': 'punto2',
                'weight': 1
            }
        ]
    },
    {
        'Name' : 'punto2',
        'NearPoints' : [
            {
                'name': 'punto3',
                'weight': 1
            },
            {
                'name': 'punto1',
                'weight': 2,
            }
        ]
    },
    {
        'Name' : 'punto3',
        'NearPoints' : [
            {
                'name': 'punto4',
                'weight': 1
            }
        ]
    },
    {
        'Name' : 'punto4',
        'NearPoints' : [
            {
                'name': 'punto1',
                'weight': 1
            }
        ]
    }

]

Prcs.MakeMap(data)

Prcs.viewMap()

Prcs.setDeparture("punto1")
Prcs.setDestination("punto3")

print(Prcs.Travel())