$('.register-account').hide;

$.ajax({
    url: "http://localhost:54681/api/user/list/" + Cookies.get('userid'),
    context: document.body,
    success: function (results) {
        $('#id').text(results.id);
        $('#name').text(results.name);
        $('#username').text(results.username);
        $('#password').text(results.password);
        $('#email').text(results.email);
        $('#phone').text(results.phone);
        $('#address').text(results.address);
        $('#accountId').text(results.accountId);

        if (results.accountId !== '' || results.accountId !== null) {
            $('.register-account').hide;
        } else {
            $('.register-account').show;
        }

        $.ajax({
            url: "http://localhost:54681/api/account/list/" + results.accountId,
            context: document.body,
            success: function (results) {
                $('#account-id').text(results.id);
                $('#type').text(results.type);
                $('#balance').text(results.balance);

                account = {
                    id: results.id,
                    type: results.type,
                    balance: results.balance
                }
            },
            statusCode: {
                404: function () {
                    alert('Account: Api off');
                },

                400: function () {
                    alert('Invalid data, try again');
                }
            }
        });
    },
    statusCode: {
        404: function () {
            alert('User: Api off');
        },

        400: function () {
            alert('Invalid data, try again');
        }
    }
});

$("#delete-user").click(function () {
    var user = {
        id: $('#id').text(),
        name: $('#name').text(),
        username: $('#username').text(),
        password: $('#password').text(),
        address: $('#address').text(),
        email: $('#email').text(),
        phone: $('#phone').text(),
        accountId: $('#accountId').text(),
    }

    var account = {
        id: $('#account-id').text(),
        type: $('#type').text(),
        balance: $('#balance').text()
    }

   /*
    $.ajax({
        url: 'http://localhost:54681/api/user/delete/',
        type: 'DELETE',
        data: user, 
        contentType: 'application/json',                 
        success: function (result) {
            alert('Sucess!');

            $.ajax({
                url: 'http://localhost:54681/api/account/delete/',
                type: 'DELETE',
                data: account,
                contentType: 'application/json',
                success: function (result) {
                    window.location.href = "index.html";
                },
                error: function (result) {
                },
                statusCode: {
                    404: function () {
                        alert('Account: Api off');
                    },

                    400: function () {
                        alert('Invalid data, try again');
                    }
                }
            });
        },
        error: function (result) {
        },
        statusCode: {
            404: function () {
                alert('Account: Api off');
            },

            400: function () {
                alert('Invalid data, try again');
            }
        }
    });*/

    $.ajax({
        url: "http://localhost:54681/api/user/delete/" + user.id,
        type: 'DELETE',
        context: document.body,
        success: function (results) {
            alert('Sucess!');
            $.ajax({
                url: "http://localhost:54681/api/account/delete/" + user.accountId,
                type: 'DELETE',
                context: document.body,
                success: function (results) {
                    window.location.href = "index.html";

                    account = {
                        id: results.id,
                        type: results.type,
                        balance: results.balance
                    }
                },
                statusCode: {
                    404: function () {
                        alert('Account: Api off');
                    },

                    400: function () {
                        alert('Invalid data, try again');
                    }
                }
            });
        },
        statusCode: {
            404: function () {
                alert('User: Api off');
            },

            400: function () {
                alert('Invalid data, try again');
            }
        }
    });
});