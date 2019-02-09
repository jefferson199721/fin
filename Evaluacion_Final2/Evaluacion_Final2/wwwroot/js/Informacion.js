class ClaseInformacion {
    constructor(Ubicacion, Detalle, Tamaño, Nombre, Fecha, accion) {
        this.Ubicacion = Ubicacion;
        this.Detalle = Detalle;
        this.Tamaño = Tamaño;
        this.Nombre = Nombre;
        this.Fecha = Fecha;
        this.accion = accion;

    }

    Nuevo_Informacion(idInformacion) {
        var Ubicacion = this.Ubicacion;
        var Detalle = this.Detalle;
        var Tamaño = this.Tamaño;
        var Nombre = this.Nombre;
        var Fecha = this.Fecha;
        var accion = this.accion;
        if (idInformacion == '') {
            try {
                $.post(
                    accion,
                    { Ubicacion, Detalle, Tamaño, Nombre, Fecha },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Informacion', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Informacion', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        } else {
            try {
                $.post(
                    accion,
                    { idInformacion, Ubicacion, Detalle, Tamaño, Nombre, Fecha  },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Informacion', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Informacion', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Informacion(idInformacion) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { idInformacion },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Ubicacion").value = respuesta.ubicacion;
                document.getElementById("Detalle").value = respuesta.detalle;
                document.getElementById("Tamaño").value = respuesta.tamaño;
                document.getElementById("Nombre").value = respuesta.nombre;
                document.getElementById("Fecha").value = respuesta.fecha;
                document.getElementById("idInformacion").value = respuesta.idInformacion;
            }
        });
    }

    eliminar_Informacion(idInformacion) {
        swal({
            title: "¿Eliminar Informacion?",
            text: "Esta seguro que desea eliminar la Informacion..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { idInformacion },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Informacion', respuesta.description, 'success');
                                this.limpiar();
                            } else {
                                swal('Informacion', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Informacion', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaInformacion() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Informacion').html(val[0]);
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Ubicacion").value = '';
        document.getElementById("Detalle").value = '';
        document.getElementById("Tamaño").value = '';
        document.getElementById("Nombre").value = '';
        document.getElementById("Fecha").value = '';
        document.getElementById("idInformacion").value = '';
        $('#Ingreso_Informacion').modal('hide');
        listaDisco();
    }




}