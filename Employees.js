﻿
EmployeeInfo = new Object();

$(document).on('pagebeforeshow', '#home', function () {
    getEmployees(renderEmployees);
    getCities(renderCities);
    getEmployeesnobusiness(renderEmployeesnobusiness);
});

$(document).on('pagebeforeshow', '#wizard', function () {
    getCities(renderCities);
});

function renderEmployees(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    eresults = results;
    $('#DynamicEmployeesList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="" data-id="' + row.Employee_pass_id + '"> onclick="'+messageToFillOrders(this.id)+'" <h3>' + row.Fname +" "+ row.Lname + '</h3><p>' + row.Employee_pass_id +'</p></a></li>'
        $('#DynamicEmployeesList').append(dynamicLi);
       $('#DynamicEmployeesList').listview('refresh');
    });
}


function renderCities(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    eresults = results;
    $('#DynamicCitiesList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="" data-id="' + row.id + '">  <h3>' + row.name + '</h3></a></li>'
        $('#DynamicCitiesList').append(dynamicLi);
        $('#DynamicCitiesList').listview('refresh');
    });
}


$("input[name='search']").on("click", function(){
   EmployeeInfo.pass = $("#PassTB").val();
   getEmployeeById(EmployeeInfo, renderEmployeeByID);
    $.mobile.changePage("Wizard.html", {
           transition: "slide", changeHash: false

        });     
});




$(document).on('vclick', '#DynamicEmployeesList li a', function () {
    EmployeeInfo.id = $(this).attr('data-id');
  //  renderFullEmployee(EmployeeInfo, eresults);
    $.mobile.changePage("#employee", {
        transition: "slide", changeHash: false

    });

});


function renderEmployeesnobusiness(NoEmpresults) {
    //this is the callBackFunc 
    NoEmpresults = $.parseJSON(NoEmpresults.d);
    len = Object.keys(NoEmpresults).length;
    document.getElementById("unEmpNum").innerHTML = len;

}


function renderEmployeeByID(results){
    results = $.parseJSON(results.d);
    $('#wizardpage').empty();
    if (results.Employee_pass_id == null) { results = null; }
    else {
    //dynamicList = '<li> <a href="" data-id="' + row.Id + '"> <img src="' + imageFullPath + '"/>  <h3>' + row.Title + '</h3><p>Price: ' + row.Price + '</br>Inventory: ' + row.Inventory + '</p></a></li>'
    //$('#DynamicListproducts').append(dynamicList);
    //$('#DynamicListproducts').listview('refresh');

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





