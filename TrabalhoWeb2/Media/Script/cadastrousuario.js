(function () {
    var $btn = $('#btnSubmit'),
        verificaCampo = function (input, text) {
            $msg = $('.msg');
            if (input.val() === '') {
                $msg.append('<p>O campo ' + text + ' deve ser preenchido.</p>');
                $msg.fadeOut(10000);
            }
            return false;
        },

        verificaNome = function () {
            var $input = $('#Nome');
            $btn.click(function () {
                verificaCampo($input, 'nome');
            });
        },

        verificaLogin = function () {
            var $input = $('#Login');
            $btn.click(function () {
                verificaCampo($input, 'login');
            });
        },

        verificaSenha = function () {
            var $input = $('#Senha');
            $btn.click(function () {
                verificaCampo($input, 'senha');
            });
        },

        validacaoSenha = function () {
            var $senha = $('#Senha'),
                $validacao = $('#senhaValidacao');
            $btn.click(function () {
                if($senha.val !== $validacao.val()) {
                    $msg.append('<p>O campo senha e confirmação de senha devem ter o mesmo valor.</p>');
                    $msg.fadeOut(10000);
                }
            });
        };

    verificaNome();
    verificaLogin();
    verificaSenha();
    validacaoSenha();
}());