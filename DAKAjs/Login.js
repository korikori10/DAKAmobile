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
    userPass = $("#user-password").val();
    getUserById(username, userPass, ValidateUser);

}

function ValidateUser(results) {
   
    rememberMe = $("#remember-me");
    results = $.parseJSON(results.d);
    if (results) {
        if (rememberMe.prop("checked")) {
            localStorage.setItem("userName", username)
            localStorage.setItem("userPass", userPass)
        }

        getUserByUserName(username, renderUser);
        function renderUser(results) {
            results = $.parseJSON(results.d);
            sessionStorage.setItem("u_img", results.User_img);
            sessionStorage.setItem("FullName", results.Full_name);
            sessionStorage.setItem("userName", username);
            window.location = "Dash.html";
        }
    }
    else {
        $("#wrongPH").html('*שם משתמש או סיסמה שגויים').css('color','red')

    }

}
