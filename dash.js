EmployeeInfo = new Object();


$(document).ready(function () {
getEmployees(renderEmployees);
getEmployeesnobusiness(renderEmployeesnobusiness);

});



function renderEmployees(results) {
    //this is the callBackFunc 

    results = $.parseJSON(results.d);
   
    var dl = $('#DynamicEmployeesList');
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Employee_pass_id + '">' + row.Fname + " " + row.Lname + '</option>';
    dl.append(dynamicLi);
    });
    ////////////////////////////////////////////
    var select = $(".selectize-select").selectize({
        maxItems: 1, //Max items selectable in the textbox
        maxOptions: 30, //Max options to render at once in the dropdown
        onChange: function (value) {
            sessionStorage.removeItem("empInfo")
            EmployeeInfo.pass = value;
            sessionStorage.setItem("empInfo", EmployeeInfo.pass);
            window.location = "Wizard.html"
        }
    });

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