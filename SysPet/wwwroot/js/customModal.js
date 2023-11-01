document.addEventListener("DOMContentLoaded", function () {
    var customTooltipElements = document.querySelectorAll(".custom-tooltip");

    customTooltipElements.forEach(function (element) {
        element.addEventListener("click", function (e) {
            e.preventDefault();
            var target = element.getAttribute("data-target");
            var href = element.getAttribute("href");

            var xhr = new XMLHttpRequest();
            xhr.open("GET", href, true);

            xhr.onload = function () {
                if (xhr.status === 200) {
                    var modalContent = xhr.responseText;
                    var targetModal = document.querySelector(target);

                    if (targetModal) {
                        targetModal.innerHTML = modalContent;

                        var modal = new bootstrap.Modal(targetModal);
                        modal.show();
                    }
                }
            };

            xhr.send();
        });
    });
});
