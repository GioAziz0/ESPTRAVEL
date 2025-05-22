// Sidebar toggle

console.log("Ciao")

const toggleButton = document.getElementById('toggleSidebar')
const sidebar = document.getElementById('sidebar');
const main = document.getElementById('main');
const tbs = document.getElementsByClassName('toolbar')

toggleButton.addEventListener('click', () => {
    sidebar.classList.toggle('hidden');
    main.classList.toggle('expanded');
    
    if (sidebar.classList.contains('hidden')) {
        toggleButton.style.left = '1.5rem';
    } else {
        toggleButton.style.left = 'calc(var(--sidebar-width) + 1.5rem)';
    }
});

// Gestione mappa nel canvas

let MIN_SIZE = 300
let MAX_SIZE = 1500 
let BASE_RADIUS = 500
let BASE_LINE_WIDTH = 300 
let BASE_FONT_SIZE = 1500;

const canvas = document.getElementById('canva')
const ctx = canvas.getContext('2d');

canvas.addEventListener('transitionend', () => {
    isAnimating = false;
});

let currentMapData = {
    points: [],
    floors: [],
};

let currentFloorData = {
    points: [],
    name: null,
    floor: null,
    image: null,
    path: null,
};

currentIndexFloor = 0;
let currentStep = 0;

let path = {
    sequence: null,
}

// Variabili gestione animazioni
let isAnimating = false;
let currentTransform = {
    x: canvas.width / 2,
    y: canvas.height / 2,
    scale: 1,
    rotation: 0
};
let targetTransform = { ...currentTransform };
let animationFrameId = null;


function clearCanvas() {
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.clearRect(0, 0, canvas.width, canvas.height);
}

async function loadImage(url) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => resolve(img);
        img.onerror = reject;
        img.src = url;
    });
}

function drawImage(img) {
    canvas.width = img.width;
    canvas.height = img.height;
    ctx.drawImage(img, 0, 0);
}

async function loadMap() {
    clearCanvas()
    const id = document.getElementById('mapId').value;
    try {
        const [floorsRes, pointsRes] = await Promise.all([
            fetch(`/floorsJson/?id=${id}`),
            fetch(`/pointsJson/?id=${id}`),
            //fetch(`/arcsJson/?id=${id}`)
        ])
        
        currentMapData.floors = await floorsRes.json();
        currentMapData.points = await pointsRes.json();

        populateDropdowns();
        
        if (!floorsRes.ok) {
            throw new Error('Errore nel caricamento dei dati della mappa: floors');
        }
        if (!pointsRes.ok) {
            throw new Error('Errore nel caricamento dei dati della mappa: points');
        }
        
        await loadFloorData(currentIndexFloor);
        loadFloor();
        
        Array.from(tbs).forEach(element => {
            element.classList.add('active');
        });
        
        document.getElementById('errorMessage').style.display = 'none';
    } catch (error) {
        Array.from(tbs).forEach(element => {
            element.classList.remove('active');
        });
        console.log(error)
        document.getElementById('errorMessage').style.display = 'block';
    }
}

async function loadFloorData(fl) {
    if (currentMapData.floors.length === 0) {
        trhow(new Error("Nessun piano trovato"))
        return;
    }
    if (fl < 0 || fl > currentMapData.floors.length) {
        trhow(new Error("given floor is out of range"))
        return;
    }
    
    
    console.log(currentMapData.floors[fl])
    currentFloorData.name = currentMapData.floors[fl].name
    currentFloorData.points = currentMapData.points.filter(p => p.floor === currentMapData.floors[fl].floor)
    const imageUrl = `/map_image/?id=${document.getElementById('mapId').value}&floor=${currentMapData.floors[fl].floor}`;
    currentFloorData.image = await loadImage(imageUrl)
    currentFloorData.floor = currentMapData.floors[fl].floor;
    canvas.width = currentFloorData.image.width;
    canvas.height = currentFloorData.image.height;
    
    currentTransform = {
        x: canvas.width / 2,
        y: canvas.height / 2,
        scale: 1,
        rotation: 0
    };
    
    MIN_SIZE = 300 * ((canvas.width + canvas.height)/2) / 7000;   
    MAX_SIZE = 500 * ((canvas.width + canvas.height)/2) / 7000;  
    BASE_RADIUS = 300 * ((canvas.width + canvas.height)/2) / 7000;
    BASE_LINE_WIDTH = 300 * ((canvas.width + canvas.height)/2) / 7000;
    BASE_FONT_SIZE = 14;
}

async function loadImage(url) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => resolve(img);
        img.onerror = reject;
        img.src = url;
    });
}


function drawImage(img) {
    console.log(img)
    ctx.drawImage(img, 0, 0);
}

function populateDropdowns() {
    const startSelect = document.getElementById('partenza');
    const endSelect = document.getElementById('arrivo');
    
    // Pulisci le opzioni esistenti mantenendo il placeholder
    startSelect.innerHTML = '<option value="" disabled selected>Punto di partenza</option>';
    endSelect.innerHTML = '<option value="" disabled selected>Punto di arrivo</option>';
    
    // Popola con i punti della mappa
    currentMapData.points.forEach(point => {
        const option = document.createElement('option');
        option.value = `${point.floor}*${point.name}`;
        option.textContent = `${point.name} (${point.floor})`;
        
        startSelect.appendChild(option.cloneNode(true));
        endSelect.appendChild(option.cloneNode(true));
    });
}

function drawPoints(points) {
    const displayedRect = canvas.getBoundingClientRect();
    const cssScale = canvas.width / displayedRect.width;
    const totalScale = currentTransform.scale * cssScale;

    console.log("MIN", MIN_SIZE)

    // Calcolo limiti dinamici
    const dynamicMin = MIN_SIZE / totalScale;
    const dynamicMax = MAX_SIZE / totalScale;

    points.forEach(point => {
        const [x, y] = point.cordinatepunti.split(',').map(coord => parseInt(coord.trim()));
        ctx.beginPath();
        ctx.fillStyle = 'Green';
        
        // Calcolo raggio grezzo
        let radius = (BASE_RADIUS / cssScale) * currentTransform.scale;
        
        // Applica limiti dinamici
        radius = Math.min(dynamicMax, Math.max(dynamicMin, radius));
        
        ctx.arc(x, y, radius, 0, Math.PI * 2);
        ctx.fill();

        // Testo con limiti dinamici
        let fontSize = (BASE_FONT_SIZE / cssScale) * currentTransform.scale;
        fontSize = Math.min(dynamicMax, Math.max(dynamicMin, fontSize));
        ctx.font = `${fontSize}px Arial`;
        ctx.fillText(point.name, x + radius + 5, y - radius - 5);
    });
}

function loadFloor() {
    console.log("chiamatooo")
    drawImage(currentFloorData.image)
    drawPoints(currentFloorData.points)
    console.log(path.sequence)
    if (!path.sequence)
        return
    if (path.sequence.length>1)
        DrawThisFloorPath()
}

async function findPath() {
    const idMap = document.getElementById('mapId').value;
    const start = document.getElementById('partenza').value;
    const end = document.getElementById('arrivo').value;

    if (!idMap || !start || !end) {
        alert('Per favore, inserisci ID mappa e seleziona partenza e arrivo.');
        return;
    }

    try {
        const response = await fetch(`/travel/?IDmap=${idMap}&start=${start}&end=${end}`);
        if (!response.ok) {
            const errorData = await response.text();
            let message = JSON.parse(errorData).detail
            throw new Error((message || 'Errore sconosciuto dal server'))
        } 
        path.sequence = await response.json();
    } catch (error) {
        console.error('Errore:', error);
        alert(error);
    }
}

async function Navigate() {
    clearCanvas();
    await findPath();
    loadFloor();
    Step(0);

}

function ReloadThisFloorPath(){
    let pat = path.sequence
    console.log(pat)
    console.log("o", path.sequence)
    tempP = pat.filter(item => {
        // Trova l'indice del primo asterisco
        const asteriskIndex = item.indexOf('*');
        if (asteriskIndex !== -1) {
          // Estrae la parte prima dell'asterisco
          const partePrimaAsterisco = item.slice(0, asteriskIndex);
          console.log("ppa", partePrimaAsterisco)
          return partePrimaAsterisco == currentFloorData.floor;  // Filtra per valore desiderato
        }
      });

      console.log("cidfaao", tempP)
    
    const npat = tempP.map(item => {
        // Trova l'indice del primo asterisco
        const asteriskIndex = item.indexOf('*');
        if (asteriskIndex !== -1) {
          // Rimuove la parte prima dell'asterisco (incluso l'asterisco)
          return item.slice(asteriskIndex + 1);
        }
      });
    console.log("ciao", npat)
    currentFloorData.path = npat
}

async function DrawThisFloorPath(){
    await ReloadThisFloorPath();
    drawPath(currentFloorData.path, currentFloorData.points);
}

function drawPath(path, points) {
    const displayedRect = canvas.getBoundingClientRect();
    const cssScale = canvas.width / displayedRect.width;
    const totalScale = currentTransform.scale * cssScale;

    // Calcolo limiti dinamici
    const dynamicMin = MIN_SIZE / totalScale;
    const dynamicMax = MAX_SIZE / totalScale;

    ctx.beginPath();
    ctx.strokeStyle = 'rgba(0, 127, 255, 0.5)';
    
    let lineWidth = (BASE_LINE_WIDTH / cssScale) * currentTransform.scale;
    lineWidth = Math.min(dynamicMax, Math.max(dynamicMin, lineWidth));
    ctx.lineWidth = lineWidth;

    path.forEach((pointName, i) => {
        const point = points.find(p => p.name === pointName);
        const [x, y] = point.cordinatepunti.split(',').map(Number);
        i === 0 ? ctx.moveTo(x, y) : ctx.lineTo(x, y);
    });

    ctx.stroke();
}


function setCS(i) {
    if (i >= 0 && i <= currentFloorData.path.length)
    {
        console.log("asjdhfasdfòlskdjfalòskdfj", i)
        currentStep = i;

    }
        
    console.log("athis", currentStep)
    if (currentStep == 0) {
        document.getElementById("step-label").textContent = "Overview";
    } else {
        document.getElementById("step-label").textContent = currentStep;
    }
}

function SF() {
    console.log("hee")
    if (currentStep < currentFloorData.path.length - 1) {
        console.log("oprreee", currentStep)
        setCS(currentStep + 1);
        console.log("cuccui", currentStep)
        Step(currentStep);
    }
    console.log(currentStep)
}

function SB() {
    if (currentStep > 0) {
        setCS(currentStep - 1);
        console.log("cuccui", currentStep)
        Step(currentStep);
    }
}

async function floorUp() {
    if (currentIndexFloor < currentMapData.floors.length)
        {
        currentIndexFloor += 1;
        await loadFloorData(currentIndexFloor)
        loadFloor()
        Step(0);
        setCS(0);
        document.getElementById("floor-label").textContent = currentMapData.floors[currentIndexFloor].floor
    }
}

async function floorDown() {
    if (currentIndexFloor > 0)
        {
            currentIndexFloor -= 1;
            await loadFloorData(currentIndexFloor)
            loadFloor()
            Step(0);
            setCS(0);
            document.getElementById("floor-label").textContent = currentMapData.floors[currentIndexFloor].floor
        }
}





function calculateTargetAnimation(i, p1, p2){
    if (i == 0){
        return { x: canvas.width / 2,  y: canvas.height / 2, scale: 1, rotation: 0 };
    }
    
    if (!p1 || !p2) return null;

    const [x1, y1] = p1.cordinatepunti.split(',').map(Number);
    const [x2, y2] = p2.cordinatepunti.split(',').map(Number);

    const dx = x2 - x1;
    const dy = y2 - y1;
    const length = Math.hypot(dx, dy);

    let angle = Math.atan2(dy, dx);
    const AngleCorrection = - Math.PI / 2;

    const rotation = AngleCorrection - angle;

    return {
        x: (x1 + x2) / 2,
        y: (y1 + y2) / 2,
        scale: Math.min(canvas.height / (length * 1.5)),
        rotation: rotation
    }
}


function Step(i){
    if (!currentFloorData.path || i<0 || i>= currentFloorData.path.length) return;
    let lpath = currentFloorData.path

    console.log(i)
    console.log("ajsfhksdfh", lpath[i])

    if (i == 0) {
        targetTransform = { x: canvas.width / 2,  y: canvas.height / 2, scale: 1, rotation: 0 }
        startAnimation();
        return
    }

    const p1 = currentFloorData.points.find(pt => pt.name == lpath[i-1]);
    const p2 = currentFloorData.points.find(pt => pt.name == lpath[i]);
    console.log(currentFloorData.points, "pathi", lpath[i-1])

    console.log("points", p1, p2)
    
    if (p1.floor != p2.floor){
        floorUp()
        return;
    }

    const newTarget = calculateTargetAnimation(i, p1, p2);
    if (!newTarget || newTarget == null) return;
    targetTransform = newTarget;
    startAnimation();
}

function startAnimation() {
    if (animationFrameId) cancelAnimationFrame(animationFrameId);
    animate();
}

function animate() {
    // Interpolazione angolo con percorso più breve
    let angleDiff = targetTransform.rotation - currentTransform.rotation;
    angleDiff = ((angleDiff + Math.PI) % (2 * Math.PI)) - Math.PI; // Forza il percorso più breve
    
    currentTransform.rotation += angleDiff * 0.05;
    
    // Interpolazione posizione e scala
    currentTransform.x += (targetTransform.x - currentTransform.x) * 0.05;
    currentTransform.y += (targetTransform.y - currentTransform.y) * 0.05;
    currentTransform.scale += (targetTransform.scale - currentTransform.scale) * 0.05;

    applyTransforms();

    if (needsUpdate()) {
        animationFrameId = requestAnimationFrame(animate);
    }
}

function needsUpdate() {
    return Math.abs(currentTransform.rotation - targetTransform.rotation) > 0.001 ||
           Math.abs(currentTransform.scale - targetTransform.scale) > 0.001;
}

function applyTransforms() {
    // Reset e pulizia
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Centro del canvas
    ctx.translate(canvas.width/2, canvas.height/2);
    
    // Applica rotazione
    ctx.rotate(currentTransform.rotation);
    
    // Scala basata sulla lunghezza del segmento
    ctx.scale(currentTransform.scale, currentTransform.scale);
    
    // Centra sul punto medio
    ctx.translate(-currentTransform.x, -currentTransform.y);

    // Disegno elementi
    loadFloor()

    // Evidenzia segmento corrente
    if (currentStep > 0) {
        const p1 = currentFloorData.points.find(pt => pt.name === path.sequence[currentStep-1]);
        const p2 = currentFloorData.points.find(pt => pt.name === path.sequence[currentStep]);
        
        if (p1 && p2) {
            const [x1, y1] = p1.cordinatepunti.split(',').map(Number);
            const [x2, y2] = p2.cordinatepunti.split(',').map(Number);
            
            ctx.beginPath();
            ctx.moveTo(x1, y1);
            ctx.lineTo(x2, y2);
            ctx.strokeStyle = 'rgba(143, 0, 255, 1)';
            
            const BASE_HIGHLIGHT_WIDTH = 10;
            const displayedRect = canvas.getBoundingClientRect();
            const cssScale = canvas.width / displayedRect.width;
            
            let lineWidth = (BASE_HIGHLIGHT_WIDTH / cssScale) * currentTransform.scale;
            lineWidth = Math.min(MAX_SIZE, Math.max(MIN_SIZE, lineWidth));
            ctx.lineWidth = lineWidth;
            
            ctx.stroke();
        }
    }
}


