window.addEventListener("load", init);

/*
 Funcion que se encarga de darle valor al badge del boton carrito, el cual indicara con un numero los elementos que tiene el carrito
 */
function init() {
    let $numElementosCarrito = document.querySelector("#numElementsCarrito");

    let carrito;
    if (localStorage.getItem('carrito') !== null) {
        carrito = JSON.parse(localStorage.getItem('carrito'));
    }

    if (carrito === undefined || carrito.length === 0) {
        carrito = [];
        $numElementosCarrito.textContent = 0;
    } else {
        /*
         * Lo que hace aqui es una funcion callback con un sumatorio, 
         * el metodo reduce lo que hace es pasar por parametros("elemento" en este caso) los elementos del array, 
         * y total es el parametro que devolvera, en este caso lo que hacemos es para cada Objeto.Cantidad que esta dentro del array carrito, le sumamos el valor a total, que empezara en 0
         * con esto, conseguimos que recorra todo el array de carrito y haga el sumatorio de los elementos Cantidad.
        */
        let suma = carrito.reduce((total, elemento) => total + elemento[0].Cantidad, 0);
        $numElementosCarrito.textContent = suma;
    }
    console.log(carrito)
}