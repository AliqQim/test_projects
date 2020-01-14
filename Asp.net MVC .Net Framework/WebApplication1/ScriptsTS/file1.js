function f() {
    $.ajax({
        url: "/Home/AjaxAction/",
        success: function (data) {
            alert("Age -  " + data.Ago + ", " + data.Date);
        },
        method: "post"
    });
}
