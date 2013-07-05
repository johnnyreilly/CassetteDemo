/// <reference path="../../typings/jquery/jquery.d.ts" />
// @reference ~/bundles/core

$(document).ready(function () {

    var $body = $("#body");

    $body.fadeOut(1000, function () {

        $body.html('<div style="width: 150px; margin: 0 auto;">I made it all go away...</div>')
            .fadeIn();
    
    });
});