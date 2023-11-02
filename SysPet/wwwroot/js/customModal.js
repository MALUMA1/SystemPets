document.addEventListener("DOMContentLoaded", function () {
    var elementos = document.querySelectorAll(".open-modal");

    elementos.forEach(function (elemento) {
        elemento.addEventListener("click", function () {
            var elementoId = this.getAttribute("data-id");
            var xhr = new XMLHttpRequest();
            xhr.open("GET", "/Appointment/ShowDetails?id=" + elementoId, true);

            xhr.onload = function () {
                if (xhr.status === 200) {
                    document.getElementById("exampleModal").innerHTML = xhr.responseText;
                }
            };

            xhr.send();
        });
    });
});


