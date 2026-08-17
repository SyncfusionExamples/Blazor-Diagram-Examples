// Function to remove background from the selected symbol
function removeSelectedSymbolBackground() {
    // Query the selected element
    var selectedElement = document.querySelector('.e-symbolpalette .e-symbol-selected');

    if (selectedElement) {
        selectedElement.classList.remove("e-symbol-selected");
        selectedElement.classList.remove("e-symbol-hover");
    }
}