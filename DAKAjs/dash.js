﻿EmployeeInfo = new Object();


$(document).ready(function () {

    getEmployees(renderEmployees);
    //statistics
getEmployeesnobusinesss(renderEmployeesnobusiness);

});


//Searchbox Selectize
function renderEmployees(results) {
    //this is the callBackFunc 
    totalEmp = 0;
    results = $.parseJSON(results.d);
    for (var i = 1; i <= results.length; i++) {
        totalEmp = i;
    }
    var dl = $('#DynamicEmployeesList');
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Employee_pass_id + '">' + row.Fname + " " + row.Lname + '</option>';
    dl.append(dynamicLi);
    });
    ////////////////////////////////////////////
    var select = $(".selectize-select").selectize({
        maxItems: 1, //Max items selectable in the textbox
        maxOptions: 30, //Max options to render at once in the dropdown
        onItemAdd: function (value) {
            sessionStorage.removeItem("empInfo")
            EmployeeInfo.pass = value;
            sessionStorage.setItem("empInfo", EmployeeInfo.pass);
            window.location = "Wizard.html"
        }
    });

}
     
//Statistics
function renderEmployeesnobusiness(NoEmpresults) {
    //this is the callBackFunc 
    NoEmpresults = $.parseJSON(NoEmpresults.d);
    len = Object.keys(NoEmpresults).length;
    document.getElementById("unEmpNum").innerHTML = len;
    document.getElementById("unEmpNum2").value = len;
    document.getElementById("unEmpNum2").max= totalEmp;
    $(".knob").knob(); 
}

//Search Modal
$("#SearchEmployee").on("click", function () {
      
    sessionStorage.removeItem("empInfo")
    EmployeeInfo.pass = $("#PassTB").val();
    sessionStorage.setItem("empInfo", EmployeeInfo.pass);
    window.location = "Wizard.html"
});