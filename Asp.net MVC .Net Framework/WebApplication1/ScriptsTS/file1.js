"use strict";
exports.__esModule = true;
var AjaxDto = /** @class */ (function () {
    function AjaxDto() {
    }
    return AjaxDto;
}());
exports.AjaxDto = AjaxDto;
function f() {
    $.ajax({
        url: "/Home/AjaxAction/",
        success: function (data) {
            alert("Age -  " + data.Age + ", " + data.Date);
        },
        method: "post"
    });
}
