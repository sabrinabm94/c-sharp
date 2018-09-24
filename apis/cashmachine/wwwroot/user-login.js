$(".register-login").submit(function (event) {
    event.preventDefault();

    var username = $('#username').val();
    var password = $('#password').val();

    if (username != '', password != '') {
        var user = {
            username: username,
            password: password,
        }

        $.ajax({
            url: 'https://localhost:44323/api/user/login',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (data == true) {
                    alert("Sucess!");

                    $.ajax({
                        url: "https://localhost:44323/api/user/list/" + username,
                        context: document.body,
                        success: function (results) {
                            Cookies.set('userid', results.id, {expires: 1});
                            Cookies.set('logged', true, {expires: 1});
                            window.location.href = "user-info.html";
                        },
                        statusCode: {
                            404: function () {
                                alert('Api off');
                            },

                            400: function () {
                                alert('Invalid data, try again');
                            }
                        }
                    });
                } else {
                    alert("Invalid user or password!");
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