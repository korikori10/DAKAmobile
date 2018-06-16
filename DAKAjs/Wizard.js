selectedCity = new Object();
EmployeeInfo = new Object();
resultsSave = new Object();
isUpdate = new Object();
var EmpPic = null;
var EmpFile = null;

$(document).ready(function () {
    getCities(renderCities);
    getCountries(renderCountries);
    getBusinesses(renderBusinesses);
    getOccu(renderOccu);
//Picture or file upload
    $("#Pic").on("change", function () {
        pbLBL = $("#pLBL2")
        pbDiv = $("#progressBar")
        pbLBL.text('Uploading...');
        pbDiv.fadeIn(500);
        var files = $(this).get(0).files;
        if (files.length>0) {


        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i])
        }
        EmployeeInfo.Doc_id = EmployeeInfo.pass + makeid();
        EmployeeInfo.Doctype_id = '3';
        uploadFiles(formData, setEmpPic);
}
    })
    $("#Pic1").on("change", function () {
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
            uploadFiles(formData, setEmpFile);

        }
    })
    $("#Pic2").on("change", function () {
        pbLBL = $("#pLB2")
        pbDiv = $("#progressBar2")
        pbLBL.text('Uploading...');
        pbDiv.fadeIn(500)
        var files = $(this).get(0).files;
        if (files.length > 0) {

            var formData = new FormData();
            for (var i = 0; i < files.length; i++) {
                formData.append(files[i].name, files[i])
            }
            EmployeeInfo.Doc_id = EmployeeInfo.pass + makeid();
            EmployeeInfo.Doctype_id = '4';
            EmployeeInfo.Employee_pass_id = EmployeeInfo.pass
            uploadFiles(formData, setEmpFile);

        }
    })

});

function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 5; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}

function setEmpFile(results)
{
    EmpFile = results;
}

function setEmpPic(results) {
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
    });
}


function renderOccu(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#OccuSE').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Occupation_code + '">' + row.Occupation_desc + '</option>';
        $('#OccuSE').append(dynamicLi);
    });
}

function insertEmp(array) {

    array.Bus_name = $('#businessSE option:selected').text();
    array.Occupation_desc = $('#OccuSE option:selected').text();
    array.Day_off_name = $('#day_off option:selected').text();


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
    }
    else {
        array.updateBus = true;
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

                    updateEmployee({ EmployeeInfo: JSON.stringify(array) })
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
                    InsertDocs({ EmployeeInfo: JSON.stringify(EmployeeInfo) });
                    insertEmployee({ EmployeeInfo: JSON.stringify(array) });
                }
                else {
                    // swal("Cancelled", "Your imaginary file is safe :)", "error");
                }
            });

    }

}


