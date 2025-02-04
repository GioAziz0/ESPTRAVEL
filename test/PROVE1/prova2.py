import requests

url = 'http://127.0.0.1:8000/load/'
files = {'file': open('ListaPunti_GioAziz.json', 'rb')}
params = {'id': 'Egitto'}

response = requests.post(url, files=files, params=params)

print(response)  # Stampa la risposta dell'API
