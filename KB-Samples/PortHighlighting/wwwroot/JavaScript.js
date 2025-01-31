
function getDiagramViewportBounds() {

    var bounds = document.getElementsByClassName("e-background-layer")[0].getBoundingClientRect();
    return bounds;
    //return {
    //    x: bounds.x, y: bounds.y, width: bounds.width, height: bounds.height
    //};

}
var Rect = /** @class */function () {
    function Rect(x, y, width, height) {
        /**
         * Sets the x-coordinate of the starting point of a rectangular region
         *
         * @default 0
         */
        this.x = Number.MAX_VALUE;
        /**
         * Sets the y-coordinate of the starting point of a rectangular region
         *
         * @default 0
         */
        this.y = Number.MAX_VALUE;
        /**
         * Sets the width of a rectangular region
         *
         * @default 0
         */
        this.width = 0;
        /**
         * Sets the height of a rectangular region
         *
         * @default 0
         */
        this.height = 0;
        if (x === undefined || y === undefined) {
            x = y = Number.MAX_VALUE;
            width = height = 0;
        } else {
            if (width === undefined) {
                width = 0;
            }
            if (height === undefined) {
                height = 0;
            }
        }
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    /**   @private  */
    Rect.empty = new Rect(Number.MAX_VALUE, Number.MIN_VALUE, 0, 0);
    return Rect;
}();
var args = {};
measureScrollValues: function measureScrollValues(diagramId) {
    var element = document.getElementById(diagramId);
    var point = new Rect(element.scrollLeft, element.scrollTop, element.scrollWidth, element.scrollHeight);
    return point;
}


WiredEvent: function WiredEvent(diagramID) {
    var diagram = document.getElementById(diagramID);
    var tooltip = document.getElementById('diagramTooltip');

    document.body.appendChild(tooltip);
    var moveHandler = function (e) {
        var bounds = measureScrollValues(e.currentTarget.id);
        var bounds = diagram.getBoundingClientRect();
        var canvasScrollLeft = diagram.scrollLeft;
        var canvasScrollTop = diagram.scrollTop;
        e.diagramCanvasScrollBounds = bounds;
        e.diagramGetBoundingClientRect = e.currentTarget.getBoundingClientRect();
        // Update tooltip position and content
        // Calculate mouse position relative to the diagram
        var mouseX = e.clientX - bounds.left + canvasScrollLeft;
        var mouseY = e.clientY - bounds.top + canvasScrollTop;

        // Update tooltip position and content
        tooltip.style.left = `${e.clientX + 10}px`; // Offset for visibility
        tooltip.style.top = `${e.clientY + 10}px`;
        tooltip.style.display = 'block';
        tooltip.textContent = `X: ${mouseX.toFixed(2)}, Y:${mouseY.toFixed(2)}`;
        DotNet.invokeMethodAsync('SF663142', 'InvokeEvent', e.diagramCanvasScrollBounds, e.diagramGetBoundingClientRect, e.clientX, e.clientY);

    };

    var mouseLeaveHandler = function () {
        // Hide the tooltip when the mouse leaves the diagram
        tooltip.style.display = 'none';
    };

    diagram.addEventListener('move', moveHandler, true);
    diagram.addEventListener('mousemove', moveHandler, true);
    diagram.addEventListener('leave', mouseLeaveHandler, true);
    diagram.addEventListener('mouseleave', mouseLeaveHandler, true);
}

