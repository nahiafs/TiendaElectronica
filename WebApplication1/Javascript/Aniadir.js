let $mensaje = document.querySelector("#mensaje");

function Enviar() {
    event.preventDefault();
    var uri = '@Url.Action("Aniadir", "Producto")';
    var producto = {};
    producto = cargarProducto(producto);
    $.ajax({
        url: uri,
        data: JSON.stringify(producto),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function exito(data) {
    $mensaje.textContent = data;
}

function cargarProducto(producto) {
    producto.Nombre = document.getElementById("nombre").value;
    producto.Marca = document.getElementById("marca").value;
    producto.Categoria = document.getElementById("categoria").value;
    producto.Precio = document.getElementById("precio").value;
    producto.Imagen = document.getElementById("imagen").value;

    if (document.getElementById("nuevo").checked)
        producto.Estado = document.getElementById("nuevo").value;
    if (document.getElementById("segundaMano").checked)
        producto.Estado = document.getElementById("segundaMano").value;

    return producto;
}