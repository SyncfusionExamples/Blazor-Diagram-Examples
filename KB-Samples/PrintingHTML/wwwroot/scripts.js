window.print = function print(id) {
    var printContent = document.getElementById(id);
    var WinPrint = window.open('', '', 'width=900,height=690');
    WinPrint.document.write(printContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
}