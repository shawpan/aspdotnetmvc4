﻿$(function () {

    var ajaxFormSubmit = function () {

        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-cp-target"));
            var $newData = $(data);
            $target.replaceWith($newData);
            $newData.effect("highlight");
        });

        return false;
    };
    var submitAutoCompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        $form = $input.parent("form:first");
        $form.submit();
    }
    var createAutoComplete = function () {
        var $input = $(this);

        var options =
            {
                source: $input.attr("data-cp-autocomplete"),
                select: submitAutoCompleteForm
            };
        $input.autocomplete(options);
    };
    var getPage = function () {
        $anchorTag = $(this);
        var options =
            {
                url: $anchorTag.attr("href"),
                type: "get",
                data:$("form").serialize()
            };
        $.ajax(options).done(function (data) {
            var $target = $($anchorTag.parents("div.pagedList").attr("data-cp-target"));
            $target.replaceWith(data);
        });
        return false;
    }

    $("form[data-cp-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-cp-autocomplete]").each(createAutoComplete);
    $(".main-content").on("click", ".pagedList a", getPage);
});