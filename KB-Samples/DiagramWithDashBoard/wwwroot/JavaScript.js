﻿window.getPanelWidth = function (divId) {
    let div = document.getElementById(divId);
    if (div) {
        let rect = div.getBoundingClientRect();
        return (rect.width / 3) - 5;
    }
    return null;
}