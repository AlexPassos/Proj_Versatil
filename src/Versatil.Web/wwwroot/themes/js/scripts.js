$(function () {
    paceOptions = {
        ajax: true,
        document: true,
        eventLag: {
            lagThreshold: 10
        }
    };

    $.ajaxSetup({ cache: false });

    $(document).ajaxStart(function () {
        Pace.restart();
    }).ajaxStop(unblockUI);

    $('.cpf-mask').mask('000.000.000-00', { reverse: true });
    $('.date-mask').mask('00/00/0000', { placeholder: '__/__/____' });
    $('.money-mask').mask("#.##0,00", { reverse: true });
    $('.telefone-mask').mask('(00) 0000-0000');
    $('.celular-mask').mask('(00) 00000-0000');

    $('.date-picker').datetimepicker({
        format: 'DD/MM/YYYY',
        locale: 'pt-BR'
    });

    $('[data-toggle="tooltip"]').tooltip();

    slideToTop();
});

function initBSTooltip() {
    $('[data-toggle="tooltip"]').tooltip();
}

function erroAjax(error, funcAction) {
    var toastrOptions = {
        closeButton: true,
        timeOut: "5000",
        positionClass: "toast-bottom-right",
    };

    unblockUI();

    if (error.status == 400) {
        Swal.fire({
            type: "error",
            title: "Ops! Algo deu errado",
            html: errorSweetAlert(error.responseJSON.errors),
        });
    } else if (error.status == 401) {
        toastr.options = toastrOptions;
        toastr["error"]("Sua sess&atilde;o expirou, efetue login novamente.");
        setTimeout(function () {
            window.location.href = "/";
        }, 1000);
    } else if (error.status == 403) {
        toastr.options = toastrOptions;
        toastr["error"]("Você não tem acesso a este recurso.");
    } else if (error.status == 404) {
        toastr.options = toastrOptions;
        toastr["error"]("Página ou recurso não encontrado.");
    } else if (error.status == 500) {
        toastr.options = toastrOptions;
        toastr["error"]("Erro interno.");
    } else {
        toastr.options = toastrOptions;
        toastr["error"]("Falha na conex&atilde;o.");
    }

    funcAction();
}

function sucessoAjax(data, mensagem, funcAction) {
    unblockUI();

    if (data.success) {
        toastr.options = {
            "closeButton": true,
            "timeOut": "10000",
            "positionClass": "toast-bottom-right"
        }
        toastr["success"](mensagem);
        funcAction();
    }
}

function errorSummary(error, seletorInner) {
    var message = '';
    var messagesList = '';

    for (var i = 0, length = error.length; i < length; i++) {
        message = error[i];
        messagesList += '<li>' + message + '</li>';
    }

    if (error.length > 0) {

        var html = '<div class="alert alert-danger" fade show role="alert">';
        html += '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>';
        html += '<h4>Ops!</h4>';
        html += '<ul class="text-danger text-left">';
        html += messagesList;
        html += '</ul>';
        html += '</div>';

        $(seletorInner).html(html);
    }
}

function slideToTop() {
    var $slideToTop = $("<div />");

    $slideToTop.html('<i class="fa fa-chevron-up"></i>');

    $slideToTop.css({
        position: "fixed",
        bottom: "20px",
        right: "25px",
        width: "40px",
        height: "40px",
        color: "#eee",
        "font-size": "",
        "line-height": "40px",
        "text-align": "center",
        "background-color": "#222d32",
        cursor: "pointer",
        "border-radius": "5px",
        "z-index": "99999",
        opacity: ".7",
        display: "none",
    });

    $slideToTop.on("mouseenter", function () {
        $(this).css("opacity", "1");
    });

    $slideToTop.on("mouseout", function () {
        $(this).css("opacity", ".7");
    });

    $(".wrapper").append($slideToTop);

    $(window).scroll(function () {
        if ($(window).scrollTop() >= 150) {
            if (!$($slideToTop).is(":visible")) {
                $($slideToTop).fadeIn(500);
            }
        } else {
            $($slideToTop).fadeOut(500);
        }
    });

    $($slideToTop).click(function () {
        $("html, body").animate(
            {
                scrollTop: 0,
            },
            500
        );
    });
}

function errorSweetAlert(data) {
    var message = '';
    var messagesList = '';

    for (var i = 0, length = data.length; i < length; i++) {
        message = data[i];
        messagesList += '<li>' + message + '</li>';
    }

    var html = '';
    html += '<ul class="text-danger text-left">';
    html += messagesList;
    html += '</ul>';

    return html;
}

function dataTableLanguages() {
    var language = {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ at&eacute; _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 at&eacute; 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por p&aacute;gina",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Pr&oacute;ximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "&Uacute;ltimo"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    };
    return language;
}

function blockUI(texto) {
    var message = texto !== undefined ? texto : "";
    $.blockUI({
        message:
            '<div class="fa-3x"><i class="fas fa-circle-notch fa-spin"></i> ' +
            message +
            "</div>",
        css: {
            backgroundColor: "transparent",
            color: "#F7A33D",
            border: "none",
            zIndex: 99999,
        },
        overlayCSS: {
            backgroundColor: "#000",
            opacity: 0.5,
            zIndex: 99998,
        },
    });
}

function unblockUI() {
    $.unblockUI();
}