EmployeeInfo = new Object();
$(document).on('load', function () {

});

$(document).ready(function () {
getEmployees(renderEmployees);

  //  getEmployeesnobusiness(renderEmployeesnobusiness);
});



function renderEmployees(results) {
    //this is the callBackFunc 
    //results = $.parseJSON(results.d);
    EmployeeInfo = results.d

    $(".selectize-select").selectize({
        create: true,
        valueField: 'Emp_Pass_id',
        lableField: 'Fname',
        sortField: 'text',
        searchField: ['Emp_Pass_id', 'Fname', 'Lname'],
        options: EmployeeInfo
    });
 
    //eresults = results;
    //$('#DynamicEmployeesList').empty();
    //$.each(results, function (i, row) {
    //    dynamicLi = '<option value="' + row.Employee_pass_id + '">'+ row.Fname + " " + row.Lname + '</option>'
    //    $('#DynamicEmployeesList').append(dynamicLi);
        //$('#DynamicEmployeesList').listview('refresh');
   // });
}