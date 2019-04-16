// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    //on click of create button, show modal
    var placeholderElement = $('#modal-placeholder')
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            //data in this scope is the html of the modal
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });

        placeholderElement.on('click', '[data-dismiss="ajax-modal"]', function (event) {
            placeholderElement.find('.modal').modal('hide');
        });

        placeholderElement.on('click', '[data-save="modal"]', function (event) {
            event.preventDefault();

            var form = $(this).parents('.modal').find('form');
            var actionUrl = form.attr('action');
            var dataToSend = new FormData(form.get(0));

            $.ajax({ url: actionUrl, method: 'post', data: dataToSend, processData: false, contentType: false }).done(function (data) {
                var newBody = $('.modal-body', data);
                placeholderElement.find('.modal-body').replaceWith(newBody);
                // find IsValid input field and check it's value
                // if it's valid then hide modal window
                var isValid = newBody.find('[name="IsValid"]').val() == 'True';

                if (isValid) {
                    var tableElement = $('#table');
                    var tableUrl = tableElement.data('url');
                    console.log(tableElement)
                    $.get(tableUrl).done(function (table) {
                        tableElement.replaceWith(table);
                    });

                    placeholderElement.find('.modal').modal('hide');
                    //location.reload()
                }
            });
        });
        
    });
});