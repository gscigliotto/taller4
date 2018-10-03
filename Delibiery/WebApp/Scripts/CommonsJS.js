function RecuperaPass(id) {

    $("#msgbag").css("display", "none");
    var fileID = id;
    var params = "{'id': '" + fileID + "'}";
    $.ajax({
        type: 'POST',
        url: '/Usuarios/RecuperarPass',
        data: params,

        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#msgbag").css("display", "");
            $("#msgbag").text("Contraseña enviada correctamente.");

        },

        error: function (response) {
            //alert(response.responseText);
            $("#msgbag").css("display", "");
            $("#msgbag").text("Surgio un inconveniente.");
        }
    });



    return false;
}