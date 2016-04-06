/// <reference path="jquery-1.6.4.js" />
(function ($) {

    $.fn.suggestAlias = function () {

        if (this.length < 1)
            return;

        $(this).blur(function () {
            var aliasInput = $('#Alias');

            if (aliasInput.val() != '')
                return;
//            var result = "";
//            $.each($(this).val().split(' '),
//                function (index, value) {
//                    result += value.charAt(0).toUpperCase();
//                }
//            );
            aliasInput.val($(this).val());
        });
    }
})(jQuery);

$(document).ready(function () {
    if ($(".numeric").length != 0)
        $(".numeric").numeric();
    if ($(".integer").length != 0)
        $(".integer").numeric(false);
    if ($(".decimal").length != 0)
        $(".decimal").numeric({ decimal: '.', negative: false });
    if ($(".positive").length != 0)
        $(".positive").numeric({ negative: false });
    if ($(".positive-integer").length != 0)
        $(".positive-integer").numeric({ decimal: false, negative: false });

    $("#Nombre").suggestAlias();
});


function getQueryStringParameter(name) {

    var match = RegExp('[?&]' + name + '=([^&]*)')
                    .exec(window.location.search);

    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));

}

function doListBoxFilter(listBoxName, filter, options) {
    var list = $('#' + listBoxName);

    list.empty();

    if (filter == '') {
        list.append(options);
        list.val(null);
        return;
    }

    var temp = [];
    var option;
    for (var i = 0; i < options.length; i++) {
        option = options[i];
        if (option && option.innerText.toLowerCase().indexOf(filter.toLowerCase()) !== -1) {
            temp.push(option);
        }
    }
    // we got all the options, now append to DOM 
    list.append(temp);

    if (temp.length == 1) {
        list.val(temp[0].value);
    }
    else {
        list.val(null);
    }

    list.change();
}

function postCurrentForm(actionLink) {
    var form = $('form:first');

    var currentAction = form.attr('action');

    form.attr('action', actionLink.attr('href'));
    form.submit();

    form.attr('action', currentAction);

    return false;
}

function postForm(actionLink, formId) {
    var form = $('#' + formId);

    var currentAction = form.attr('action');

    form.attr('action', actionLink.attr('href'));
    form.submit();

    form.attr('action', currentAction);

    return false;
}

function resizeContent() {

    var navigationSize = getNavigationSize();
    var target_height = navigationSize == 0 ? $('#navigationWrapper').height() : navigationSize + 50;

    if (target_height < $('#workspace').height())
        target_height = $('#workspace').height()

    if (target_height < $('#actionsWrapper').height())
        target_height = $('#actionsWrapper').height()

    $('#workspace').height(target_height);
//    $('#navigationWrapper').height(target_height);
    $('#actionsWrapper').height(target_height);
}

function getNavigationSize() {
    var size = 0;

    $.each($(".navigationFirst"), function (key, value) {
        size += $(value).height();
    });

    return size;
}

$(window).resize(function () {
    resizeContent();
    $(".navigation_list").click(resizeContent);
})
$(document).ready(function () {
    resizeContent();
    $(".navigation_list").click(resizeContent);
    //$('#searchBox').focus();
})
