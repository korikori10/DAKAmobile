var local = true;
var WSUrl = 'ajaxWebService.asmx';
if (!local) {
    WSUrl = 'http://proj.ruppin.ac.il/bgroup59/test2/tar2/ajaxWebService.asmx';
}

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
        url: "ajaxWebService.asmx/getBusinessesTable",
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
//Get all cities for wizard
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
        url: "ajaxWebService.asmx/getEmployeesnobusiness",
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


function getUserById(username, ValidateUser) {

    // serialize the object to JSON string
    var dataString = '{"username":' + JSON.stringify(username) + '}';

    $.ajax({
        url: WSUrl + '/getUserByUserName',
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
function insertEmployee(EmployeeInfo) {
    var emp = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: WSUrl + '/insertEmployee',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: emp,
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

//update employee from wizard to DB using ajax and WS
function updateEmployee(EmployeeInfo) {
    var emp = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: WSUrl + '/updateEmployee',
        type: 'POST',
        contentType: 'application/json; charset = utf-8',
        data: emp,
        success: function () {
        //    alert(EmployeeInfo);

            //var files = $("#Pic")[0].files;
            //    if (files.length > 0) {
            //        var formData = FormData();
            //        for (var i = 0; i < files.length; i++) {
            //            formData.append(files[i].name, files[i])
            //        }

            //        uploadFiles(formData);
            //    }
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
function uploadFiles(formData, setEmpFile) {
    pbLBL = $("#pbLBL")
    pbDiv = $("#progressBar")
    $.ajax({
        url: 'UploadHandler.ashx',
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
