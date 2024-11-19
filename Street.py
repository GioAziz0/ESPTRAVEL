class Street:
    def __init__(self, name, lenght):
        self.Name = name
        self.Lenght = lenght
        self.NearStreets = []
    
    def AddNearStreets(self, Streets):
        for s in Streets:
            self.NearStreets.append(s)

    def RemoveNearStreets(self, Streets):
        for s in Streets:
            if s in self.NearStreets:
                self.NearStreets.remove(s)