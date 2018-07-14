﻿var local = true;
var WSUrl = 'ajaxWebService.asmx';
var UHUrl = 'UploadHandler.ashx';
if (!local) {
    WSUrl = 'https://proj.ruppin.ac.il/bgroup59/test2/tar2/ajaxWebService.asmx';
    UHUrl = 'https://proj.ruppin.ac.il/bgroup59/test2/tar2/UploadHandler.ashx'
}
$(document).ready(function () {
    $("#user_img").attr('src', sessionStorage.getItem("u_img"));
    $("#full_name").html(sessionStorage.getItem("FullName"));
});
// Get all Employees for Searchbox on dash
function getEmployees(renderEmployees) {
    $.ajax({
        url: WSUrl + '/getEmployees',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            
            renderEmployees(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
       
    });
    
}

//Get all businesses to Businusses table
function getBusinessesTable() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: WSUrl + "/getBusinessesTable",
        success: function (data) {
            var datatableVariable = $('#BusinessTable').DataTable({
                data: data,
                columns: [
                    {
                        'data': 'Bus_id', 'visible': false
                    },
                    { 'data': 'Bus_name' },
                    {
                        'data': 'Phone', 'render': function (phone) {
                            var phone = '<a href="tel:5555555">התקשר לחברה</a>';

                            return phone;
                        }
                    },
                ]
            });
        }
    });

}

//Get all cities for wizard
function getCities(renderCities) {
    $.ajax({
        url: WSUrl + '/getCities',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderCities(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }

    });

} 
//Get all Occupations for wizard
function getOccu(renderOccu) {
    $.ajax({
        url: WSUrl + '/getOccupation',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderOccu(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }

    });

} 

//Get all Countries for wizard
function getCountries(renderCountries) {
    $.ajax({
        url: WSUrl + '/getCountries',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderCountries(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }

    });

}

//select only the employees that today are not assigned to business from DB throw AJAX and WB
function getEmployeesnobusinesss(renderEmployeesnobusiness) {
    $.ajax({
        url: WSUrl + '/getEmployeesNoBusinessAmount',
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderEmployeesnobusiness(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }

    });

}

//Bring the right employee to wizard
function getEmployeeById(EmployeeInfo, renderEmployeeByID) {

    // serialize the object to JSON string
    var dataString = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: WSUrl + '/GetEmployeeById',
        data: dataString,
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderEmployeeByID(results);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

// Get all Employees for Employee no business table
function getEmployeesnobusiness() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: WSUrl + "/getEmployeesnobusiness",
        success: function (data) {
            var datatableVariable = $('#EmployeesTable').DataTable({
                data: data,
                columns: [
                    { 'data': 'Employee_pass_id' },
                    { 'data': 'Fname' },
                    { 'data': 'Lname' },
                    {
                        'data': "",
                        'defaultContent': '<button id="edit" name="edit" type="button" class="btn btn-info view" data-toggle="tooltip" data-original-title="צפה בעובד"><i class="icon-eye3"></i></button>',
                    }]
            });
        }
    });

}


function getUserById(username, userPass , ValidateUser) {

    // serialize the object to JSON string
    var dataString = '{"username":' + JSON.stringify(username) + ', "userPass":' + JSON.stringify(userPass) + '}';

    $.ajax({
        url: WSUrl + '/validateUserByUserName',
        data: dataString,
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            ValidateUser(results);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

//Get all Businesses for wizard
function getBusinesses(renderBusinesses) {
    $.ajax({
        url: WSUrl + '/getBusinesses',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        dataType: 'json',
        success: function (results) {
            renderBusinesses(results);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

//insert employee from wizard to DB using ajax and WS
function insertEmployee(EmployeeInfo, InsertAllDocs) {
    var emp = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: WSUrl + '/insertEmployee',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: emp,
        success: function (results) {
            InsertAllDocs(results);
            setTimeout(function () {
                swal("בוצע!", "כל הנתונים נשמרו בהצלחה", "success");
            }, 1000);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
            
        }
    });
}


function updatePass(newpass, username) {
    userPass = JSON.stringify({ userName: username, pass: newpass })
    $.ajax({
        url: WSUrl + '/updateUserPass',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: userPass,
        success: function () {
            setTimeout(function () {
                swal("בוצע!", "כל הנתונים נשמרו בהצלחה", "success");
            }, 1000);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);

        }
    });
}


function InsertSignature(svg, file, insertContract) {
    var data = JSON.stringify({ svgString: svg, fileString: file })

    $.ajax({
        url: WSUrl + '/insertSignature',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        dataType: "json",
        data: data,
        success: function (results) {
            insertContract(results)
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);

        }
    });
}

//update employee from wizard to DB using ajax and WS
function updateEmployee(EmployeeInfo, InsertAllDocs) {
    var emp = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: WSUrl + '/updateEmployee',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: emp,
        success: function (results) {
            InsertAllDocs(results);
                
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

//take user deatails from DB using ajax WS
function getUserByUserName(username, renderUser) {
    var dataString = '{"username":' + JSON.stringify(username) + '}';
    $.ajax({
        url: WSUrl + '/getUserByUserName',
        data: dataString,
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderUser(results);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

//Upload files from wizard
function uploadFiles(formData, pbLBL, pbDiv,setEmpPic) {
    //pbLBL = $("#pbLBL")
    //pbDiv = $("#progressBar")
    $.ajax({
        url: UHUrl,
        method: "POST",
        data: formData,
        contentType: false,
        processData: false,
        dataType: 'json',
        success: function (results) {
            setEmpFile(results);
            pbLBL.text('Complete');
            pbDiv.fadeOut(2000);
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
        
    });
   
}

////Upload files from wizard
//function uploadFiles(formData, setEmpVisa) {
//    pbLBL = $("#pVlBl")
//    pbDiv = $("#progressBar4")
//    $.ajax({
//        url: UHUrl,
//        method: "POST",
//        data: formData,
//        contentType: false,
//        processData: false,
//        dataType: 'json',
//        success: function (results) {
//            setEmpVisa(results);
//            pbLBL.text('Complete');
//            pbDiv.fadeOut(2000);
//        },
//        error: function (xhr, status, error) {
//            var err = eval("(" + xhr.responseText + ")");
//            alert(err.Message);
//        }

//    });

//}
////Upload files from wizard
//function uploadFiles(formData, setEmpID) {
//    pbLBL = $("#pbLBL")
//    pbDiv = $("#progressBar1")
//    $.ajax({
//        url: UHUrl,
//        method: "POST",
//        data: formData,
//        contentType: false,
//        processData: false,
//        dataType: 'json',
//        success: function (results) {
//            setEmpID(results);
//            pbLBL.text('Complete');
//            pbDiv.fadeOut(2000);
//        },
//        error: function (xhr, status, error) {
//            var err = eval("(" + xhr.responseText + ")");
//            alert(err.Message);
//        }

//    });

//}

////Upload files from wizard
//function uploadFiles(formData, setEmpAuth) {
//    pbLBL = $("#pLB2")
//    pbDiv = $("#progressBar2")
//    $.ajax({
//        url: UHUrl,
//        method: "POST",
//        data: formData,
//        contentType: false,
//        processData: false,
//        dataType: 'json',
//        success: function (results) {
//            setEmpAuth(results);
//            pbLBL.text('Complete');
//            pbDiv.fadeOut(2000);
//        },
//        error: function (xhr, status, error) {
//            var err = eval("(" + xhr.responseText + ")");
//            alert(err.Message);
//        }

//    });

//}

//Insert docs
function InsertConts(FileInfo, i, finished) {

    // serialize the object to JSON string
    var file = JSON.stringify(FileInfo);
    $.ajax({
        url: WSUrl + '/InsertDoc',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: file,
        success: function (results) {
            finished(i)
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

function InsertDocs(FileInfo) {

    // serialize the object to JSON string
    var file = JSON.stringify(FileInfo);
    $.ajax({
        url: WSUrl + '/InsertDoc',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: file,
        success: function (results) {
          
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}
