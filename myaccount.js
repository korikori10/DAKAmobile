
//function init() {
//    var username = localStorage.getItem('user-name');
//    getUserByUserName(username, renderUser);
//}
//$(document).on('pagebeforeshow', '#account', function () {
//    var username = localStorage.getItem('user-name');
//    getUserByUserName(username, renderUser);
//});

function renderUser(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#user-profile-cards').empty();
   // $.each(results, function (i, row) {
    document.getElementById('name').innerHTML = results.Full_name;
    document.getElementById('mail').innerHTML = results.U_name;
    document.getElementById('phone').innerHTML = results.Phone;
    document.getElementById('usertype').innerHTML = results.U_type_code;


   // })
}