$(document).ready(function () {
    $("#datepicker").datepicker(
    {
        onSelect: registerDay
    });

    $(".listElementRequest span.close-button").live("click", function () {
        var elementClicked = this;
        var date = $(elementClicked).siblings(".list-date").text();
        var dateArray = date.split(".");
        console.log(dateArray);

        $.ajax(
        {
            url: "leave/removeDay",
            data: "day=" + parseInt(dateArray[0]) + "&month=" + parseInt(dateArray[1]) + "&year=" + parseInt(dateArray[2]),
            type: "POST",
            complete: function () {
                $(elementClicked).parent().hide("blind");
            },
            error: function () {
                $(this).hide();
            }
        });
    });

    function registerDay(dateText, inst) {
        $.ajax(
        {
            url: "leave/register",
            data: "day=" + inst.selectedDay + "&month=" + inst.selectedMonth + "&year=" + inst.selectedYear,
            type: "POST",
            complete: function (xhr) {
                $("#daysRequested").replaceWith(xhr.responseText);
            }
        });

    }

    $("#requestForm").submit(function () {
        var typeRequest = $("#requestForm :selected").val();
        var user_comment = $('#requestForm textarea').val();
        $.ajax({
            url: "leave/saveRequest",
            type: "POST",
            data: "type=" + typeRequest + "&user_comment=" + user_comment,
            complete: function(xhr){
                console.log(xhr);
            }
        });

        return false;
    });

})