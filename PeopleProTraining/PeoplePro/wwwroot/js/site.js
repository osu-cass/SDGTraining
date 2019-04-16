// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

})

function getDepartments() {
    $.ajax({
        type: 'GET',
        url: 'Departments/AjaxGet',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: (res) => {
            console.log('res =', res);
        },
        failure: (xhr, status, err) => {
            alert('HTTP Status: ' + xhr.status + '; Error Text: ' + xhr.responseText);
        }
    });
}

function createDepartment() {
    // show modal
    $('#departmentModal').modal('show');

    // reset form validation
    var form = $('#departmentForm')[0];
    form.classList.remove('was-validated');
    form.reset();

    // validate on submit
    $('#departmentModalAcceptBtn').click((event) => {
        if (form.checkValidity() === false) {
            if (!$('#invalidDepartmentFormMsg')[0]) {
                $('#departmentModal').find('.modal-footer').prepend(
                    '<p id="invalidDepartmentFormMsg" style="color: red">Invalid form</p>'
                );
            }
            event.preventDefault();
            event.stopPropagation();
        } else {
            $('#invalidDepartmentFormMsg').remove();
            // close modal if valid form
            $('#departmentModal').modal('hide');
            // make actual changes to models
            $.ajax({
                type: 'POST',
                url: 'Departments/AjaxCreate',
                data: objectifyForm(form),
                beforeSend: () => {
                    console.log('About to send:', objectifyForm(form));
                },
                success: (res) => {
                    console.log('res =', res);
                    $('tbody').append('<tr>' +
                        '<td>' + res.name + '</td>' +
                        '<td>' + res.buildingName + '</td>' +
                        '<td></td>' +
                        '<td>' + 
                            '<a asp-action="Edit" asp-route-id="' + res.id + '">Edit</a> | ' +
                            '<a asp-action="Details" asp-route-id="' + res.id + '">Details</a> | ' + 
                            '<a asp-action="Delete" asp-route-id="' + res.id + '">Delete</a>' +
                        '</td>' +
                    '</tr>');
                },
                failure: (xhr, status, err) => {
                    alert('HTTP Status: ' + xhr.status + '; Error Text: ' + xhr.responseText);
                }
            });
        }
        form.classList.add('was-validated');
    });
}

function objectifyForm(form) {
    var retObj = {};

    $(form).serializeArray().forEach((field) => {
        retObj[field.name] = field.value;
    });

    return retObj;
}