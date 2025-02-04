import requests

url = 'http://127.0.0.1:8000/travel/'
#files = {'file': open('ListaPunti_GioAziz.json', 'rb')}
params = {'IDmap': 'Egitto',
          'start': 'A',
          'end': 'N'}

response = requests.get(url, params=params)

print(response)  # Stampa la risposta dell'API

data = response.json()
print(data)