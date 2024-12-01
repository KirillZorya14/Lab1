async function calculateAndRender() {
    const line1 = { x1: 1, y1: 1, x2: 4, y2: 4 };
    const line2 = { x3: 1, y3: 4, x4: 4, y4: 1 };

    const response1 = await fetch('http://localhost:44390/FindIntersectionService.asmx/FindIntersection', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ ...line1, ...line2 }),
    });
    console.log(response1);
    if (!response1.ok) {
        throw new Error(`Error: ${response1.status} ${response1.statusText}`);
    }
    const intersection = await response1.json();
    const px = intersection.d.X;
    const py = intersection.d.Y;

    console.log('X:', px, 'Y:', py);
    console.log('Intersection:', intersection);

    const response2 = await fetch('http://localhost:44372/RenderGraphService.asmx/RenderGraph', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ ...line1, ...line2, px, py}),
    });
    if (!response2.ok) {
        throw new Error(`Error: ${response2.status} ${response2.statusText}`);
    }
    const svg = await response2.text();
    console.log('SVG:', svg);

    const svgString = JSON.parse(svg).d;
    const svgElement = new DOMParser().parseFromString(svgString, 'image/svg+xml').documentElement;

    document.getElementById('graph').appendChild(svgElement);
}

calculateAndRender();
