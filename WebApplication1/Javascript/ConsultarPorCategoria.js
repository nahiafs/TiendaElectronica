function borrarProducto(id) {
    var lista = document.getElementById(id);

    if (lista.hasChildNodes) {
        lista.parentNode.removeChild(lista);
    }
}