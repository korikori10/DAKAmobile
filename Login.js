//localStorage to save user name (no expiration)
function movetopage() {
    if (localStorage) {

        // Get the value of the name field.
        var username = document.getElementById('user-name').value;

        // Save the name in localStorage.
        localStorage.setItem('user-name', username);  
    }
window.location = "Dash.html"
}

 //var UserInfo = document.cookie;
 //       UserInfo = username;
