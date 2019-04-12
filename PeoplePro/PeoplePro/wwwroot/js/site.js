// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    //on click of create button, show modal
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });
    //on click of submit button, validate data is entered correctly

    //once validated ajax request

    //before request is sent, confirm request data
    //console.log(request)

    //if response is valid, print response
    //console.log(response)

    //handle error
});