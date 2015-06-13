$(document).ready(
    function () {
        $.getJSON(
            '/Agenda/listarUsuario',
                null,
                function (data) {
                    $('#lstUsuario').find('option').remove();
                    $.each(
                        data,
                        function (index) {
                            $('#lstUsuario').append('<option value="' + data[index].UsuarioId + '">' + data[index].Nome + '</option>');
                        })

                });

        $.getJSON(
            '/Agenda/retornaParticipantes',
            { evento: $('#AgendaId').val() },
            function (val) {
                tag = '';
                $.each(
                    val,
                    function (ind) {
                        tag += '<li class="lista-participante">' + val[ind].Nome + '</li>';
                    });
                $("#tdBody").append(tag);
            });

        $('#btnAdicionar').click(
            function () {
                $('#carregando').html('Salvando Dados. Aguarde!');

                $.post(
                    '/Agenda/adicionarParticipante',
                {
                    IdNovoUsuario: $('#lstUsuario').val(),
                    IdAgenda: $('#AgendaId').val(),
                    IdUsuario: $('#UsuarioId').val(),
                },
                function () {
                    $('#carregando').html('');
                    alert('Participante adicionado com sucesso!');
                    location.reload();
                }
                )
            });

        $('#btnRemover').click(
            function () {
                $('#carregando').html('Salvando Dados. Aguarde!');

                $.post(
                    '/Agenda/removerParticipante',
                {
                    IdNovoUsuario: $('#lstUsuario').val(),
                    IdAgenda: $('#AgendaId').val(),
                    IdUsuario: $('#UsuarioId').val(),
                },
                function () {
                    $('#carregando').html('');
                    alert('Participante removido com sucesso!');
                    location.reload();
                }
                )
            });

    });