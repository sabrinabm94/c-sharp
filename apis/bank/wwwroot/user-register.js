$(".register-user").submit(function(event) {
    event.preventDefault();

    var name = $('#name').val();
    var username = $('#username').val();
    var password = $('#password').val();
    var address = $('#address').val();
    var email = $('#email').val();
    var phone = $('#phone').val();
    var accountId = $('#accountId').val();

    if (name != '', username != '', password != '', address != '', email != '', phone != '', accountId != '') {
        var user = {
            name: name,
            username: username,
            password: password,
            address: address,
            email: email,
            phone: phone,
            accountId: accountId
        }

        $.ajax({
            url: 'http://localhost:54681/api/user/register',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (data != null) {
                    alert("Sucess!");

                    $('#name').val("");
                    $('#username').val("");
                    $('#password').val("");
                    $('#address').val("");
                    $('#email').val("");
                    $('#phone').val("");
                    $('#accountId').val("");
                } else {
                    alert("Already registred!");
                }
            },
            error: function (error) {
                console.log(error);
                alert("Error: " + error);
            },
            data: JSON.stringify(user),
        });
    } else {
        alert("Fill all the fields!");
    }
});