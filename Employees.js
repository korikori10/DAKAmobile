CategoryInfo = new Object();
EmployeeInfo = new Object();

$(document).on('pagebeforeshow', '#home', function () {
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
    }

   
    )
}

$(document).on('vclick', '#DynamicEmployeesList li a', function () {
    EmployeeInfo.id = $(this).attr('data-id');
  //  renderFullEmployee(EmployeeInfo, eresults);
    $.mobile.changePage("#employee", {
        transition: "slide", changeHash: false

    });

});

//$(document).on('vclick', '#addempbtn button', function () {
  
//    $.mobile.changePage("#wizard", {
//        transition: "slide", changeHash: false

//    });

//});

//function renderProducts(results) {
//    //this is the callBackFunc 
//    results = $.parseJSON(results.d);
//    $('#DynamicListproducts').empty();
//    $.each(results, function (i, row) {
//      // console.log(JSON.stringify(row));
//       if (row.ImagePath == null) { imageFullPath = "/images/no-img.jpg" }
//            else { imageFullPath = row.ImagePath }
//       dynamicList = '<li> <a href="" data-id="' + row.Id + '"> <img src="' + imageFullPath + '"/>  <h3>' + row.Title + '</h3><p>Price: ' + row.Price + '</br>Inventory: ' + row.Inventory + '</p></a></li>'
//       $('#DynamicListproducts').append(dynamicList);
//        $('#DynamicListproducts').listview('refresh');
//    })
//}


//$(document).on('vclick', '#DynamicListproducts li a', function () {
//    ProductInfo.id = $(this).attr('data-id');
//    getProduct(ProductInfo, renderFullProduct);
//    $.mobile.changePage("#product", {
//        transition: "slide", changeHash: false

//    });

//});

function renderFullEmployee(results) {
    //this is the callBackFunc 
    // results = $.parseJSON(results.d);
    $.each(eresults, function (i, row) {
        if (EmployeeInfo.id == row.Emloyee_pass_id) {
            $('#employeePage').empty();

        }
        //$('#employeePage').append(dynamicLi);
    });

        //var attributes = "";
        //$('#productPage').empty();
        //    if (results.ImagePath == null) { imageFullPath = "/images/no-img.jpg" }
        //    else { imageFullPath = results.ImagePath }
        //    pimginv = "<div class='pro'><h3>" + results.Title + "</h3></br><img src='" + imageFullPath + "'/> </br><p>Inventory: " + results.Inventory + "</p></div><div  id='productPageList'  data-role='collapsible-set'>"
        //    $('#productPage').append(pimginv);
        //        if (results.Attributes['אספקה מהירה'] == null) {
        //            attributes += "<h4>No attributes for this product!</h4>"
        //        }
        //        else {
        //    $.each(results.Attributes, function (i, row) {
        //            attributes += "<div class='col' data-role='collapsible'><h3>" + i + "</h3>" + "<p>" + row + "</p></div>"
        //    });

        //        }
        //    $('#productPageList').append(attributes);
        //    $('div[data-role="collapsible"]').collapsible();



    }





