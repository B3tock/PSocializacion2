function CallPopUpWindowMsj(url) {
    $("#dialog-message").dialog({
        modal: true, buttons: {
            Aceptar: function () {
                $(this).dialog("close"); if (url != "vacio") { location.href(url) }
            }
        }
    })
}
function alertMsj(title, content, url) {
    $("#msjContent").text(content);
    $("#msjTitle").text(title); CallPopUpWindowMsj(url)
}
function CallPopUpWindow() {
    $("#dialog-message").dialog({
        modal: true, buttons: { Ok: function () { $(this).dialog("close") } }
    })
}
function alertacall(title, content) {
    $("#msjContent").text(content);
    $("#msjTitle").text(title); CallPopUpWindow()
}
function myfunction(cadena) {
    var caja2 = $('<div title="Mensaje Sistema !!"><p>' + cadena + "</p></div>");
    caja2.dialog({ buttons: { Ok: function () { $(this).dialog("close") } } })
}
function mialertaimagen(cadena) {
    var caja2 = $('<div title="Mensaje Sistema !!"><p>' + cadena + "</p></div>");
    caja2.dialog({ buttons: { Aceptar: function () { $(this).dialog("close") } } })
}
function mialertaMVC(cadena,url) {
    var caja2 = $('<div title="Mensaje Sistema !!"><p>' + cadena + "</p></div>");
    caja2.dialog({
        buttons: {
            Cancelar: function () {
                $(this).dialog("close")
            },
            Aceptar: function () {
                $(this).dialog("close");
                location.href = url;
            }
        }
    })
}
function mensajemodal(cadena, url) {
    var caja2 = $('<div title="Mensaje Sistema !!"><p>' + cadena + "</p></div>");
    caja2.dialog({
        modal: true,        
        buttons: {
            Cancelar: function () {
                $(this).dialog("close")
            },
            Aceptar: function () {
                $(this).dialog("close");
                if (url == '')
                    history.go(-3);
                else
                    location.href = url;
            }
        }
    })
}
function mensajemodalaceptar(cadena) {
    var caja2 = $('<div title="Mensaje Sistema !!"><p>' + cadena + "</p></div>");
    caja2.dialog({        
        modal: true,
        buttons: {           
            Aceptar: function () {
                $(this).dialog("close");                
            }
        }
    })
}