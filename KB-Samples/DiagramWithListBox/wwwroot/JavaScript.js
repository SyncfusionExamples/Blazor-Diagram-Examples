window.InvokeClockEvent1 = (dotNetHelper, diagramID) => {
    var diagram = document.getElementById(diagramID);
    var wheelHandler = function (e) {
        var bounds = measureScrollValues(e.currentTarget.id);
        e.diagramCanvasScrollBounds = bounds;
        e.diagramGetBoundingClientRect = e.currentTarget.getBoundingClientRect();
        //var zoom = e.wheelDelta > 0 ? true : false;
        ///*  prevent the default behavior of the event*/
        //e.preventDefault();
        ///* Stop the event from propagating further*/
        //e.stopPropagation();
        var sss = window.scrollX.toString() + "adsh" + window.scrollY.toString();
        dotNetHelper.invokeMethodAsync('ChangeState', sss);
    };
    diagram.addEventListener('mouseup', wheelHandler, true);
};
 function getlistViewWidth(id){

     var idw = document.getElementById(id);
     return idw.offsetWidth.toString();
}
measureScrollValues: function measureScrollValues(diagramId) {
    var element = document.getElementById(diagramId);
    var point = new Rect(element.scrollLeft, element.scrollTop, element.scrollWidth, element.scrollHeight);
    return point;
}
function InvokeClockEvent(dotNetHelper, diagramID) {
    var sss = window.scrollX.toString() + "adsh" + window.scrollY.toString();
    return sss;
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