
EmployeeInfo = new Object();

$(document).ready(function () {
    getEmployeesnobusiness();
    getEmployeesnobusinesss(renderEmployeesnobusiness);
});


function renderEmployeesnobusiness(results) {
    //this is the callBackFunc 
    totalEmp = 0;
    results = $.parseJSON(results.d);
    for (var i = 1; i <= results.length; i++) {
        totalEmp = i;
    }
    var dl = $('#DynamicEmployeesList');
    $.each(results, function (i, row) {
        dynamicLi = '<a href="Wizard.html" value="' + row.Employee_pass_id + '"> <h3>' + row.Fname + " " + row.Lname + '</h3><p > ' + row.Employee_pass_id + '</p><i class="icon-arrow2"></i></a>';
        EmployeeInfo.pass = row.Employee_pass_id;
        sessionStorage.setItem("empInfo", EmployeeInfo.pass);
        dl.append(dynamicLi);
    });
}

//View button from employee no business
$('.table').on('click', 'tr td button', function () {

    sessionStorage.removeItem("empInfo")
    tr = $(this).closest('tr');//.find('td:first').text();
    tableId = $(this).closest('.table').attr('id');
    var data = $("#" + tableId).DataTable().row(tr).data();
    EmployeeInfo.pass = data['Employee_pass_id'];
    sessionStorage.setItem("empInfo", EmployeeInfo.pass);
    window.location = "Wizard.html";
});


