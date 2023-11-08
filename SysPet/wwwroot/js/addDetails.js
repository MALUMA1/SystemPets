

function SetItems() {
    document.querySelectorAll('select').forEach(function (select) {
        select.addEventListener('change', function () {
            var selectedOption = select.options[select.selectedIndex];
            var precio = parseFloat(selectedOption.getAttribute('data-precio'));
            var descripcion = selectedOption.getAttribute('data-descripcion');
            var cantidad = parseFloat(document.getElementById('Cantidad').value);
            var total = document.getElementById('Total');
            var cantidadArticulos = document.getElementById('CantidadArticulos');
            var totalItem = document.getElementById('Total-item');

            if (isNaN(cantidad)) {
                cantidad = 1;
            }

            var totalByItem = precio * cantidad;
            var totalSale = totalByItem;

            document.getElementById('Precio').value = precio;
            document.getElementById('Descripcion').value = descripcion;

            totalItem.value = totalByItem;
            total.value = totalSale;
            cantidadArticulos.value = cantidad; // Asigna el valor de cantidad a cantidadArticulos
        });
    });

}


function actualizarCampos() {
    var select = document.getElementById('miDropdown');
    var precioInput = document.getElementById('Precio');
    var descripcionInput = document.getElementById('Descripcion');

    var selectedOption = select.options[select.selectedIndex];

    if (selectedOption.value === "") {
        precioInput.value = "";
        descripcionInput.value = "";
    } else {
        var precio = selectedOption.getAttribute('data-precio');
        var descripcion = selectedOption.getAttribute('data-descripcion');
        precioInput.value = precio;
        descripcionInput.value = descripcion;
    }
}



