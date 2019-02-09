// Write your JavaScript code.
$().ready(
    () => {
        listaDisco();
        listaInformacion();
        
    });

var nuevo_Disco = () => {
    var Nombre = document.getElementById('Nombre').value;
    var Capacidad = document.getElementById('Capacidad').value;
    var Tipo = document.getElementById('Tipo').value;

    var idDisco = document.getElementById("idDisco").value;

    if (idDisco == '') {
        var accion = '../Discos/Nuevo_Disco_Controller';
    } else {
        var accion = '../Discos/Editar_Disco_Controller';
    }

    if (Nombre == '') {
        $('#control_Nombre').removeClass('hidden');
    } else {
        $('#control_Nombre').addClass('hidden');
        if (Capacidad == '') {
            $('#control_Capacidad').removeClass('hidden');
        } else {
            $('#control_Capacidad').addClass('hidden');
            if (Tipo == '') {
                $('#control_Tipo').removeClass('hidden');
            } else {
                $('#control_Tipo').addClass('hidden');
                var clasedisc = new ClaseDisco(Nombre, Capacidad, Tipo, accion);
                clasedisc.Nuevo_Disco(idDisco);

            }
        }

    }

}

var nuevo_Informacion = () => {
    var Ubicacion = document.getElementById('Ubicacion').value;
    var Detalle = document.getElementById('Detalle').value;
    var Tamaño = document.getElementById('Tamaño').value;
    var Nombre = document.getElementById('Nombre').value;
    var Fecha = document.getElementById('Fecha').value;

    var idInformacion = document.getElementById("idInformacion").value;

    if (idInformacion == '') {
        var accion = '../Informacion/Nuevo_Informacion_Controller';
    } else {
        var accion = '../Informacion/Editar_Informacion_Controller';
    }

    if (Ubicacion == '') {
        $('#control_Ubicacion').removeClass('hidden');
    } else {
        $('#control_Ubicacion').addClass('hidden');
        if (Detalle == '') {
            $('#control_Detalle').removeClass('hidden');
        } else {
            $('#control_Detalle').addClass('hidden');
            if (Tamaño == '') {
                $('#control_Tamaño').removeClass('hidden');
            } else {
                $('#control_Tamaño').addClass('hidden');
                if (Nombre == '') {
                    $('#control_Nombre').removeClass('hidden');
                } else {
                    $('#control_Nombre').addClass('hidden');
                    if (Fecha == '') {
                        $('#control_Fecha').removeClass('hidden');
                    } else {
                        $('#control_Fecha').addClass('hidden');
                        var claseInfo = new ClaseInformacion(Ubicacion,Detalle,Tamaño,Nombre,Fecha,accion)
                        claseInfo.Nuevo_Informacion(idInformacion);
                    }
                }
            }
        }

    }

}





var Un_Disco = (idDisco) => {
    var accion = "../Discos/Un_Disco_Controller";
    var disco = new ClaseDisco(' ', ' ', ' ', accion);
    disco.Un_Disco(idDisco);
}

var Un_Informacion = (idInformacion) => {
    var accion = "../Informacion/Un_Informacion_Controller";
    var informacion = new ClaseInformacion('','','','','',accion)
    informacion.Un_Informacion(idInformacion);
}




////Ingreso de Eliminar/////


var eliminar_disco = (idDisco) => {
    var accion = "../Discos/Eliminar_Disco_Controller";
    var disco = new ClaseDisco(' ', ' ', ' ', accion);
    disco.eliminar_Disco(idDisco);
}

var eliminar_Informacion = (idInformacion) => {
    var accion = "../Informacion/Eliminar_Informacion_Controller";
    var informacion = new ClaseInformacion('', '', '', '', '', accion);
    informacion.eliminar_Informacion(idInformacion);
}

var validarRUC = () => {
    var ruc = document.getElementById('Ruc').value;
    if (ruc == '') {
        $('#control_Ruc').removeClass("hidden");

    } else {
        var accion = 'Proveedors/Validar_Ruc_Proveedor_Controller';
        var proveedor = new ClaseProveedores(ruc, ' ', ' ', ' ', ' ', accion);
        proveedor.validarRUC();
    }
}


////Validacion correos/////


////Ingreso de Listas/////


var listaDisco = () => {
    var accion = 'Discos/Lista_Disco_Controller';
    var disco = new ClaseDisco('', '', '', accion);
    disco.listaDisco();
}

var listaInformacion = () => {
    var accion = 'Informacion/Lista_Informacion_Controller';
    var info = new ClaseInformacion('', '', '', '', '', accion);
    info.listaInformacion();
}








var Imprimir_Disco = () => {
    var contenido = document.getElementById('Imprimir_Disco').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte').modal('hide');
}

var Imprimir_Informacion = () => {
    var contenido = document.getElementById('Imprimir_Informacion').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte1').modal('hide');
}

var quitar_Botones1 = () => {
    var contador = 0;
    $('#Cuerpo_Disco tr').each(function () {
        var celdas = $(this).find('td');

        $(celdas[5]).addClass('hidden');

    });
}

var quitar_Botones1 = () => {
    var contador = 0;
    $('#Cuerpo_Informacion tr').each(function () {
        var celdas = $(this).find('td');

        $(celdas[5]).addClass('hidden');

    });
}

