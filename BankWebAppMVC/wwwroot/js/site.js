function renderUserDashboard(data) {
    const accountSection = document.getElementById("accountSection");
    const transactionTable = document.getElementById("transactionTable");

    accountSection.innerHTML = data.accounts
        .map(a => `<div><b>Account:</b> ${a.accountNumber} — Balance: $${a.balance}</div>`)
        .join("");

    transactionTable.innerHTML = data.transactions
        .map(t => `
      <tr>
        <td>${new Date(t.date).toLocaleDateString()}</td>
        <td>${t.transactionType}</td>
        <td>${t.amount.toFixed(2)}</td>
        <td>${t.description || ""}</td>
      </tr>
    `)
        .join("");
}


function renderAdminDashboard(data) {
    const accountSection = document.getElementById("accountSection");
    const transactionTable = document.getElementById("transactionTable");

    accountSection.innerHTML = `<h4>Total Users: ${data.users.length}</h4>`;
    transactionTable.innerHTML = data.transactions
        .map(t => `
      <tr>
        <td>${new Date(t.date).toLocaleDateString()}</td>
        <td>${t.transactionType}</td>
        <td>${t.amount.toFixed(2)}</td>
        <td>${t.description || ""}</td>
      </tr>
    `)
        .join("");
}