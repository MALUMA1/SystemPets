function validarContrasenas()
{
    var password = document.getElementsByName("Contrasenia")[0].value;
    var confirmPassword = document.getElementsByName("ConfirmPassword")[0].value;

    if (password !== confirmPassword) {
        document.getElementById("errorPasswordMismatch").textContent = "Las contraseñas no coinciden.";
    return false; // Evita que se envíe el formulario
    }

    // Si las contraseñas coinciden, borra el mensaje de error y permite que se envíe el formulario
    document.getElementById("errorPasswordMismatch").textContent = "";
    return true;
}