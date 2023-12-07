$(document).ready(function () {
    $('#IdCasa').change(function () {
        var idCasa = $(this).val();

        $.ajax({
            url: 'https://localhost:44347/ConsultarPrecio?q=' + idCasa,
            type: 'GET',
            success: function (precio) {
                $('#exampleInputUsername2').val(precio);
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

    $('#IdCasa').change(function () {
        // Obtener el valor seleccionado en el dropdown
        var selectedValue = $(this).val();

        // Seleccionar el botón por su clase
        var btnAbonar = $('.btn-abonar');

        // Habilitar o deshabilitar el botón según la opción seleccionada
        btnAbonar.prop('disabled', selectedValue === '');
    });
});