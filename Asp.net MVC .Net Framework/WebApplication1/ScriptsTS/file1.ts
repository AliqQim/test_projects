
declare let $;

export class AjaxDto {
    public Date: string;
    public Age: number;
}

function f() {
    $.ajax({
        url: "/Home/AjaxAction/",
        success: function (data: AjaxDto) {
            alert(`Age -  ${data.Age}, ${data.Date}`);
        },
        method: "post"
    });
}