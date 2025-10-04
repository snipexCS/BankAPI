function filterTransactions() {
    const from = document.getElementById("fromDate").value;
    const to = document.getElementById("toDate").value;
    const rows = document.querySelectorAll("#transactionsBody tr");
    rows.forEach(row => {
        const date = new Date(row.cells[3].innerText);
        const fromDate = from ? new Date(from) : null;
        const toDate = to ? new Date(to) : null;
        if ((fromDate && date < fromDate) || (toDate && date > toDate)) {
            row.style.display = "none";
        } else {
            row.style.display = "";
        }
    });
}
function searchUsers() {
    const input = document.getElementById("searchInput").value.toLowerCase();
    const rows = document.querySelectorAll("#usersTable tbody tr");

    rows.forEach(row => {
        const name = row.cells[1].innerText.toLowerCase();
        const email = row.cells[2].innerText.toLowerCase();
        const phone = row.cells[3].innerText.toLowerCase();
        if (name.includes(input) || email.includes(input) || phone.includes(input)) {
            row.style.display = "";
        } else {
            row.style.display = "none";
        }
    });
}
document.addEventListener("DOMContentLoaded", function () {
    const success = document.getElementById("success-message");
    const error = document.getElementById("error-message");

    if (success) {
        setTimeout(() => success.style.display = 'none', 4000);
    }
    if (error) {
        setTimeout(() => error.style.display = 'none', 4000);
    }
});
