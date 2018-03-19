selectedCity = new Object();
EmployeeInfo = new Object();

$(document).on('pagebeforeshow', '#wizard', function () {
    getCities(renderCities);
    getCountries(renderCountries);
});
$(document).ready(function () {
    $('.selectize-select').selectize;
})

function renderCities(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#DynamicCitiesList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Id + '">' + row.Name + '</option>'
        $('#DynamicCitiesList').append(dynamicLi);
      //  $('#DynamicCitiesList').listview('refresh');
    });
}

function renderCountries(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#DynamiCountryList').empty();
    $.each(results, function (i, row) {
        dynamicLi = '<option value="' + row.Id + '">' + row.Name + '</option>'
        $('#DynamiCountryList').append(dynamicLi);
      //  $('#DynamiCountryList').listview('refresh');
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


    insertEmployee({ EmployeeInfo: JSON.stringify(array) });
    }
