$.ajax({
    url: "https://localhost:44323/api/user/list/" + Cookies.get('userid'),
    context: document.body,
    success: function (results) {
        $('#id').text(results.id);
        $('#name').text(results.name);
        $('#username').text(results.username);
        $('#email').text(results.email);
        $('#phone').text(results.phone);
        $('#address').text(results.address);
        $('#accountId').text(results.accountId);

        $.ajax({
            url: "https://localhost:44323/api/account/list/" + results.accountId,
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

    $.ajax({
        url: 'https://localhost:44323/api/user/delete/',
        type: 'DELETE',
        data: { user: user }, 
        contentType: 'application/json',  
        dataType: 'text',                
        success: function (result) {
            alert('Sucess!');

            $("#delete-user").click(function () {
                $.ajax({
                    url: 'https://localhost:44323/api/account/delete/',
                    type: 'DELETE',
                    data: { account: account },
                    contentType: 'application/json',
                    dataType: 'text',
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
    });
});