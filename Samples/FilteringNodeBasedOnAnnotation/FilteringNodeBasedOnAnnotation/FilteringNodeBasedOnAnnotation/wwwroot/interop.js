window.getDiagramViewportBounds = function () {

    var bounds = document.getElementsByClassName('e-control e-diagram e-lib e-droppable e-tooltip');

    return bounds[0].getBoundingClientRect();

}

