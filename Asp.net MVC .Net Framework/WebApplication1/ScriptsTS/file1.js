function f() {
    $.ajax({
        url: "/Home/AjaxAction/",
        success: function (data) {
            alert("Age -  " + data.Age + ", " + data.Date);
        },
        method: "post"
    });
}
