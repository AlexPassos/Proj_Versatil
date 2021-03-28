function confirmacaoExclusao(url, title, texto){
    
    Swal.fire({
        title: title,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#17a2b8',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Não',
        confirmButtonText: 'Sim'
    }).then((result) => {
        
        if (result.value) {
            $.ajax({
                dataType: 'json',
                url: url,
                type: 'DELETE',
                beforeSend: function () {
                    //blockUI('Processando...');
                },
                success: function (retorno) {
                  console.log(retorno);
                    if (retorno.success) {
                        mensagemSuccess(retorno.messages[0]);
                        setTimeout(function(){
                            window.location.href = retorno.url;
                        }, 1000);
                    } else {
                        mensagemErro(retorno.messages[0]);
                    }
                },
                error: function (erro) {
                    mensagemErro('Ops! Erro na requisição da solitação.');
                }
            });
        }
      })
}