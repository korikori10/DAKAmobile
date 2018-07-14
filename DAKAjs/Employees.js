
EmployeeInfo = new Object();

$(document).ready(function () {
    //get all employees without business
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
    dl.empty();
    $.each(results, function (i, row) {
        if (row.Picture == "") { imageFullPath = "/images/employee-no-one.jpg" }
        else { imageFullPath = row.Picture }
        dynamicLi = '<a href="Wizard.html" id="' + row.Employee_pass_id + '"> <img src="' + imageFullPath + '"/><h3>' + row.Fname + " " + row.Lname + '</h3><p > ' + row.Employee_pass_id + '</p><i class="icon-arrow-left"></i></a>';
        dl.append(dynamicLi);
    });
    $("a").on('click', function () {
        EmployeeInfo.pass = $(this).attr("id");;
        sessionStorage.setItem("empInfo", EmployeeInfo.pass);
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


