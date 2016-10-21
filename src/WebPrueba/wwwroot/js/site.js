function createDialog(title, content) {
    $.confirm({
        title: title,
        content: content,
        confirmButton: 'Aceptar',
        cancalButton: 'Cancelar'
    });
}

$(document).ready(function () {
    $('#personsTable').DataTable();
});

$(document).on('click', '.js-delete', function () {
    $.confirm({
        title: 'Eliminar Registro',
        content: '¿Desea eliminar esta persona?',
        confirmButton: 'Aceptar',
        cancelButton: 'Cancelar',
        confirm:function() {
            $.ajax({
                url: location.origin + '/Persons/Delete/',
                data : {id : $(this).data('id')},
                type: 'POST',
                success: function (e) {
                    if (typeof e != "undefined" && e != null) {
                        if (e.Status == "OK") {
                            alert("Eliminado")
                        }
                    }
                }
            });
        }
    });
   
});

$(document).on('click', '.js-btn-add-person', function () {

    $.ajax({
        url: location.origin + '/Persons/Create',
        type: 'POST',
        success: function(e) {
            if (typeof e != "undefined" && e != null) {
                createDialog('Prueba', e);
            }
        }
    });
});