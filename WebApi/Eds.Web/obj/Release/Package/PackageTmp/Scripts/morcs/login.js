$(function () {
    document.onkeydown = function (evt) {
        var evt = window.event ? window.event : evt;
        if (evt.keyCode == 13) {
            onLogin();
        }
    }
    Getimgsrc();
    if (document.getElementById('userCode')) {
        document.getElementById('userCode').focus();
    }
    $("#Verify").click(function () {
        Getimgsrc();
    });
});
function onLogin() {
    var userCode = document.getElementById("userCode").value;
    if (userCode.length <= 0) {
        swal("","请输入飞行网账号登录!");
        $("#userCode").focus();
        return false;
    }

    var password = document.getElementById("password").value;
    if (password.length <= 0) {
        swal("", "请输入密码!");
        $("#password").focus();
        return false;
    }
    var inputCheckCode = document.getElementById("inputCheckCode").value;
    if (inputCheckCode.length <= 0) {
        swal("", "请输入验证码!");
        $("#inputCheckCode").focus();
        return false;
    }
    $.ajax({
        type: "Get",
        url: "/Login/GetLogin",
        data: { userCode: userCode, password: password, inputCheckCode: inputCheckCode, r: Math.random() },
        dataType: "text",
        async: false,
        success: function (data) {
            if (data == "001") {
                swal("", "验证码错误!");
                $("#inputCheckCode").focus();
            }
            else if (data == "0") {
                var returnUrl = getUrlParam("returnUrl");
                if (returnUrl == null) {
                    window.location.href = '/Flight/Index';
                }
                else {
                    window.location = returnUrl;
                }
            }
            else if (data == "501") {
                swal("", "用户名或密码错误!");
                Getimgsrc();
            }
            else if (data == "101") {
                swal("", "您没有权限访问,请联系管理员!");
                Getimgsrc();
            }
            else {
                swal("", "系统内部错误!");
                Getimgsrc();
            }
        }
    });
}

function Getimgsrc() {
    $("#Verify").attr("src", "/Login/GetValidateCode?timestamp=" + new Date().getTime());
}