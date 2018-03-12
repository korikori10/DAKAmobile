function getEmployees(renderEmployees) {
    $.ajax({
        url: 'ajaxWebService.asmx/getEmployees',
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

function getEmployeesnobusiness(renderEmployeesnobusiness) {
    $.ajax({
        url: 'ajaxWebService.asmx/getEmployeesnobusiness',
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


function getEmployeeById(EmployeeInfo, renderEmployeeByID) {

    // serialize the object to JSON string
    var dataString = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: 'ajaxWebService.asmx/GetEmployeeById',
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

function getProduct(ProductInfo, renderFullProduct) {

    // serialize the object to JSON string
    var dataString = JSON.stringify(ProductInfo);

    $.ajax({
        url: 'ajaxWebService.asmx/getProduct',
        data: dataString,
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderFullProduct(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
    
}
