$(document).ready(function () {


    var limit = 1;
    var offset = 0;
    var recarregar = 1;
    var valorHeight = $(window).height();

    $(".conteudo").css({ height: valorHeight });

    

    $(".comentar").click(function (e) {
        e.preventDefault();

        var id = $(this).data("postid");

    
        $.ajax(
            {
                type: 'GET',
                url: '/Home/AtualizarComentario/' + id,
                dataType: 'html',
                data: { id: id },
                async: true,
                success: function (data) {
                    $('#comentarios-' + id).html(data);
                }
            });
    });



    $(".curtir").click(function (e) {
        e.preventDefault();

        var id = $(this).data("postid");

        $.ajax(
            {
                type: 'POST',
                url: '/Home/Curtir/' + id,
                data: { id: id },
                async: true,
                success: function (data) {
        
                    if (data == 0) {
                        $(".quantidadecurtir-" + id).css({ display: 'none' });
                    }
                    else {
                        $(".quantidadecurtir-" + id).css({ display: 'initial', "background-color": "#2196f3" });

                    }
                    $(".quantidadecurtir-" + id).text(data);
                }
            });
    });


    $(window).scroll(function (e) {
        e.preventDefault();
        if (($(window).scrollTop() + $(window).height() + 20) >= $(document).height()) {
            //requisição ajax para selecionar postagens


            if (recarregar == 1) {


                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": true,
                    "positionClass": "toast-bottom-center",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }

                Command: toastr["success"]("Carregando...")

                recarregar = recarregar + 1;
                limit = limit + 1;
                offset = offset + 1;
            
                $.ajax({
                    url: '/Home/CarregarFeed', //Página PHP que seleciona postagens
                    type: 'GET', // método post, GET ...
                    dataType: 'Html',
                    async: true,
                    data: { 'limit': limit, 'offset': offset }, //seus paramêtros
                    beforeSuceess: function () {
                        recarregar = 0;
                    },
                    success: function (data) { // sucesso de retorno executar função
                        recarregar = 1;
                        $('#conteudo').append(data); // adiciona o resultado na div #conteudo
                        toastr.clear();


                    },// fim success
                    error: function (data) {
                        toastr.clear();
                        Command: toastr["info"]("Não possui mais posts para seremos carregados.");
                        $('#conteudo').append('<a href="#" style="margin: 50px 0px;" class="btn btn-primary btn-block">Encontrar Amigos</a>');

                    }
                }); // fim ajax
            }
            
        } // fim do if
    }); // fim scroll

    
}); 


