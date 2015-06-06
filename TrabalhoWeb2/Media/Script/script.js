$(document).ready(
            function () {
                $.getJSON(
                    '@Url.Content("~/Agenda/retornaCompromissos")',
                            { qtd: 0 },
                            function (data) {
                                $("#trContainer").html('');

                                if (data.length == 0) {

                                    $("#trContainer").append('<tr><td><h2>Sem compromissos futuros</h2></td></tr>');

                                } else {

                                    $.each(
                                    data,
                                    function (index) {
                                        var d = new Date(parseInt(data[index].DataCompromisso.substr(6)));

                                        var tag = '<tr><td>' +
                                            '<div id="tituloCompromisso"><b>Título:</b> ' + data[index].Titulo + '</div>' +
                                            '<div id="dataCompromisso"><b>Data:</b> ' + d.toLocaleString() + '</div>' +
                                            '<div id="DescricaoCompromisso"><b>Descrição:</b> ' + data[index].Descricao + '</div>' +
                                            '<div id="participantesCompromisso"><b>Participantes:</b> ';

                                        $.getJSON(
                                            '@Url.Content("~/Agenda/retornaParticipantes")',
                                            { evento: data[index].AgendaId },
                                            function (val) {
                                                $.each(
                                                    val,
                                                    function (ind) {
                                                        tag += val[ind].Nome + ', '
                                                    });
                                                $("#trContainer").append(tag + '</div>' + '</td></tr>');
                                            })
                                    })
                                }
                            })
            })