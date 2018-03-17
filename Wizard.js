selectedCity = new Object();

$(document).on('pagebeforeshow', '#wizard', function () {
    getCities(renderCities);
    getCountries(renderCountries);
});

function renderCities(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#DynamicCitiesList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="#" data-id="' + row.Name + '">  <h3>' + row.Name + '</h3></a></li>'
        $('#DynamicCitiesList').append(dynamicLi);
        $('#DynamicCitiesList').listview('refresh');
    });
}

function renderCountries(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#DynamiCountryList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="#" data-id="' + row.Name + '">  <h3>' + row.Name + '</h3></a></li>'
        $('#DynamiCountryList').append(dynamicLi);
        $('#DynamiCountryList').listview('refresh');
    });
}

$(document).on('vclick', '#DynamicCitiesList li a', function () {
    selectedCity.Name = $(this).attr('data-id');
    $(this).closest('[data-role=listview]').prev('form').find('input').val(selectedCity.Name);
    $(this).closest('[data-role=listview]').prev('form').find('input').attr("name", "city");
    $(this).closest('[data-role=listview]').children().addClass('ui-screen-hidden');


});

$(document).on('vclick', '#DynamiCountryList li a', function () {
    selectedCity.Name = $(this).attr('data-id');
    $(this).closest('[data-role=listview]').prev('form').find('input').val(selectedCity.Name);
    $(this).closest('[data-role=listview]').prev('form').find('input').attr("name","country");
    $(this).closest('[data-role=listview]').children().addClass('ui-screen-hidden');


});

function insertEmp(array) {
       
    
    var EmployeeInfo = array;


        insertEmployee(EmployeeInfo)
    }
