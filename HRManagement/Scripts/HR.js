$(document).ready(function () {
    changeButtonsLook();

    $("#datepicker").datepicker(
    {
        onSelect: registerDay,
        minDate: new Date()
    });

    $("img.close-button").live("click", function () {
        var elementClicked = this;
        var date = $(elementClicked).siblings(".list-date").text();
        var dateArray = date.split(".");

        $.ajax(
        {
            url: "leave/removeDay",
            data: "day=" + parseInt(dateArray[0]) + "&month=" + parseInt(dateArray[1]) + "&year=" + parseInt(dateArray[2]),
            type: "POST",
            complete: function () {
                $(elementClicked).parent().hide();
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

    $("#requestForm").live("submit", function (event) {
        event.preventDefault();
        var typeRequest = $("#requestForm :selected").val();
        var user_comment = $('#requestForm textarea').val();

        $('#sendRequest').attr('disabled', 'disabled');
        $.ajax({
            url: $(this).attr('action'),
            type: "POST",
            data: "type=" + typeRequest + "&user_comment=" + user_comment,
            complete: function (xhr) {
                $('#ajaxMessage').text(xhr.responseText);
                $('#sendRequest').removeAttr('disabled');
                reloadMyRequests();
            }
        });

        return false;
    });

    $("a.actionClass").live("click", function (event) {
        event.preventDefault();
        var el = $(this);
        $("#request_info").html("<img src='../../Content/images/ajax-loader.gif' />");
        $.ajax({
            url: el.attr("href"),
            type: "GET",
            complete: function (xhr) {
                $('#request_info').replaceWith(xhr.responseText);
                changeButtonsLook();
                cancelAndRemoveEvents();
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }
        })

    });

    $("#myRequestEdit").live("submit", function (event) {
        event.preventDefault();
        var el = $(this); submitButton
        $('#submitButton').attr('disabled', 'disabled');
        $.ajax({
            url: "leave/edit",
            type: "POST",
            data: "id=" + parseInt($("#LeaveRequest_Id").val())
                    + "&type=" + parseInt($("#RequestType").val())
                    + "&comment=" + $("#LeaveRequest_Comment").val(),
            complete: function (xhr) {
                console.log(xhr);
                $('#submitButton').removeAttr('disabled');
                $("#request_info").html(xhr.responseText);
            }
        });
    });

    function changeButtonsLook() {
        $("input[type='button'], input[type='submit']").button();
    }

    function cancelAndRemoveEvents() {
        $("#cancelButton").live("click", function (event) {
            event.preventDefault();
            var requestInfoContents = $("#request_info").html();
            $("#request_info").html("<div id='temporarDivForAnime'>" + requestInfoContents + "</div>");
            $("#temporarDivForAnime").hide("blind");
        })
        $("#removeButton").live("click", function (event) {
            event.preventDefault();
            $('#removeButton').attr('disabled', 'disabled');
            $.ajax({
                url: "leave/remove",
                type: "POST",
                data: "id=" + parseInt($("#LeaveRequest_Id").val()),
                complete: function (xhr) {
                    console.log(xhr);
                    if (1 == xhr.responseText) {
                        $("#request_info").html("Leave request removed.");
                        reloadMyRequests();
                    }
                    else {
                        $("#request_info").html("Leave request could not be removed.");
                    }
                }

            });
        })
    }

    function reloadMyRequests() {
        $("table.myRequests").html("<img src='../../Content/images/ajax-loader.gif' />");
        $.ajax({
            url: "leave/MyRequests",
            type: "GET",
            complete: function (xhr) {
                $("table.myRequests").replaceWith(xhr.responseText);
            }
        });
    }
})

