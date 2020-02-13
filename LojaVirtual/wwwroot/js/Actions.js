﻿$(document).ready(function () {    
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Tem certeza que deseja realizar esta operação?");

        if (resultado == false) {
            e.preventDefault();
        }
    });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });

    AjaxUploadImagemProduto();
});

function AjaxUploadImagemProduto() {
    $(".img-upload").click(function () {
        $(this).parent().find(".input-file").click();
    });

    $(".btn-imagem-excluir").click(function () {
        var campoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");

        $.ajax({
            type: "GET",
            url: "/Colaborador/Imagem/Deletar?caminho=" + campoHidden.val(),
            error: function () {
            },
            success: function (data) {
                Imagem.attr("src", "/img/imagem-padrao.png");
            }
        })
    });

    $(".input-file").change(function (){
        //Formulario de dados via JS
        var Binario = $(this)[0].files[0];
        var Formulario = new FormData();
        Formulario.append("file", Binario);

        var campoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");
        //TODO: Requisicao Ajax enviando Formulario
        $.ajax({
            type: "POST",
            url: "/Colaborador/Imagem/Armazenar",
            data: Formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro no envio do arquivo");
            },
            success: function (data) {
                var caminho = data.caminho;
                Imagem.attr("src", caminho);
                campoHidden.val(caminho);
            }
        })

    });
}