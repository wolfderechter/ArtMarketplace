/* global $ */

$(document).ready(function () {
    $('#filters').on('click', function (e) {
        e.preventDefault();
        let filter = document.getElementById('f-row');
        let elem = document.getElementsByClassName('kol');
        if (filter.classList.contains('show')) {
            $(this).html('Toon filters');
            $('#f-row').removeClass('show');
            for (let i = 0; i < elem.length; i++) {
                elem[i].classList.remove('col-3');
            }
            for (let i = 0; i < elem.length; i++) {
                elem[i].classList.add('col-4');
            }
        } else {
            $(this).html('Verberg filters');
            $("#f-row").addClass('show');
            for (let i = 0; i < elem.length; i++) {
                elem[i].classList.add('col-3');
            }
            for (let i = 0; i < elem.length; i++) {
                elem[i].classList.remove('col-4');
            }
        }
    });
})