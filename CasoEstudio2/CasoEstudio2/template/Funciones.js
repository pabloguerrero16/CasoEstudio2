$(document).ready(function () {
    $('#Id_Compra').change(function () {
        var idCompra = $(this).val();

        $.ajax({
            url: 'https://localhost:44374/ConsultarSaldo?q=' + idCompra,
            type: 'GET',
            success: function (saldo) {
                $('#exampleInputUsername2').val(saldo);
            },
            error: function () {
            }
        });
    });


    $('#Monto').on('input', function () {
        var abono = parseFloat($(this).val()) || 0;
        var saldoAnterior = parseFloat($('#exampleInputUsername2').val()) || 0;

        if (abono <= saldoAnterior && abono >= 0) {
            $('#btnAbonar').prop('disabled', false);
            $('#mensajeError').hide();
        } else {
            $('#btnAbonar').prop('disabled', true);
            $('#mensajeError').show();
        }
    });
});