$(document).ready(function () {
    $(".check-box").click(function () {
        $.ajax({
            data: { "Id": $(this).parent().prev().prev().prev().text() },
            url: '/Comentario/ActiveDeactive',
            type: 'post',
            success: function (response) {
                
            }
        });
    });




});

