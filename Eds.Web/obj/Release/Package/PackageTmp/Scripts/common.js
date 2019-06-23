function $V(_1, _2) {
    if (IsNullOrEmpty(_1)) {
        return _2;
    }
    return _1;
}

function IsNullOrEmpty(_1) {
    if (_1 == null || _1 == undefined || _1 == '') {
        return true;
    }
    return false;
}
/*
提醒框:_1 状态码;_2 错误信息;_3:错误堆栈详情;_4:提示分组
*/
function AlterMessage(_1, _2, _3, _4) {
    alert(_2);
}

function JosnToDate(value) {
    var dateRegExp = /^\/Date\((.*?)\)\/$/;
    var date = dateRegExp.exec(value);
    return new Date(parseInt(date[1]));
}

//异步调用结束，分析调用是否成功
function OnAjaxActionEnd(responseJson) {
    if (responseJson == null || responseJson == undefined) {
        AlterMessage(1, "系统内部错误");
        return false;
    }
    var nRetCode = responseJson['RetCode'];
    if (nRetCode != '0') {
        AlterMessage(nRetCode, responseJson['RetInfo']);
        return false;
    }
    return true;
}
//异步调用
function OnAjaxAction(_1, _callback) {
    if ($V(_1.url) == '') {
        AlterMessage(1, "向服务器发送请求失败:Url地址为空!");
        return;
    }
    $.ajax({
        //async: _1.async,
        url: _1.url,
        type: $V(_1.type, 'POST'),
        //data: _1.params,
        dataType: "json",
        timeout: $V(_1.timeout, 30000),
        contentType: 'application/json',
        success: function (response) {
            var bSuccess = OnAjaxActionEnd(response);
            _callback({ success: bSuccess, result: response });
        },
        //通常情况下textStatus和errorThrown只有其中一个包含信息
        error: function (_1, _2) {
            AlterMessage(1, "向服务器发送请求失败:系统内部错误!");
            _callback({ success: false, result: '' });
        }
    });
}
/************tanyin add begin***************/
//Grid 全选事件
function selectAll() {
    var checklist = document.getElementsByName("selected");
    if (document.getElementById("check-all").checked) {
        for (var i = 0; i < checklist.length; i++) {
            $(checklist[i]).parent().parent().parent().addClass("k-state-selected");
            checklist[i].checked = 1;

        }
    } else {
        for (var j = 0; j < checklist.length; j++) {
            $(checklist[j]).parent().parent().parent().removeClass("k-state-selected");
            checklist[j].checked = 0;
        }
    }
}

function oncheck(checkboxobj) {

    //if ($(checkboxobj).attr("checked") == "checked") {
    //    $(checkboxobj).parent().parent().parent().addClass("k-state-selected");
    //}
    //else {
    //    $(checkboxobj).parent().parent().parent().removeClass("k-state-selected");
    //}
}

//JSON日期格式化,用法new Date()).Format("yyyy-MM-dd hh:mm:ss")= 2015-11-2 10:09:33
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
//获取url参数值
function getUrlParam(name) {
    //构造一个含有目标参数的正则表达式对象  
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    //匹配目标参数  
    var r = window.location.search.substr(1).match(reg);
    //返回参数值  
    if (r != null) return unescape(r[2]);
    return null;
}



function returnLoginUrl()
{
    if (window.location.href.indexOf('Login') >= 0) {
        window.location.href = '/Login/Index';
    }
    else {
        window.location.href = '/Login/Index?returnUrl="' + window.location.href+'"';
    }

}
/************tanyin add end***************/
