document.addEventListener('DOMContentLoaded', function () {
    var contadorDetalles = 0;

    var agregarDetalleButton = document.getElementById('agregarDetalle'); //referencia al boton
    agregarDetalleButton.addEventListener('click', function () {
        var nuevaFila = document.createElement('tr');
        nuevaFila.innerHTML = `
                <td><input type="number" class="form-control" name="DetalleVenta[${contadorDetalles}].Descripcion" value="1" /></td>
                <td><input type="number" class="form-control" name="DetalleVenta[${contadorDetalles}].Cantidad" value="1" /></td>
                    <select class="form-control" name="DetalleVenta[${contadorDetalles}].IdProducto" onchange="cargarValoresPredeterminados(this)">
                        ${document.getElementById('Productos').innerHTML}
                    </select>
                <td><input type="number" class="form-control" name="DetalleVenta[${contadorDetalles}].Precio" value="10.00" /></td>
                <td><input type="number" class="form-control" name="DetalleVenta[${contadorDetalles}].Total" readonly /></td>
                <td><button type="button" class="btn btn-danger" onclick="eliminarFila(this)">Eliminar</button></td>
            `;

        var detallesBody = document.getElementById('detalles-body');
        detallesBody.appendChild(nuevaFila);
        contadorDetalles++;
    });


    var detallesBody = document.getElementById('detalles-body');
    detallesBody.addEventListener('change', function (event) {
        if (event.target.tagName === 'SELECT') {
            var selectedOption = event.target.options[event.target.selectedIndex];
            var precio = parseFloat(selectedOption.getAttribute('data-precio')) || 0;
            var cantidadInput = event.target.closest('tr').querySelector('input[name$="Cantidad"]');
            var cantidad = parseFloat(cantidadInput.value) || 0;
            var total = precio * cantidad;
            event.target.closest('tr').querySelector('input[name$="Precio"]').value = precio;
            event.target.closest('tr').querySelector('input[name$="Total"]').value = total;
        }
    });

});

function eliminarFila(boton) {
    boton.closest('tr').remove();
}