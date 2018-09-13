$(document).ready(function () {


    $(".comentar-r").click(function (e) {
        e.preventDefault();

        var id = $(this).data("postid");

        console.log(id);

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



    $(".curtir-r").click(function (e) {
        e.preventDefault();
        var v = 1;
        var id = $(this).data("postid");

        console.log(id);
        if (v == 1) {

            v = 2;
            $.ajax(
                {
                    type: 'POST',
                    url: '/Home/Curtir/' + id,
                    data: { id: id },
                    async: true,
                    success: function (data) {
                        console.log(data);
                        if (data == 0) {
                            $(".quantidadecurtir-" + id).css({ display: 'none' });
                        }
                        else {
                            $(".quantidadecurtir-" + id).css({ display: 'initial', "background-color": "#2196f3" });

                        }
                        $(".quantidadecurtir-" + id).text(data);
                        v = 1;

                        console.log(v);
                    }
                });
        }
    });

});