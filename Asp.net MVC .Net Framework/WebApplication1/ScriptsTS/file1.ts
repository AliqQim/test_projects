
declare let $;

function f() {
    $.ajax({
        url: "/Home/AjaxAction/",
        success: function (data: amoduleaaWebApplication1.Controllers.HomeControllerqqq.AjaxDto) {
            alert(`Age -  ${data.Age}, ${data.Date}`);
        },
        method: "post"
    });
}