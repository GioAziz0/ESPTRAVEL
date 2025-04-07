import re

class Arc:
    def __init__(self, pointA, pointB, weight):
        self.pointA = pointA
        self.pointB = pointB
        self.weight = weight 
    
    def _point_setter(self, name):
        if re.search("^[a-zA-Z0-9_+-]+$", str(name)): #se la stringa è alfanumerice:
            return str(name)
        else:
            raise ValueError("Point name must be alphanumerical")

    @property
    def pointA(self):
        return self._pointA
    
    @pointA.setter
    def pointA(self, name):
        self._pointA = self._point_setter(name)

    @property
    def pointB(self):
        return self._pointB
    
    @pointB.setter
    def pointB(self, name):
        self._pointB = self._point_setter(name)

    @property
    def weight(self):
        return self._weight
    
    @weight.setter
    def weight(self, w):
        self._weight = float(w.replace(',', '.'))


        