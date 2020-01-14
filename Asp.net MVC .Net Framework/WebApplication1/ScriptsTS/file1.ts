
declare let $;

function f() {
    $.ajax({
        url: "/Home/AjaxAction/",
        success: function (data: WebApplication1.Controllers.HomeController.AjaxDto) {
            alert(`Age -  ${data.Ago}, ${data.Date}`);
        },
        method: "post"
    });
}