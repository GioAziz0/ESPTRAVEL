class Point:
    def __init__(self, name):
        self.Name = name
        self.NearPoints = []
    
    def AddNearPoints(self, Points):
        '''
        Points = [
            {
                name:
                weight:
            }
            ...
        ]
        '''
        for s in Points:
            self.NearPoints.append(s)

    def RemoveNearPoints(self, Points):
        for s in Points:
            if s in self.NearPoints:
                self.NearPoints.remove(s)