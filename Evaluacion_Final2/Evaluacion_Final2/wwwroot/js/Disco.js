class ClaseDisco {
    constructor(Nombre, Capacidad, Tipo, accion) {
        this.Nombre = Nombre;
        this.Capacidad = Capacidad;
        this.Tipo = Tipo;
        this.accion = accion;

    }

    Nuevo_Disco(idDisco) {
        var Nombre = this.Nombre;
        var Capacidad = this.Capacidad;
        var Tipo = this.Tipo;
        var accion = this.accion;
        if (idDisco == '') {
            try {
                $.post(
                    accion,
                    { Nombre, Capacidad, Tipo },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Discos', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Discos', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        } else {
            try {
                $.post(
                    accion,
                    { idDisco, Nombre, Capacidad, Tipo },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Discos', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Discos', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Disco(idDisco) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { idDisco },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Nombre").value = respuesta.nombre;
                document.getElementById("Capacidad").value = respuesta.capacidad;
                document.getElementById("Tipo").value = respuesta.tipo;
                document.getElementById("idDisco").value = respuesta.idDisco;
            }
        });
    }

    eliminar_Disco(idDisco) {
        swal({
            title: "¿Eliminar Disco?",
            text: "Esta seguro que desea eliminar el Disco..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { idDisco },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Discos', respuesta.description, 'success');
                                this.limpiar();
                            } else {
                                swal('Discos', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Discos', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaDisco() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Disco').html(val[0]);
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Nombre").value = '';
        document.getElementById("Capacidad").value = '';
        document.getElementById("Tipo").value = '';
        document.getElementById("idDisco").value = '';
        $('#Ingreso_Disco').modal('hide');
        listaDisco();
    }




}