//take local storage on the specific user 
$(document).ready(function () {
    var username = sessionStorage.getItem('userName');

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

//make User labels editable
//function editable() {
$('#edit').click(function () {
    document.getElementById("name").style.contenteditable = true;
    document.getElementById("mail").style.contenteditable = true;
    document.getElementById("phone").style.contenteditable = true;
    document.getElementById("usertype").style.contenteditable = true;
    document.getElementById('save').innerHTML = "<button type='button'><i class='icon- save'></i> שמור</button>";
    // document.getElementById('save').hidden = "false";
});


//}