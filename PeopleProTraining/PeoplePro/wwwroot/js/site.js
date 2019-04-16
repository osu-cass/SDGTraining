$(function () {
    var departmentModalPlaceholder = $('#departmentModalPlaceholder');

    // select buttons with a  data-toggle="ajax-modal"  attribute
    $('button[data-toggle="ajax-modal"]').click(function () {
        var url = $(this).data('url');

        // make an AJAX request to show the department modal
        $.get(url, (res) => {
            departmentModalPlaceholder.html(res);
            departmentModalPlaceholder.find('.modal').modal('show');
        });
    });

    // select buttons with a  data-save="ajax-modal"  attribute
    departmentModalPlaceholder.on('click', '[data-save="ajax-modal"]', function (event) {
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
                // append to table
                $('tbody').append(newRow);
            }
        });
    });
});