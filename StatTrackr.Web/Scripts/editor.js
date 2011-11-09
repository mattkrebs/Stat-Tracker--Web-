

$(function () {
    $('#dialog').dialog({
        autoOpen: false,
        width: 600,
        resizable: false,
        title: 'Edit Item',
        url: "",
        modal: true,
        position: [null, 100],
        buttons: {
            "Save": function () {
                    $("#dialog form").submit();
                
            },
            //            "Save & Publish": function () {
            //                $("#publish").val(true);
            //                $("#dialog form").submit();
            //            },
            "Close": function () {
                $(this).html("");
                $(this).dialog("close");
            }
        }
    });

});