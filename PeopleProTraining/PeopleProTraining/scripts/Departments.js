//Add Data Function
function CreateAJAX() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var form = $('#__AjaxAntiForgeryForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var empObj = {
        __RequestVerificationToken: token,
        DepartmentId: $('#DepartmentId').val(),
        Name: $('#Name').val(),
    };
    console.log(form);
    console.log(token);
    $.ajax({
        url: "/Departments/CreateAJAX",
        data: empObj,
        type: "POST",
        dataType: "json",
        success: function (result) {
            window.location.href = '/Departments'
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Valdidation using jquery - TODO
function validate() {
    var isValid = true;
    return isValid;
}