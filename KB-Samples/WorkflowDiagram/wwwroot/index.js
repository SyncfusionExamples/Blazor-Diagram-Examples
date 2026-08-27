window.loadIndicator = function() {
    const loadingIndicator = document.getElementsByClassName('loading-indicator');
    // To remove loading indicator.
    for (let l = 0; l < loadingIndicator.length; l++) {
        (loadingIndicator[l]).style.display = 'none';
    }
    // To add tick mark.
    const tick = document.getElementsByClassName('tick');
    for (let l = 0; l < tick.length; l++) {
        (tick[l]).style.display = 'flex';
    }
}
