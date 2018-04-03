
EmployeeInfo = new Object();

$(document).ready(function () {
    getEmployees(renderEmployees);
});


function renderEmployees(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    eresults = results;
    $('#DynamicEmployeesList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="" data-id="' + row.Employee_pass_id + '"> <h3>' + row.Fname +" "+ row.Lname + '</h3><p>' + row.Employee_pass_id +'</p></a></li>'
        $('#DynamicEmployeesList').append(dynamicLi);
       $('#DynamicEmployeesList').listview('refresh');
    });
}

function renderEmployeeByID(results){
    results = $.parseJSON(results.d);
    $('#wizardpage').empty();
    if (results.Employee_pass_id == null) { results = null; }
    else {


    }
}

function renderFullEmployee(results) {
    //this is the callBackFunc 
    // results = $.parseJSON(results.d);
    $.each(eresults, function (i, row) {
        if (EmployeeInfo.id == row.Emloyee_pass_id) {
            $('#employeePage').empty();

        }
        //$('#employeePage').append(dynamicLi);
    });

    }







