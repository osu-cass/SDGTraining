$(function() {
    var departmentModalPlaceholder = $('#departmentModalPlaceholder');

    // select buttons with a  data-toggle="add-modal"  attribute
    $('button[data-toggle="add-modal"]').click(function() {
        var url = $(this).data('url');

        // make an AJAX request to show the department modal
        $.get(url, (res) => {
            departmentModalPlaceholder.html(res);
            departmentModalPlaceholder.find('.modal').modal('show');
        });
    });

    // select buttons with a  data-save="add-modal"  attribute
    departmentModalPlaceholder.on('click', '[data-save="add-modal"]', function(event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var url = form.attr('action');
        var req = form.serialize();

        // make an AJAX request to add a new department
        $.post(url, req, (res) => {
            if (res.err) {
                if (!$('#invalidDepartmentFormMsg')[0]) {
                    $('#departmentModal').find('.modal-footer').prepend(
                        '<p id="invalidDepartmentFormMsg" class="text-danger">Invalid form</p>'
                    );
                }
            } else {
                departmentModalPlaceholder.find('.modal').modal('hide');

                // response is the whole  <html></html>  content, find the last  <tr>  tag
                var newRow = $('<div></div>').hide().html(res).find('tr').last();
                // bind a click event to the buttons on this row
                newRow.find('button[data-toggle="delete-modal"]').click(showDepartmentConfirmModal);
                // append to table - update view
                $('tbody').append(newRow);
            }
        });
    });

    // select buttons with a  data-toggle="delete-modal"  attribute
    $('button[data-toggle="delete-modal"]').click(showDepartmentConfirmModal);

    // select button with a  data-delete="delete-modal"  attribute
    departmentModalPlaceholder.on('click', '[data-delete="delete-modal"]', function(event) {
        event.preventDefault();

        var url = $(this).data('url');

        // make an AJAX request to delete this department
        $.post(url, null, (res) => {
            departmentModalPlaceholder.find('.modal').modal('hide');

            // Remove the  <tr>  with matching button action URL - update view
            $('tr button[data-url="' + url + '"]').parents('tr').remove();
        });
    })
});

function showDepartmentConfirmModal() {
    var url = $(this).data('url');

    // make an AJAX request to show the confirmation modal
    $.get(url, (res) => {
        $('#departmentModalPlaceholder').html(res);
        $('#departmentModalPlaceholder').find('.modal').modal('show');
    });
}