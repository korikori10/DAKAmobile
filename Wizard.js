﻿selectedCity = new Object();
EmployeeInfo = new Object();
resultsSave = new Object();
isUpdate = new Object();
EmpPic = new Object();

$(document).ready(function () {
    getCities(renderCities);
    getCountries(renderCountries);
    getBusinesses(renderBusinesses);
    $("#Pic").on("change", function () {
        var files = $(this).get(0).files;
        if (files.length>0) {


        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i])
        }
        uploadFiles(formData , setEmpFile);


}
    })
});
$(window).load(function () {
   // document.getElementById("first").disabled = true; 
    //current_fs = $('#first');
    //next_fs = $('#second');
    //next_fs.show();
    //current_fs.hide();
});

function setEmpFile(results)
{
    //results = $.parseJSON(results.d);
    EmpPic = results;
}
 function fixDate(date) {
    var date = new Date(parseInt(date.substr(6)));
    var month = date.getMonth() + 1;
    var day = date.getDate();
    if (month.toString().length < 2) { month = '0' + month; }
    if (day.toString().length < 2) { day = '0' + day; }
    return date.getFullYear() + "-" + month + "-" + day;

}
function populate(frm, data) {
    $.each(data, function (key, value) {
        var ctrl = $('[name=' + key + ']', frm);
      //  console.log(ctrl.prop("type"))
        switch (ctrl.prop("type")) {
            case "radio": case "checkbox": 
                ctrl.each(function () {
                    if ($(this).attr('value') == value) $(this).attr("checked", value);
                });
                break;
            case "file":
                break;
            case "select-one":
                if (value === true) {
                    value = 'T';
                }
                else if (value === false) {
                    value = 'F';
                }
                ctrl.val(value);
                break;
            default:
              ctrl.val(value);
               
        }
    }

    );
}
function renderEmployeeByID(results) {

    results = $.parseJSON(results.d);
    resultsSave = results;
    if (results.Employee_pass_id == null) {
        isUpdate = false;
        $("#passportid").val(EmployeeInfo.pass);
        results = null;
        document.getElementById("kindoform").innerHTML = "ברוכים הבאים! זוהי קליטה חדשה,אנא הזן את כל הפרטים";
    }
    else {
        var frm = $("#insertEmpForm");
        var data = results;
        isUpdate = true;
        data.Birthday = fixDate(data.Birthday);
        populate(frm, data);
        $('.selectize-select').selectize();
        document.getElementById("kindoform").innerHTML = "עובד זה כבר פעיל במערכת, יש לבצע ציוות מחדש בלבד";

        
    }

}

function renderBusinesses(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#businessSE').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Bus_id + '">' + row.Bus_name + '</option>';
        $('#businessSE').append(dynamicLi);
      //  $('#DynamicCitiesList').listview('refresh');
        
    });
}

function renderCountries(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#DynamiCountryList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Id + '">' + row.Name + '</option>';
        $('#DynamiCountryList').append(dynamicLi);
       
    });
        EmployeeInfo.pass = sessionStorage.getItem("empInfo");
        getEmployeeById(EmployeeInfo, renderEmployeeByID);
}
function renderCities(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#DynamicCitiesList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Id + '">' + row.Name + '</option>';
        $('#DynamicCitiesList').append(dynamicLi);
        //  $('#DynamicCitiesList').listview('refresh');
    });
}

//$(document).on('vclick', '#DynamicCitiesList li a', function () {
//    selectedCity.Name = $(this).attr('data-id');
//    $(this).closest('[data-role=listview]').prev('form').find('input').val(selectedCity.Name);
//    $(this).closest('[data-role=listview]').prev('form').find('input').attr("name", "city");
//    $(this).closest('[data-role=listview]').children().addClass('ui-screen-hidden');


//});

//$(document).on('vclick', '#DynamiCountryList li a', function () {
//    selectedCity.Name = $(this).attr('data-id');
//    $(this).closest('[data-role=listview]').prev('form').find('input').val(selectedCity.Name);
//    $(this).closest('[data-role=listview]').prev('form').find('input').attr("name","country");
//    $(this).closest('[data-role=listview]').children().addClass('ui-screen-hidden');


//});

function insertEmp(array) {
       
    
    //EmployeeInfo = array;
    array.Picture = EmpPic;
    if (isUpdate)
    {
    if (array.Business == resultsSave.Business) {
        array.updateBus = false;
    }
    else {
        array.updateBus = true;
    }
        updateEmployee({ EmployeeInfo: JSON.stringify(array) })
    }
    else {
      //  array.updateBus = true; 

    insertEmployee({ EmployeeInfo: JSON.stringify(array) });
    }
    }
