let $items = document.querySelector('#items');
let total = 0;
let $carrito = document.querySelector('#carrito');
let $total = document.querySelector('#total');
let $mensaje = document.querySelector('#mensaje');
let carrito;

// Tenemos que poner estas comprobaciones para que funcione la recuperación
// del carro en el localStorage
if (localStorage.carrito !== undefined)
    carrito = JSON.parse(localStorage.carrito);
if (carrito === undefined)
    carrito = []
else {
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

//*************************************************
// Funciones
//*************************************************
/*function anyadirCarrito(dato) {
    var encontrado = false;
    if (carrito.length == 0) {
        dato[0].Cantidad = 1;
        carrito.push(dato)
    }
    else {
        var cantidad = 1;
        for (var i = 0; i < carrito.length; i++) {
            var codProducto = carrito[i][0].CodProducto;
            if (codProducto == dato[0].CodProducto && !encontrado) {
                carrito[i][0].Cantidad++;
                encontrado = true;
            }
        }
        if (!encontrado) {
            dato[0].Cantidad = cantidad;
            carrito.push(dato);
        }
    }
    calcularTotal(carrito);
    renderizarCarrito(carrito);
    init();
}*/

function renderizarCarrito(carrito) {
    $carrito.textContent = '';
    // Generamos los Nodos a partir de carrito
    var indice = 0;

    for (let miItem of carrito) {
        // Creamos el nodo del item del carrito
        let miNodo = document.createElement('li');
        miNodo.classList.add('list-group-item', 'text-right');
        // Imagen del producto
        let miImagen = document.createElement('img');
        miImagen.src = miItem[0]['Imagen'];
        miImagen.style.width = '100px';
        // Informacion producto
        let miProducto = document.createElement('span');
        miProducto.innerHTML = `${parseInt(miItem[0].Cantidad)} - ${miItem[0]['Nombre']} - ${parseInt(miItem[0]['Precio']) * parseInt(miItem[0].Cantidad)}€`;
        // Boton de borrar
        let miBoton = document.createElement('button');
        miBoton.classList.add('btn', 'btn-danger', 'mx-5');
        miBoton.textContent = 'X';
        miBoton.setAttribute('posicion', indice);
        indice = indice + 1;
        miBoton.addEventListener('click', borrarItemCarrito);
        // Mezclamos nodos
        miNodo.appendChild(miImagen);
        miNodo.appendChild(miProducto);
        miNodo.appendChild(miBoton);
        miNodo.style.display = 'flex';
        miNodo.style.alignItems = 'center';
        miNodo.style.justifyContent = 'space-between';
        $carrito.appendChild(miNodo);
    }
}

function borrarItemCarrito() {
    let posicion = this.getAttribute('posicion');
    carrito.splice(posicion, 1);
    localStorage.removeItem("carrito");
    localStorage.carrito = JSON.stringify(carrito);
    renderizarCarrito(carrito);
    calcularTotal(carrito);
    init();
}

function calcularTotal(carrito) {
    // Limpiamos precio anterior
    total = 0;
    // Recorremos el array del carrito
    for (let miItem of carrito) {
        var cantidad = parseInt(miItem[0].Cantidad);
        // ---------- VER ------------------
        var totalProducto = parseInt(miItem[0]['Precio']) * cantidad;
        total = total + totalProducto;
        //total = total + parseInt(miItem[0]['Precio']);
    }
    // Formateamos el total para que solo tenga dos decimales
    let totalDosDecimales = total.toFixed(2);
    // Renderizamos el precio en el HTML
    $total.textContent = totalDosDecimales;
}

/*function success(data) {
    console.log(data.Nombre);
    anyadirCarrito(data);
    localStorage.carrito = JSON.stringify(carrito);
}*/

function comprar() {
    if (carrito.length > 0) {
        var uri = '/Producto/comprar';
        var lineas = lineasFactura(carrito);
        //EN ESTE APARTADO CUANDO LA COMPRA SEA CORRECTA SE SACARÁ MENSAJE INFORMATIVO Y SE BORRARÁ EL CARRITO
        //DE localStorage.
        $.ajax({
            url: uri,
            data: JSON.stringify(lineas),
            type: 'POST',
            success: exito,
            contentType: 'application/json'
        });
    }
}

function exito(data) {
    // Esta función se ejecuta cuando la petición AJAX ha tenido éxito visualizando el mensaje en html.
    $mensaje.textContent = data;
    alert(data);
    // Se realiza el borrado del carrito del almacén local una vez que la compra ha tenido éxito.
    localStorage.removeItem("carrito");
    $carrito.textContent = '';
    $total.textContent = '';
    init();
}

function lineasFactura(carrito) {
    var lineas = [];
    var lf = {};
    for (let miItem of carrito) {
        lf = {};
        lf.CodFactura = "";
        lf.Producto = miItem[0].CodProducto;
        lf.Cantidad = miItem[0].Cantidad;
        lf.Total = miItem[0].Precio * lf.Cantidad;
        lineas.push(lf);
    }
    return lineas;
}
