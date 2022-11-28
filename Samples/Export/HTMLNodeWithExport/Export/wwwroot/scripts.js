
window.getDiagramContent = function getDiagramContent(id) {

    var diagram = document.getElementById(id).innerHTML;
    return diagram;
}

window.getDiagramBounds = function getDiagramBounds(id) {
    var diagram = document.getElementById(id);
    var bounds = diagram.getBoundingClientRect();
    return bounds;
}

window.download = function download(image) {
    var el = document.createElement("a");
    el.setAttribute("href", image);
    el.setAttribute("download", "diagram");
    document.body.appendChild(el);
    el.click();
    el.remove();
}

