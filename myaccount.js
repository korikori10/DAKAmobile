//take local storage on the specific user 
$(document).on('pageinit', '#account', function () {
    var username = localStorage.getItem('user-name');
    getUserByUserName(username, renderUser);
});

//put into labels the user data
function renderUser(results) {
    results = $.parseJSON(results.d);
    document.getElementById('name').innerHTML = results.Full_name;
    document.getElementById('mail').innerHTML = results.U_name;
    document.getElementById('phone').innerHTML = results.Phone;
    document.getElementById('usertype').innerHTML = results.U_type_name;
}