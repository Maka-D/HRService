$(document).ready(function () {
    $('#RegisterBtn').click(function () {
        var input = this;
        setTimeout(function () {
            input.disabled = true;
        }, 300);
        setTimeout(function () {
            input.disabled = false;
        }, 3000);
        
    });
    $('#GoToRegistrationBtn').click(function () {
        $('#RegistrationDiv').slideDown(1000);
        $('#SignInDiv').slideUp(1000);
        $('#tempData').hide();
    });
    $('#GoToLogInBtn').click(function () {
        $('#SignInDiv').slideDown(1000);
        $('#RegistrationDiv').slideUp(1000);
        $('#tempData').hide();
    });

    $('#deleteEmployeeBtn').click(function () {
        var Id = $('#deleteEmployeeBtn').val().trim();
        if (Id != null) {
          
            $.ajax({
                url: "/User/DeleteEmployee",
                method: "delete",
                data: { "Id": Id },
                success: function (response) {
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    } else {
                        alert("Some error occiured!");
                    }
                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }
    });
    
});