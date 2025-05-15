function getViewportBounds() {
    var parentElement = document.getElementsByClassName('e-background-layer')[0];
    var firstChild = parentElement.firstElementChild; // Get the first child element

    // Get x, y attributes (they are stored as strings)
    var x = parseFloat(firstChild.getAttribute('x')) || 0;
    var y = parseFloat(firstChild.getAttribute('y')) || 0;
    var width = parseFloat(firstChild.getAttribute('width')) || 0;
    var height = parseFloat(firstChild.getAttribute('height')) || 0;


    return { x, y, width, height };
}