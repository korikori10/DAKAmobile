﻿selectedCity = new Object();
EmployeeInfo = new Object();
resultsSave = new Object();
isUpdate = new Object();
var updateBus = new Object();
var EmpPic = null;
EmpVisa = new Object();
EmpID = new Object();
EmpAuth = new Object();

$(document).ready(function () {
    getCities(renderCities);
    getCountries(renderCountries);
    getBusinesses(renderBusinesses);
    getOccu(renderOccu);

    //fields autocomplete logic
    $('[name=Il_citizen]').on('change', function () {
        if (this.value == 'T') {

        $('[name=Insurance]').val('T').attr('disabled', 'disabled');
        }
        else {
            $('[name=Insurance]').removeAttr('disabled').val("");
        }
    });

    $('[name=Food_incloud]').on('change', function () {
        if (this.value == 'F') {

            $('[name=Food_pay]').val(0).attr('disabled', 'disabled');
        }
        else {
            $('[name=Food_pay]').removeAttr('disabled');
        }
        
    });

    $('[name=Com_app]').on('change', function () {
        if (this.value == 'F') {

            $('[name=Monthly_rent]').val(0).attr('disabled', 'disabled');
        }
        else {
            $('[name=Monthly_rent]').removeAttr('disabled');
        }

    });

//Picture or file upload
    $("#Pic").on("change", function () {
        pbLBL = $("#pLBL2")
        pbDiv = $("#progressBar")
        pbLBL.text('Uploading...');
        pbDiv.fadeIn(500);
        var files = $(this).get(0).files;
        if (files.length > 0) {


            var formData = new FormData();
            for (var i = 0; i < files.length; i++) {
                formData.append(files[i].name, files[i])
            }

            uploadFiles(formData, pbLBL, pbDiv, setEmpPic);
        }
    });
    $("#PicID").on("change", function () {
        pbLBL = $("#pbLBL")
        pbDiv = $("#progressBar1")
        pbLBL.text('Uploading...');
        pbDiv.fadeIn(500)
        var files = $(this).get(0).files;
        if (files.length > 0) {


            var formData = new FormData();
            for (var i = 0; i < files.length; i++) {
                formData.append(files[i].name, files[i])
            }
            EmployeeInfo.Doc_id = EmployeeInfo.pass + makeid();
            EmployeeInfo.Doctype_id = '2';
            uploadFiles(formData, pbLBL, pbDiv, setEmpID);

        }
    })
    $("#Picvisa").on("change", function () {
        pbLBL = $("#pVlBl")
        pbDiv = $("#progressBar4")
        pbLBL.text('Uploading...');
        pbDiv.fadeIn(500);
        var files = $(this).get(0).files;
        if (files.length > 0) {


            var formData = new FormData();
            for (var i = 0; i < files.length; i++) {
                formData.append(files[i].name, files[i])
            }
            
            uploadFiles(formData, pbLBL, pbDiv, setEmpVisa);
        }
    })
});
$("#picAuth").on("change", function () {
    pbLBL = $("#pLB3")
    pbDiv = $("#progressBar6")
    pbLBL.text('Uploading...');
    pbDiv.fadeIn(500);
    var files = $(this).get(0).files;
    if (files.length > 0) {


        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i])
        }

        uploadFiles(formData, pbLBL, pbDiv, setEmpAuth);
    }
});

//Make us random id
function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 5; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}

//Set each pic or document into variables
function setEmpVisa(results)
{
    EmpVisa.Img_url = results;
    EmpVisa.Doc_id = EmployeeInfo.pass + makeid();
    EmpVisa.Doctype_id = '1';
    EmpVisa.Employee_pass_id = EmployeeInfo.pass;
   
}

function setEmpAuth(results) {
    EmpAuth.Img_url = results;
    EmpAuth.Doc_id = EmployeeInfo.pass + makeid();
    EmpAuth.Doctype_id = '3';
    EmpAuth.Employee_pass_id = EmployeeInfo.pass;
}

function setEmpID(results) {
    EmpID.Img_url = results;
    EmpID.Doc_id = EmployeeInfo.pass + makeid();
    EmpID.Doctype_id = '2';
    EmpID.Employee_pass_id = EmployeeInfo.pass;
}

function setEmpPic(results) {
    EmpPic = results;
}

//Fix date to correct format
 function fixDate(date) {
    var date = new Date(parseInt(date.substr(6)));
    var month = date.getMonth() + 1;
    var day = date.getDate();
    if (month.toString().length < 2) { month = '0' + month; }
    if (day.toString().length < 2) { day = '0' + day; }
    return date.getFullYear() + "-" + month + "-" + day;

}

//populat form
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
        
        document.getElementById("kindoform").innerHTML = "עובד זה כבר פעיל במערכת, יש לבצע ציוות מחדש בלבד";
        $('.actions li a[href^="#next"]').trigger('click');
        
    }
    $('.selectize-select').selectize();

}

function renderBusinesses(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#businessSE').empty();
    dynamicLi = '<option value=""> בחר Select</option>';
    $('#businessSE').append(dynamicLi);
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
    dynamicLi = '<option value=""> בחר Select</option>';
    $('#DynamiCountryList').append(dynamicLi);
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
    dynamicLi = '<option value=""> בחר Select</option>';
    $('#DynamicCitiesList').append(dynamicLi);
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Id + '">' + row.Name + '</option>';
        $('#DynamicCitiesList').append(dynamicLi);
    });
}

function renderOccu(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#OccuSE').empty();
    dynamicLi = '<option value=""> בחר Select</option>';
    $('#OccuSE').append(dynamicLi);
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Occupation_code + '">' + row.Occupation_desc + '</option>';
        $('#OccuSE').append(dynamicLi);
    });
}

///////// INSERTS /////////
function insertEmp(array) {

    array.Bus_name = $('#businessSE option:selected').text();
    array.Occupation_desc = $('#OccuSE option:selected').text();
    array.Day_off_name = $('#day_off option:selected').text();
    array.Add_city_name = $('#DynamicCitiesList option:selected').text();


    if (isUpdate)
    {
    if (EmpPic == null) {
     array.Picture = resultsSave.Picture;   

    }
    else {
    array.Picture = EmpPic;
    }
    if (array.Business == resultsSave.Business) {
        array.updateBus = false;
        updateBus = false;
    }
    else {
        array.updateBus = true;
        updateBus = true;
        }
        swal({
            title: "האם אתה בטוח?",
            text: "אתה עומד לעדכן פרטי עובד.",
            type: "info",
            confirmButtonText: "כן",
            showCancelButton: "true",
            cancelButtonText: "בטל",
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        },

            function (isConfirm) {
                if (isConfirm) {

                    updateEmployee({ EmployeeInfo: JSON.stringify(array) }, InsertAllDocs)
                }
                else {
                    // swal("Cancelled", "Your imaginary file is safe :)", "error");
                }
            });
       
    }
    else {
        swal({
            title: "האם אתה בטוח?",
            text: "אתה עומד להוסיף עובד חדש.",
            type: "info",
            confirmButtonText: "כן",
            showCancelButton: "true",
            cancelButtonText: "בטל",
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        },

            function (isConfirm) {
                if (isConfirm) {
                    array.Picture = EmpPic;
                    insertEmployee({ EmployeeInfo: JSON.stringify(array) }, InsertAllDocs);

                }
                else {
    
                }
            });

    }

}

function InsertAllDocs(results) {
    if (!isUpdate) {
    EmpVisa.Ex_date = $('#date4_2').val();
        InsertDocs({ FileInfo: JSON.stringify(EmpVisa) });

           
    InsertDocs({ FileInfo: JSON.stringify(EmpID) });


        
    InsertDocs({ FileInfo: JSON.stringify(EmpAuth) });
           
    

    }
    if (!updateBus) {
        swal({
            title: "בוצע!",
            text: "כל הנתונים נשמרו בהצלחה",
            type: "success",
            confirmButtonText: "חזור למסך הבית",
        },

            function (isConfirm) {

                window.location = "Dash.html"

            })
    }
    else {
        sessionStorage.setItem('contract', results.d);
        setTimeout(function () {
        window.location = "ContractDisplay.html";
        }, 1000);

    }
}


