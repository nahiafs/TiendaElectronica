﻿let carrito;
let total = 0;

if (localStorage.carrito !== undefined){
    carrito = JSON.parse(localStorage.getItem('carrito'));
}
    
if (carrito === undefined){
    carrito = []
}
    

function borrarProducto(a) {
    var list = document.getElementById(a);

    if (list.hasChildNodes()) {
        list.parentNode.removeChild(list);
    }
}
function success(data) {
    anyadirCarrito(data);
    localStorage.setItem('carrito',JSON.stringify(carrito))
    init();
}

function anyadirCarrito(dato) {
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
}
