// Despues de document.ready
$(function () {
    let placeholderElement = $('#modal-placeholder');
    // all buttons with data-toggle equal to ajax-modal
    $('button[data-toggle="ajax-modal"]').click(function () {
        let url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        let form = $(this).parents('.modal').find('form');
        let actionUrl = form.attr('action');
        let dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            let newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

            form = newBody.find('form');
            $.validator.unobtrusive.parse(form);

            if (form.valid()) {
                placeholderElement.find('.modal').modal('hide');
            }
        });
    });
});

