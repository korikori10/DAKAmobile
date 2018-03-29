selectedCity = new Object();
EmployeeInfo = new Object();
resultsSave = new Object();
isUpdate = new Object();

$(document).on('pagebeforeshow', '#wizard', function () {
    getCities(renderCities);
    getCountries(renderCountries);
    getBusinesses(renderBusinesses);
});
$(document).ready(function () {

});
function fixDate (date) {
    var date = new Date(parseInt(date.substr(6)));
    var month = date.getMonth() + 1;
    return date.getFullYear() + "-" + month + "-" + date.getDate();
}
function populate(frm, data) {
    $.each(data, function (key, value) {
        var ctrl = $('[name=' + key + ']', frm);
     
        switch (ctrl.prop("type")) {
            case "radio": case "checkbox": 
                ctrl.each(function () {
                    if ($(this).attr('value') == value) $(this).attr("checked", value);
                });
                break;
            case "file":
                break;
            case "select-one":
                ctrl.val(value).prop('selected', true)
                ctrl.selectmenu("refresh");
                break;
            default:
                ctrl.val(value);
               
        }
    });
}
function renderEmployeeByID(results) {

    results = $.parseJSON(results.d);
    resultsSave = results;
    if (results.Employee_pass_id == null) {
        isUpdate = false;
        $("#passportid").val(EmployeeInfo.pass);
        results = null;
    }
    else {
        var frm = $("#insertEmpForm");
        var data = results;
        isUpdate = true;
        data.Birthday = fixDate(data.Birthday);
        populate(frm, data);
        //$('#name').val(results.Fname + " " + results.Lname);
        //$('#sysIdTB').val(results.Sys_id);
        ////$('#dobTB').val(function  () {
        ////    var date = new Date(parseInt(results.Birthday.substr(6)));
        ////      var month = date.getMonth() + 1;
        ////      return date.getDate() + "/" + month + "/" + date.getFullYear();
        ////  });

        //Business = results.
        //$('#empPassTB').val(results.Employee_pass_id);
        //$('#addressTB').val(results.Add);
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
      //  $('#DynamiCountryList').listview('refresh');
        EmployeeInfo.pass = sessionStorage.getItem("empInfo");
        getEmployeeById(EmployeeInfo, renderEmployeeByID);
        $('.selectize-select').selectize;
    });
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

    if (isUpdate) {
    if (array.Business == resultsSave.Business) {
        array.updateBus = false;
    }
    else {
        array.updateBus = true;
        updateEmployee({ EmployeeInfo: JSON.stringify(array) })
    }
    }
    else {
      //  array.updateBus = true; 
    insertEmployee({ EmployeeInfo: JSON.stringify(array) });
    }
    }
