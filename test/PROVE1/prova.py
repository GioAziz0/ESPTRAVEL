import sys
import os

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../core')))
import travel

ciao = travel.Graph()
ciao.MakeMap([
    ('a', 'b', 2),
    ('b', 'c', 3),
    ('c', 'e', 4),
    ('d', 'e', 1),
    ('b', 'd', 3),
])

ciao.showMap()
print(ciao.Travel('a', 'b'))
print(travel.ShortestPath(ciao._GMap, 'a', 'e'))