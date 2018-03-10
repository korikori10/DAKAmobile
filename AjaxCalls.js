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


function getEmployeeById(EmployeeInfo, renderFullEmployee) {

    // serialize the object to JSON string
    var dataString = JSON.stringify(EmployeeInfo);

    $.ajax({
        url: 'ajaxWebService.asmx/getEmployeeById',
        data: dataString,
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            renderFullEmployee(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
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
