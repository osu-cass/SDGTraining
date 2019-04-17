$(function() {
    var departmentModalPlaceholder = $('#departmentModalPlaceholder');

    /***************************************
     * Add Departments
     ***************************************/

    // select buttons with a  data-toggle="add-modal"  attribute
    $('button[data-toggle="add-modal"]').click(function() {
        showDepartmentAddEditModal($(this), departmentModalPlaceholder);
    });

    // select buttons with a  data-save="Add-modal"  attribute
    departmentModalPlaceholder.on('click', '[data-save="Add-modal"]', function(event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var url = form.attr('action');
        var req = form.serialize();

        // make an AJAX request to add a new department
        $.post(url, req, (res) => {
            if (!res || res.err) {
                showInvalidFormMessage(form);
            } else {
                departmentModalPlaceholder.find('.modal').modal('hide');

                // append the new row to table
                var newRow = $.parseHTML(res);
                $('tbody').append(newRow);

                // add listener for Edit button of the new row
                $(newRow).find('button[data-toggle="edit-modal"]').click(function() {
                    showDepartmentAddEditModal($(this), departmentModalPlaceholder);
                });
                // add listener for Delete button of the new row
                $(newRow).find('button[data-toggle="delete-modal"]').click(function() {
                    showDepartmentConfirmModal($(this), departmentModalPlaceholder);
                });
            }
        });
    });

    /***************************************
     * Edit Departments
     ***************************************/

    // select button with a  data-toggle="edit-modal"  attribute
    $('button[data-toggle="edit-modal"]').click(function() {
        showDepartmentAddEditModal($(this), departmentModalPlaceholder);
    });

    // select button with a  data-save="Edit-modal"  attribute
    departmentModalPlaceholder.on('click', '[data-save="Edit-modal"]', function(event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var url = form.attr('action');
        var req = form.serialize();

        // make an AJAX request to add a new department
        $.post(url, req, (res) => {
            if (!res || res.err) {
                showInvalidFormMessage(form);
            } else {
                departmentModalPlaceholder.find('.modal').modal('hide');

                // update the target row
                var targetRow = $('tr button[data-url="' + url + '"]').parents('tr');
                res.replace('<tr>', '');
                res.replace('</tr>', '');
                targetRow.html(res);

                // add listener for Edit button of the new row
                $(targetRow).find('button[data-toggle="edit-modal"]').click(function() {
                    showDepartmentAddEditModal($(this), departmentModalPlaceholder);
                });
                // add listener for Delete button of the new row
                $(targetRow).find('button[data-toggle="delete-modal"]').click(function() {
                    showDepartmentConfirmModal($(this), departmentModalPlaceholder);
                });
            }
        });
    });

    /***************************************
     * Delete Departments
     ***************************************/

    // select buttons with a  data-toggle="delete-modal"  attribute
    $('button[data-toggle="delete-modal"]').click(function() {
        showDepartmentConfirmModal($(this), departmentModalPlaceholder);
    });

    // select button with a  data-delete="delete-modal"  attribute
    departmentModalPlaceholder.on('click', '[data-delete="delete-modal"]', function(event) {
        event.preventDefault();

        var url = $(this).data('url');

        // make an AJAX request to delete this department
        $.post(url, null, () => {
            departmentModalPlaceholder.find('.modal').modal('hide');

            // Remove the  <tr>  with matching button action URL - update view
            $('tr button[data-url="' + url + '"]').parents('tr').remove();
        });
    })
});

function showDepartmentAddEditModal(target, departmentModalPlaceholder) {
    var url = target.data('url');

    // make an AJAX request to show the add/edit modal
    $.get(url, (res) => {
        departmentModalPlaceholder.html(res);
        departmentModalPlaceholder.find('.modal').modal('show');
    });
}

function showDepartmentConfirmModal(target, departmentModalPlaceholder) {
    var url = target.data('url');

    // make an AJAX request to show the confirmation modal
    $.get(url, (res) => {
        departmentModalPlaceholder.html(res);
        departmentModalPlaceholder.find('.modal').modal('show');
    });
}

function showInvalidFormMessage(form) {
    if (!$('#invalidFormMessage')[0]) {
        $(form).parents('.modal').find('.modal-footer').prepend(
            '<p id="invalidFormMessage" class="text-danger">Invalid form</p>'
        );
    }
}