function GetHeightWidth(id) {
    const element = document.getElementById(id);

    if (element != null) {
        const height = element.offsetHeight.toString();
        const width = element.offsetWidth.toString();

        return height.toString() + "values" + width.toString();
    }

    return null;
}


