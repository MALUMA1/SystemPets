document.getElementById("imagenInput").addEventListener("change", function () {
    var fileName = this.files[0].name;
    var label = document.querySelector(".custom-file-label");
    label.textContent = fileName;

    var nombreArchivoDiv = document.getElementById("nombreArchivo");
    nombreArchivoDiv.textContent = "Archivo seleccionado: " + fileName;
});