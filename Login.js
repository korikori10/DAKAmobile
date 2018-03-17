//window.onload = function () {

//    // Check for LocalStorage support.


//}

function movetopage() {
    if (localStorage) {

        // Add an event listener for form submissions
        //   document.getElementById('loginform').addEventListener('button', function () {
        // Get the value of the name field.
        var username = document.getElementById('user-name').value;

        // Save the name in localStorage.
        localStorage.setItem('user-name', username);
        //  });

    }
window.location = "MobileDAKA.html"
}
