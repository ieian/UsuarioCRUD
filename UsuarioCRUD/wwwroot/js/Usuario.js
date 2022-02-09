var datatable;

$(document).ready(function () {
    LoadDataTable();
    var id = document.getElementById("usuarioId");
    if (id.value > 0) {
        $('#myModal').modal('show');
    }
});

function limpiar() {
    var usuarioId = document.getElementById("usuarioId");
    var usuarioNombre = document.getElementById("usuarioNombre");
    var usuarioApellido = document.getElementById("usuarioApellido");
    var usuarioDireccion = document.getElementById("usuarioDireccion");
    var usuarioCodigoP = document.getElementById("usuarioCodigoP");
    var usuarioTelefono = document.getElementById("usuarioTelefono");
    var usuarioTipo = document.getElementById("usuarioTipo");
    var usuarioEstado = document.getElementById("usuarioEstado");
    var usuarioCiudad = document.getElementById("usuarioCiudad");

    usuarioId.value = 0;
    usuarioNombre.value = "";
    usuarioApellido.value = "";
    usuarioDireccion.value = "";
    usuarioCodigoP.value = "";
    usuarioTelefono.value = "";
    usuarioTipo.value = "";
    usuarioEstado.value = true;
    usuarioCiudad.value = true;
}

function LoadDataTable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Usuario/ObtenerTodos"
        },
        "columns": [
            { "data": "nombre", "width": "12%" },
            { "data": "apellido", "width": "12%" },
            { "data": "direccion", "width": "12%" },
            { "data": "telefono", "width": "12%" },
            { "data": "codigoP", "width": "12%" },
            { "data": "tipo_Usuario", "width": "12%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "width": "12%",
            },
            {
                "data": "ciudad",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "width": "12%",
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div>
                            <a href="/Usuario/Crear/${data}" class="btn btn-success text-white" style="cursor:pointer;">
                                Editar
                            </a>
                            <a onclick=Eliminar("/Usuario/Eliminar/${data}") class="btn btn-danger text-white" style="cursor:pointer;")>
                                Eliminar
                            </a>
                        </div>
                        `;
                }, "width": "30%"
            }
        ]
    });
}

function Eliminar(url) {
    swal({
        title: "Estas seguro de elimiar este cliente?",
        text: "Este registro no se podra recuperar",
        icon: "warning",
        buttons: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        alert(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        alert(data.message);
                    }
                }
            });
        }
    });
}