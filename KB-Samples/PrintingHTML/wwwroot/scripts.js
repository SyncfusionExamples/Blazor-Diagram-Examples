window.print = function print(id) {
    var printContent = document.getElementById(id).innerHTML;
    var WinPrint = window.open('', '', 'width=900,height=690');
    // Apply required styles (e.g., Syncfusion theme or custom CSS)
    WinPrint.document.write('<link rel="stylesheet" type="text/css" href="_content/Syncfusion.Blazor.Themes/bootstrap5.css">');
    WinPrint.document.write(printContent);
    WinPrint.document.close();
    WinPrint.onload = function () {
        setTimeout(function () {
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }, 100);
    }
};