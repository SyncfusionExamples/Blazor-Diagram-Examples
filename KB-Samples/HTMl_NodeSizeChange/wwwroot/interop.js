window.textAreaResize = (elementId) => {
    const textarea = document.getElementById(elementId);
    const height = textarea.scrollHeight;
    const width = textarea.scrollWidth;
  const container = textarea.parentElement;
    
    textarea.style.height = 'auto'; // Reset height to auto
    textarea.style.height = Math.min(container.clientHeight, textarea.scrollHeight) + 'px'; // Set height to content size or container max height

    return { height, width };
}