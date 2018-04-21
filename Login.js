var username = new Object();
$(document).ready(function () {
   
    if (localStorage.getItem("userName") != null) {
        $("#user-name").val(localStorage.getItem("userName"))
        $("#user-password").val(localStorage.getItem("userPass"))
    }
});
//localStorage to save user name (no expiration)
function movetopage() {
    username = $("#user-name").val();
    
    getUserById(username, ValidateUser);

}

function ValidateUser(results) {
    userPass = $("#user-password").val();
    rememberMe = $("#remember-me");
    results = $.parseJSON(results.d);
    if (username == results.U_name && userPass == results.U_pwd) {
        if (rememberMe.prop("checked")) {
            localStorage.setItem("userName", username)
            localStorage.setItem("userPass", userPass)
        }
        sessionStorage.setItem("userName", username)
        window.location = "Dash.html"
    }
    else {
        $("#wrongPH").html('*שם משתמש או סיסמה שגויים').css('color','red')

    }

}
