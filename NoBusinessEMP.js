

$(document).ready(function () {
    getEmployeesnobusiness(renderEmployeesnobusiness);
});

function renderEmployeesnobusiness(NoEmpresults) {
    //this is the callBackFunc 
    NoEmpresults = $.parseJSON(NoEmpresults.d);
    len = Object.keys(NoEmpresults).length;
    document.getElementById("unEmpNum").innerHTML = len;

}

$('.table').on('click', 'tr td button', function () {

    sessionStorage.removeItem("empInfo")
    tr = $(this).closest('tr');//.find('td:first').text();
    tableId = $(this).closest('.table').attr('id');
    var data = $("#" + tableId).DataTable().row(tr).data();
    EmployeeInfo.pass = data['Employee_pass_id'];
    sessionStorage.setItem("empInfo", EmployeeInfo.pass);
    window.location = "Wizard.html";
});