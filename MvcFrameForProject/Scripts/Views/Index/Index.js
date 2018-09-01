//提交
$("#save").bind("click", function () {
    $("body").mLoading();
    var sub=$.post(
        "/Index/LoginApi",
        {
            //用户名
            Username: $("#username").val(),
            //密码
            Passwd: $("#passwd").val(),
            //验证码
            VerificationCode: $("#text").val(),
        });
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
        
});

//获取验证码
function Imgnew(){
    $("#img").attr("src", '/index/ImgApi?t=' + Math.random());
}

//页面加载事件
$(function () {
    Imgnew();
})

