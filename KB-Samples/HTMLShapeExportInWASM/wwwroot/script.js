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
    el.click();
    el.remove();
}

window.exportToImage = async function(elementId)
{
    var element = document.querySelector("#" + elementId);
    var image = "";
    await html2canvas(element).then(canvas => image = canvas.toDataURL("image/png"));
    var link = document.createElement("a");
    link.href = image;
    link.download = "diagram.png";
    link.click();
}
window.exportToPdf = async function (elementId) {
    var element = document.querySelector("#" + elementId);
    var image = "";
    await html2canvas(element).then(canvas => image = canvas.toDataURL("image/png"));

    return image;
}
window.downloadPdf = function (base64String, fileName) {
    var sliceSize = 512;
    var byteCharacters = atob(base64String);
    var byteArrays = [];
    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    var blob = new Blob(byteArrays,
        {
            type: 'application/pdf'
        }
    );
    var blobUrl = window.URL.createObjectURL(blob);
    this.triggerDownload("PDF", fileName, blobUrl);
}
window.triggerDownload = function (type, fileName, url) {
    var anchorElement = document.createElement('a');
    anchorElement.download = fileName + '.' + type.toLocaleLowerCase();
    anchorElement.href = url;
    anchorElement.click();
}