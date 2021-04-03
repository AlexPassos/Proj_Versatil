/// GERA CÓDIGO ALFANUMÉRICOS////////////////////////////////////////
function gerarCOD(tamanho) {
    //Declaramos os caracteres que irão ser utilizados para gerar nossa string alfanumérica
    var caracteres = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
    //Declaramos a variável gerar_string_alfanumerica como vazia para logo abaixo adicionarmos a ela a quantidade de caracteres que forem passadas pela função e gerados aleatoriamente no for mais abaixo abaixo
    var gerar_string_alfanumerica = "";
    for (var i = 0; i < tamanho; i++) {
        var valor_aleatorio = Math.floor(Math.random() * caracteres.length);
        gerar_string_alfanumerica += caracteres.substring(valor_aleatorio, valor_aleatorio + 1);
    }
    //Retornamos a string alfanumérica gerada
    return gerar_string_alfanumerica;
}
/// GERA CÓDIGO ALFANUMÉRICOS////////////////////////////////////////

/// DATA ATUAL /////////////////////////////////////
function fnData() {

    var dt = new Date();

    var dia = dt.getDate();
    var mes = dt.getMonth() + 1;
    var ano = dt.getFullYear();

    //var data = ((dia < 10) ? "0" : "") + dia + "/" + ((mes < 10) ? "0" : "") + mes + "/" + ano;
    var data = ano + "-" + ((mes < 10) ? "0" : "") + mes + "-" + ((dia < 10) ? "0" : "") + dia;

    return data;

}//função data
/// DATA ATUAL /////////////////////////////////////

/// HORA ATUAL ////////////////////////////////////
function fnHora(){
    var now = new Date();
    //var hora = now.getHours()+':'+now.getMinutes()+':'+now.getSeconds();
    var hora = ((now.getHours() < 10) ? "0" : "") + now.getHours() + ':' + ((now.getMinutes() < 10) ? "0" : "") + now.getMinutes() + ':' + ((now.getSeconds() < 10) ? "0" : "") + now.getSeconds();
    return hora;
}
/// HORA ATUAL ////////////////////////////////////

/// ORDENAR COMBOBOX / SELECT ///////////////////////////////////////////
function ordenarCombo(select) {
    var options = $('#' + select + ' option');
    var arr = options.map(function (_, o) {
        return {
            t: $(o).text(),
            v: o.value
        };
    }).get();
    arr.sort(function (o1, o2) {
        return o1.t > o2.t ? 1 : o1.t < o2.t ? -1 : 0;
    });
    options.each(function (i, o) {
        //console.log(i);
        o.value = arr[i].v;
        $(o).text(arr[i].t);
    });
}
/// ORDENAR COMBOBOX / SELECT ///////////////////////////////////////////

/// FORMATA VALOR PARA MOEDA /////////////////////////////////////////////
function mascaraValor(valor) {
    valor = valor.toString().replace(/\D/g, "");
    valor = valor.toString().replace(/(\d)(\d{8})$/, "$1.$2");
    valor = valor.toString().replace(/(\d)(\d{5})$/, "$1.$2");
    valor = valor.toString().replace(/(\d)(\d{2})$/, "$1,$2");
    return valor;
}
/// FORMATA VALOR PARA MOEDA ////////////////////////////////////////////

 /// DIGITAR SÓ NÚMEROS //////////////////////////
    function soNumeros(e) {
        //teclas adicionais permitidas (tab,delete,backspace,setas direita e esquerda)
        keyCodesPermitidos = new Array(8, 9, 37, 39, 46, 188, 190);

        //numeros e 0 a 9 do teclado alfanumerico
        for (x = 48; x <= 57; x++) {
            keyCodesPermitidos.push(x);
        }

        //numeros e 0 a 9 do teclado numerico
        for (x = 96; x <= 105; x++) {
            keyCodesPermitidos.push(x);
        }

        //Pega a tecla digitada
        keyCode = e.which;
        //console.log(keyCode);
        //Verifica se a tecla digitada é permitida
        if ($.inArray(keyCode, keyCodesPermitidos) !== -1) {
            return true;
        }
        return false;
    }
    /// DIGITAR SÓ NÚMEROS //////////////////////////

