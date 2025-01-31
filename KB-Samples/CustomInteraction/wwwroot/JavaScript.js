WiredEvent: function WiredEvent(diagramID, dotNetHelper) {
    var diagram = document.getElementById(diagramID);

    var wheelHandler = function (e) {
        /*  prevent the default behavior of the event*/
        e.preventDefault();
        /* Stop the event from propagating further*/
        e.stopPropagation();
        let delta = e.deltaY; // deltaY is positive for zoom out, negative for zoom in
        dotNetHelper.invokeMethodAsync('OnMouseWheel', delta);
    };

    diagram.addEventListener('wheel', wheelHandler, true);
    diagram.addEventListener('mousewheel', wheelHandler, true);
}
