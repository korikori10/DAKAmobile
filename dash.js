EmployeeInfo = new Object();


$(document).ready(function () {
getEmployees(renderEmployees);
getEmployeesnobusiness(renderEmployeesnobusiness);

  //  getEmployeesnobusiness(renderEmployeesnobusiness);
});



function renderEmployees(results) {
    //this is the callBackFunc 

    results = $.parseJSON(results.d);
   
   // EmployeeInfo = results.d

        //create: true,
        //valueField: 'Emp_Pass_id',
        //lableField: 'Fname',
        //sortField: 'text',
        //searchField: ['Emp_Pass_id', 'Fname', 'Lname'],
        //options: EmployeeInfo
    
    //var select = $("#DynamicEmployeesList")
    //$.each(results, function (i, row) {

    //    select.selectize().addOption({ value: row.Employee_pass_id, text: row.Fname + " " + row.Lname });
    //    select.selectize.addItem(row.Employee_pass_id)
    //});

    var dl = $('#DynamicEmployeesList');
    console.log("1:" + dl)
    //dl.empty();
    console.log("2:" +dl)
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Employee_pass_id + '">' + row.Fname + " " + row.Lname + '</option>';
    dl.append(dynamicLi);
       // $('#DynamicEmployeesList').listview('refresh');
    });
    $(".selectize-select").selectize();
}

function renderEmployeesnobusiness(NoEmpresults) {
    //this is the callBackFunc 
    NoEmpresults = $.parseJSON(NoEmpresults.d);
    len = Object.keys(NoEmpresults).length;
    document.getElementById("unEmpNum").innerHTML = len;
    $(".knob").knob();
}
$("#SearchEmployee").on("click", function () {
    
    
    sessionStorage.removeItem("empInfo")
    EmployeeInfo.pass = $("#PassTB").val();
    sessionStorage.setItem("empInfo", EmployeeInfo.pass);
    window.location = "Wizard.html"
});