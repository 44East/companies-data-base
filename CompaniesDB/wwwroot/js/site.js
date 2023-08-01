// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    // Используем делегирование событий для клика на ссылке с классом "employee-link"
    $(document).on("click", ".employee-link", function (e) {
        e.preventDefault();
        var employeeId = $(this).data("employee-id");
        getEmployeeDetails(employeeId);
    });

    function getEmployeeDetails(employeeId) {
        $.ajax({
            type: "GET",
            url: "/Companies/GetEmployeeDetails?id=" + employeeId,
            success: function (data) {
                // Обновление части страницы с данными о сотруднике
                $("#employeeDetailsContainer").html(data);
            },
            error: function () {
                alert("Ошибка при получении информации о сотруднике.");
            }
        });
    }    
});