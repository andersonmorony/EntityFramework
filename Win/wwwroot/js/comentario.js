var controleVezes = 0;



$(".comentarpost").click(function (e) {
    e.preventDefault();

    var botao = Ladda.create(this);
    var id = $(this).data("postid");
    var texto = $("#texto-" + id).val();

    if (texto != "") {
        
    botao.start();

        $.ajax(
            {
                type: 'POST',
                url: '/Home/Comentar',
                dataType: 'html',
                data: { "PostId": id, "Texto": texto },
                async: true,
                success: function (data) {
                    $('#comentarios-' + id).html(data);


                    $.ajax(
                        {
                            type: 'GET',
                            url: '/Home/QuantidadeComentarioAtualizar/' + id,
                            dataType: 'html',
                            data: { id: id },
                            async: true,
                            success: function (data) {
                                botao.stop();
                                $('#quantidadeComentario-' + id).text(data);
                            }
                        });
                }
            });
    }
    


});

$(".btn-visualizarpost").click(function (e) {
    e.preventDefault();

    if (controleVezes == 0) {


        controleVezes = 1;

        var id = $(this).data("postid");
        $('#myModal1').modal('show');

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-center",
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

        $.ajax(
            {
                type: 'Get',
                url: '/Post/VisualizarPost/' + id,
                data: { id: id },
                async: true,
                beforeSuceess: function () {
                    $('#modal-body-visualizar-post').html("Carregando...");
                },
                success: function (data) {

                    toastr.clear();
                    $("#modal-body-visualizar-post").html(data);
                }
            });
    }
});