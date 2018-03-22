EmployeeInfo = new Object();


$(document).ready(function () {
getEmployees(renderEmployees);
    $(".selectize-select").selectize();

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
    
    var select = $("#DynamicEmployeesList")
    $.each(results, function (i, row) {

        select.selectize.addOption({ value: row.Employee_pass_id, text: row.Fname + " " + row.Lname });
        select.selectize.addItem(row.Employee_pass_id)
    });
 
    //eresults = results;
    //$('#DynamicEmployeesList').empty();
    //$.each(results, function (i, row) {
    //    dynamicLi = '<option value="' + row.Employee_pass_id + '">'+ row.Fname + " " + row.Lname + '</option>'
    //    $('#DynamicEmployeesList').append(dynamicLi);
        //$('#DynamicEmployeesList').listview('refresh');
   // });
}
$("#SearchEmployee").on("click", function () {
    EmployeeInfo.pass = $("#PassTB").val();
    getEmployeeById(EmployeeInfo, renderEmployeeByID);

    window.location = "Wizard.html"
});