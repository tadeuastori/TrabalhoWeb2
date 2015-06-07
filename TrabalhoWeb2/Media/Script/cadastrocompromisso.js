(function () {
    var $btn = $('#btnSubmit'),
        exibirData = function () {
        var $data = $('#DataCompromisso'),
            data = new Date(),
            y = data.getFullYear(),
            m = data.getMonth() + 1,
            d = data.getDate();
        if (m < 10) {
            m = '0' + m;
        }
        if (d < 10) {
            d = '0' + d;
        }
        $data.val(y + '-' + m + '-' + d);
    },

        verificaCampo = function (input, text) {
            $msg = $('.msg');
            if (input.val() === '') {
                $msg.append('<p>O campo ' + text +' deve ser preenchido.</p>');
                $msg.fadeOut(10000);
            }
            return false;
        },

        verificaTitulo = function () {
            var $input = $('#Titulo');
            $btn.click(function () {
                verificaCampo($input, 'título');
            });
        },

        verificaData = function () {
            var $input = $('#DataCompromisso');
            $btn.click(function () {
                verificaCampo($input, 'data');
            });
        },

        verificaDescricao = function () {
            var $input = $('#Descricao');
            $btn.click(function () {
                verificaCampo($input, 'descrição');
            });
        };

    exibirData();
    verificaTitulo();
    verificaData();
    verificaDescricao();
}());