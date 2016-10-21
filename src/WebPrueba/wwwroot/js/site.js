var table;
var dialog;

function releaseFormDialog() {
    dialog.close();
}
 
$(document).ajaxStart(function () {
    $('.loading').removeClass('hidden');
});

$(document).ajaxStop(function () {
    $('.loading').addClass('hidden');
});

$(document).ready(function () { 
    table = $('#personsTable').DataTable({
        "ajax": {
            "url": location.origin + '/Persons/Get/',
            "type": "POST"
        },
        language: {
            url: "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
        }, 
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": "<a style=\"text-decoration:none;cursor:pointer;font-size:15px;\" title=\"Editar\" class=\"js-edit fa fa-pencil-square-o\"></a> <a style=\"text-decoration:none;cursor:pointer;font-size:15px;\" title=\"Eliminar\" class=\"js-delete fa fa-trash-o\"></a>"
        }]
    });
});

$(document).on('click', '.js-edit', function () {
    var datad = table.row($(this).parents('tr')).data();
    $.ajax({
        url: location.origin + '/Persons/Edit',
        type: 'POST',
        data: { id: datad[4] }, 
        success: function (e) { 
            if (typeof e != "undefined" && e != null) {
                dialog = $.confirm({
                    title: false,
                    content: e,
                    confirmButton: 'Guardar',
                    cancelButton: 'Cancelar',
                    confirm: function () {
                        var form = document.getElementById('FormPerson');
                        var formData = new FormData(form);
                        formData.append("PersonId", datad[4]);
                        if ($("#FormPerson").valid()) {
                            $.ajax({
                                url: location.origin + '/Persons/Update',
                                type: 'POST',
                                data: formData,
                                processData: false,
                                contentType: false,
                                success: function () {
                                    console.log("I Have Successful :D");
                                    table.ajax.reload();
                                }
                            });
                        }
                        else {
                            return;
                        }
                        
                    }
                });
            }
        }
    });

});
 
$(document).on('click', '.js-delete', function () { 
    var datad = table.row($(this).parents('tr')).data(); 
    dialog = $.confirm({
        title: 'Eliminar Registro',
        content: '¿Desea eliminar esta persona?',
        confirmButton: 'Aceptar',
        cancelButton: 'Cancelar',
        confirm:function() {
            $.ajax({
                url: location.origin + '/Persons/Delete/',
                data: { id: datad[4] },
                type: 'POST',
                success: function (e) { 
                   table.ajax.reload();
                }
            });
        }
    });
   
});

$(document).on('click', '.js-btn-add-person', function () {
    $.ajax({
        url: location.origin + '/Persons/CreatePerson',
        type: 'POST',
        success: function(e) {
            if (typeof e != "undefined" && e != null) {
                dialog = $.confirm({
                    title: false,
                    content: e,
                    confirmButton: 'Guardar',
                    cancelButton: 'Cancelar', 
                    confirm: function () {
                        var form = document.getElementById('FormPerson');
                        var formData = new FormData(form);
                        if ($("#FormPerson").valid()) {
                            $.ajax({
                                url: location.origin + '/Persons/Create',
                                type: 'POST',
                                data: formData,
                                processData: false,
                                contentType: false,
                                success: function () {
                                    console.log("I Have Successful :D");
                                    table.ajax.reload();
                                }
                            });
                        } else {
                            return;
                        }
                    }
                });
            }
        }
    });
});