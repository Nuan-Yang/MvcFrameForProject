//注销
function delCookie() {
    $("body").mLoading();
    var sub=$.post(
        "/Index/DelCookieApi",
        null,
        function (data) {

        }
        );

//等待返回参数
$.when(sub).done(function (data) {
    $("body").mLoading("hide");
    if (data.status)
        window.location.href = data.url;
    else
        spop({
            template: data.mess,
            group: 'submit-satus',
            style: 'error',
            autoclose: 1500,
        });
});
}
