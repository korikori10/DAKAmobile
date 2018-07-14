var UserInfo = new Object();

//take local storage on the specific user
$(document).ready(function () {
    var username = sessionStorage.getItem('userName');

    getUserByUserName(username, renderUser);
    $('#password').click(function () {
        $('#resetPassModal').modal('toggle');
    });
    $('#resetPass').click(function () {
        var newpass = $('#newPass').val();
          

        if (newpass === $('#newPassCon').val()) {
            updatePass(newpass, username);
        }
            else {
            $('#error').html('*הסיסמאות לא תואמות').css("color", "red");
            }
    });
});


//put into labels the user data
function renderUser(results) {
    results = $.parseJSON(results.d);
    UserInfo.Uid = results.Uid;
    document.getElementById('name').innerHTML = results.Full_name;
    document.getElementById('mail').innerHTML = results.U_name;
    document.getElementById('phone').innerHTML = results.Phone;
    document.getElementById('usertype').innerHTML = results.U_type_name;
    document.getElementById('img_url').src = results.User_img;
}

//update user
$("[name='UserSave']").on('click', function () {
    swal({
        title: "האם אתה בטוח?",
        text: "אתה עומד לעדכן את פרטי המשתמש.",
        type: "info",
        confirmButtonText: "כן",
        showCancelButton: "true",
        cancelButtonText: "בטל",
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },

        function (isConfirm) {
            if (isConfirm) {
                UserInfo.Full_name=document.getElementById('name').innerHTML;
                UserInfo.U_name=document.getElementById('mail').innerHTML;
                UserInfo.Phone= document.getElementById('phone').innerHTML;
              
                    UpdateUsercall({ UserInfo: JSON.stringify(UserInfo) });
                }
        });
});