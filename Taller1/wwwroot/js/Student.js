async function registrarEstudiante() {
    const form = document.getElementById("formStudent");
    const formData = new FormData(form);

    const res = await fetch("/Admin/Register", {
        method: "POST",
        body: formData
    });

    const data = await res.json();

    if (data.success) {
        alert("✅ Estudiante registrado correctamente.");
        form.reset();
    } else {
        alert("❌ Hubo un error al registrar el estudiante.");
    }
}
