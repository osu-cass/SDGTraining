//Add Data Function
function CreateAJAX() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        DepartmentId: $('#DepartmentId').val(),
        Name: $('#Name').val(),
    };
    $.ajax({
        url: "/Departments/CreateAJAX",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
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