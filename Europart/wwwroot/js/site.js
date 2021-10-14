// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#filters").on("click", function (e) {
        e.preventDefault();
        let filter = document.getElementById("f-row");
        let elem = document.getElementsByClassName("kol");
        if (filter.classList.contains("show")) {
            $("#f-row").removeClass("show");
            for (i = 0; i < elem.length; i++) {
                elem[i].classList.remove("col-3");
            }
            for (i = 0; i < elem.length; i++) {
                elem[i].classList.add("col-4");
            }
        } else {
            $("#f-row").addClass("show");
            for (i = 0; i < elem.length; i++) {
                elem[i].classList.add("col-3");
            }
            for (i = 0; i < elem.length; i++) {
                elem[i].classList.remove("col-4");
            }
        }
        
    });
})
