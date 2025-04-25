document.addEventListener("DOMContentLoaded", () => {
    loadEnrollments();
});

async function loadEnrollments() {
    let res = await fetch("/Admin/ListEnrollments"); 
    let data = await res.json();

    const tbody = document.getElementById("enrollmentsTableBody");
    tbody.innerHTML = "";

    if (data.success) {
        data.data.forEach((e, i) => {
            tbody.innerHTML += `
                <tr>
                    <td>${i + 1}</td>
                    <td>${e.studentName}</td>
                    <td>${e.courseName}</td>
                    <td>
                        <button class="btn btn-primary btn-sm" onclick="getAverage(${e.enrollmentID})">
                             View Average
                        </button>
                    </td>
                </tr>`;
        });
    }
}

async function getAverage(enrollmentId) {
    let res = await fetch(`/Admin/GetStudentAverage?enrollmentId=${enrollmentId}`); 
    let data = await res.json();

    const averageBox = document.getElementById("averageBox");
    const averageResult = document.getElementById("averageResult");

    if (data.success) {
        averageBox.classList.remove("d-none");
        averageResult.textContent = `${data.average.toFixed(2)} / 20`;
    } else {
        averageBox.classList.remove("d-none");
        averageResult.textContent = "Could not fetch average.";
    }
}
