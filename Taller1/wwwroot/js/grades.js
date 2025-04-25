document.addEventListener("DOMContentLoaded", async () => {
    const res = await fetch("/Admin/ListEnrollments");
    const data = await res.json();

    if (data.success) {
        const select = document.getElementById("enrollmentId");
        data.data.forEach(e => {
            let opt = document.createElement("option");
            opt.value = e.enrollmentID;
            opt.text = `${e.studentName} - ${e.courseName}`;
            select.appendChild(opt);
        });
    }
});


async function submitGrade() {
    const enrollmentIdRaw = document.getElementById("enrollmentId").value;
    

    const payload = {
        enrollmentID: parseInt(enrollmentIdRaw),
        gradeType: document.getElementById("gradeType").value,
        gradeValue: parseFloat(document.getElementById("gradeValue").value),
        gradeDate: document.getElementById("gradeDate").value
    };

    console.log("Enviando datos:", payload);

    const res = await fetch("/Admin/RegisterGrade", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
    });

    const result = await res.json();
    if (result.success) {
        alert("✅ Grade registered successfully!");
        document.getElementById("gradeForm").reset();
    } else {
        alert("❌ Error registering grade.");
    }
}

