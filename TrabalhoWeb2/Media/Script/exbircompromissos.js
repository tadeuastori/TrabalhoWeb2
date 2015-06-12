$(document).ready(
    function () {
        var $msg = $(".msg"),
            $retorno = $('#retornoLista'),
            url = location.href;
        $.ajax({
            dataType: "json",
            url: "/Agenda/retornaCompromissos",
            data: (function () {                
                if (url.indexOf("BoasVindas") != -1) {
                    return { qtd: 5 };
                } else if (url.indexOf("ListarCompromissos") != -1) {
                    return { qtd: 0 };
                }                
            }()),
            success: function (data) {
                if (data.length === 0) {
                    $msg.append('<p>Sem compromissos cadastrados.</p>');
                } else {
                    $.each(data, function (index) {
                        var d = new Date(parseInt(data[index].DataCompromisso.substr(6))),
                            tag = '<li class="lista-compromisso"><div><ul>' +
                                    '<li id=""><h2 class="lista-titulo">Título:</h2> ' + data[index].Titulo + '</li>' +
                                    '<li id=""><h2 class="lista-titulo">Data:</h2> ' + d.toLocaleString() + '</li>' +
                                    '<li id=""><h2 class="lista-titulo">Descrição:</h2> ' + data[index].Descricao + '</li>' +
                                    '<li id=""><h2 class="lista-titulo">Participantes:</h2>';
                        $.ajax({
                            dataType: "json",
                            url: "/Agenda/retornaParticipantes",
                            data: { evento: data[index].AgendaId },
                            success: function (val) {
                                $.each(val, function (ind) {
                                    tag += '<li class="lista-participante">' + val[ind].Nome + '</li>';
                                    if (url.indexOf("ListarCompromissos") != -1) {
                                        tag += '<div class="link-topo"><a class="link" href="/Agenda/AssociarParticipante?evento=' + data[index].AgendaId + '">+ Adicionar Participantes</a></div>';
                                    }
                                });
                                
                                $retorno.append(tag + '</div>');
                            }
                        });
                    });                    
                }
            }
        });
    });