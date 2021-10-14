// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#filters").on("click", function (e) {
        e.preventDefault();
        let filter = document.getElementById("f-row");
        if (filter.classList.contains("show")) {
            $("#f-row").removeClass("show");
        } else {
            $("#f-row").addClass("show");
            let elem = document.getElementsByClassName("col-4");
            for (i = 0; i < elem.length; i++) {
                console.log(elem[i]);
                elem[i].classList.remove("col-4");
                elem[i].classList.add("col-3");
            }
        }
        
    });
})
