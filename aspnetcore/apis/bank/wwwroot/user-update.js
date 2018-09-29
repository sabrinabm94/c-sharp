$(".register-update").submit(function (event) {
    event.preventDefault();
    //todo não precisar digitar novamente toda a informação para o update, somente o que quer alterar
    var name = $('#name').val();
    var username = $('#username').val();
    var password = $('#password').val();
    var address = $('#address').val();
    var email = $('#email').val();
    var phone = $('#phone').val();
    var accountId = $('#accountId').val();

    if (name != '', username != '', password != '', address != '', email != '', phone != '') {
        var user = {
            id: Cookies.get('userid'),
            username: username,
            name: name,
            password: password,
            address: address,
            email: email,
            phone: phone,
            accountId: accountId
        }

        $.ajax({
            url: 'http://localhost:54681/api/user/update',
            type: 'put',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                alert("Sucess!");

                $('#name').val("");
                $('#username').val("");
                $('#password').val("");
                $('#address').val("");
                $('#email').val("");
                $('#phone').val("");
                $('#accountId').val("");
            },
            error: function (error) {
                alert("Error: " + error);
            },
            data: JSON.stringify(user),
        });
    } else {
        alert("Fill all the fields!");
    }
});