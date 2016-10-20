function createDialog(title, content) {
    $.alert({
        title: title,
        content: content,
        confirm: function () {
            $.alert('Confirmed!');
        }
    });
}

$(document).on('click','.js-btn-add-person',function() {
    createDialog('Prueba', '<div class=\"btn btn-default\">Hola Mundo</div>');
});