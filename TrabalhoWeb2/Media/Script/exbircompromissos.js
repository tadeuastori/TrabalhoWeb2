//$(document).ready(
//    function () {
//        $.getJSON('/Agenda/retornaCompromissos', { qtd: 5 }, function (data) {
//            $("#trContainer").html('');
//            if (data.length == 0) {
//                $("#trContainer").append('<tr><td><h2>Sem compromissos futuros</h2></td></tr>');
//            } else {
//                $.each(data, function (index) {
//                    var d = new Date(parseInt(data[index].DataCompromisso.substr(6))),
//                        tag = '<tr><td>' +
//                                    '<div id="tituloCompromisso"><b>Título:</b> ' + data[index].Titulo + '</div>' +
//                                    '<div id="dataCompromisso"><b>Data:</b> ' + d.toLocaleString() + '</div>' +
//                                    '<div id="DescricaoCompromisso"><b>Descrição:</b> ' + data[index].Descricao + '</div>' +
//                                    '<div id="participantesCompromisso"><b>Participantes:</b> ';
//                    $.getJSON('/Agenda/retornaParticipantes', { evento: data[index].AgendaId }, function (ind) {
//                        tag += val[ind].Nome + ', ';
//                    });
//                    $("#trContainer").append(tag + '</div>' + '</td></tr>');
//                });
//            }
//        });
//    });



$(document).ready(
    function () {
        var $msg = $("#trContainer"),
            $retorno = $('#retornoLista');
        $.ajax({
            dataType: "json",
            url: "/Agenda/retornaCompromissos",
            data: { qtd: 5 },
            success: function (data) {                
                if (data.length === 0) {
                    $msg.append('<p>Sem compromissos futuros</p>');
                } else {
                    $.each(data, function (index) {
                        var d = new Date(parseInt(data[index].DataCompromisso.substr(6))),
                            tag = '<tr><td class="tdCompromisso">' +
                                                    '<div id="tituloCompromisso"><b>Título:</b> ' + data[index].Titulo + '</div>' +
                                                    '<div id="dataCompromisso"><b>Data:</b> ' + d.toLocaleString() + '</div>' +
                                                    '<div id="DescricaoCompromisso"><b>Descrição:</b> ' + data[index].Descricao + '</div>' +
                                                    '<div id="participantesCompromisso"><b>Participantes:</b><br> ';
                        $.ajax({
                            dataType: "json",
                            url: "/Agenda/retornaParticipantes",
                            data: { evento: data[index].AgendaId },
                            success: function (val) {
                                $.each(val, function (ind) {
                                    tag += '<div class="divParticipante">' + val[ind].Nome + '</div>';
                                });
                                $("#trContainer").append(tag + '</div>' + '</td></tr>');
                            }
                        });
                    });
                }
            }
        });
    });