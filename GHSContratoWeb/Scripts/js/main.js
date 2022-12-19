$(document).ready(function () {

    // Barra de pesquisa cresce e diminui quando é clicado dentro dela
    $(".input-pesquisa").click(function () {
        $(".input-pesquisa").off("click");
        $(this).animate({ "width": 500 }, 500);
        $(this).animate({ "height": 660 }, 500);
        $(this).children(".primeiro").hide();
        $(this).children("select").fadeIn();
        $(this).children("input:not(.primeiro)").fadeIn();
        $(".Codigo").focus();
    });

    $(".Genero, .Autor, .Situacao, .Vencimento").change(function () {
        $(this).css("color", "#000");
    });

    // Barra de pesquisa cresce e diminui quando é clicado dentro dela
    $(".input-pesquisa-emprestimo").click(function () {
        $(".input-pesquisa-emprestimo").off("click");
        $(this).animate({ "width": 500 }, 500);
        $(this).animate({ "height": 630 }, 500);
        $(this).children(".primeiro").hide();
        $(this).children("select").fadeIn();
        $(this).children("input:not(.primeiro)").fadeIn();
        $(".UsuarioBibliotecaNome").focus();
    });

    $(".input-pesquisa-genero").click(function () {
        $(this).animate({ "width": 500 }, 500);
        $(this).animate({ "height": 630 }, 500);
    });

    $(".input-pesquisa-usuario-biblioteca").click(function () {
        $(".input-pesquisa-usuario-biblioteca").off("click");
        $(this).animate({ "width": 500 }, 500);
        $(this).animate({ "height": 630 }, 500);
        $(this).children(".primeiro").hide();
        $(this).children("select").fadeIn();
        $(this).children("input:not(.primeiro)").fadeIn();
        $(".UsuarioBibliotecaNome").focus();
    });

});


