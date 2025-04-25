async function registerEnrollment() {
    const form = document.getElementById("enrollmentForm");
    const formData = new FormData(form);

    const res = await fetch("/Admin/RegisterToCourse", {
        method: "POST",
        body: formData
    });

    const data = await res.json();

    if (data.success) {
        alert(" Student enrolled successfully.");
        form.reset();
    } else {
        alert(" Failed to enroll student. ");
    }
}
