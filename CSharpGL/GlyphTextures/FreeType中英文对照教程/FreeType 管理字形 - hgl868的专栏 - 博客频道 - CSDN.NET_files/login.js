/*
* CSDN 登录框
* Copyright 2012, zhuhz@csdn.net
* Date: 2012-6-6
* 
* 调用：csdn.showLogin(callback);
*
* 获取当前登录用户名（可用于判断用户是否处于登录状态）：csdn.getCookie('UserName')
*/
var csdn = window.csdn || function () { };

csdn.domain = "passport.csdn.net";
csdn.doing = false;
csdn.$ = function (id) {
    return document.getElementById(id);
};
csdn.loginBack = null;
csdn.showLogin = function (callback) {

    var div = document.createElement("DIV");
    div.id = "csdn_divh";
    //div.style.marginLeft = "-200px";
    div.style.marginTop = -75 + (document.documentElement.scrollTop || document.body.scrollTop) + "px";

    // var title = '登录<a class="close" href="javascript:void(0);" onclick="javascript:csdn.closeLogin();return false;" title="关闭窗口">[X]</a>';
    var title = '';
    var body = csdn.loginForm();
    var bottom = '';
    var s = csdn.openBox().replace('#title#', title).replace('#body#', body);
    div.innerHTML = s;

    csdn.shieldBody();
    document.body.appendChild(div);

    var un = csdn.getCookie("UN");
    if (un) {
        csdn.$('u').value = un;
        csdn.$('p').focus();
    }
    else {
        csdn.$('u').focus();
    }
    csdn.$('u').onkeypress =
    csdn.$('p').onkeypress = function (ev) {
        if (csdn.isEnter(ev)) {
            csdn.login();
        }
    };
    csdn.loginBack = callback;
};
csdn.closeLogin = function () {
    document.body.removeChild(csdn.$('csdn_divh'));
    document.body.removeChild(csdn.$('csdn_shield'));
};
csdn.shieldBody = function () {
    var shield = document.createElement("DIV");
    shield.id = "csdn_shield";
    var h1 = document.documentElement.clientHeight;
    var h2 = document.documentElement.scrollHeight;
    shield.style.height = Math.max(h1, h2) + "px";
    shield.style.filter = "alpha(opacity=0)";
    shield.style.opacity = 0;
    document.body.appendChild(shield);

    csdn.setOpacity = function (obj, opacity) {
        if (opacity >= 1) opacity = opacity / 100;
        try { obj.style.opacity = opacity; } catch (err) { }
        try {
            if (obj.filters.length > 0 && obj.filters("alpha")) {
                obj.filters("alpha").opacity = opacity * 150;
            } else {
                obj.style.filter = "alpha(opacity=\"" + (opacity * 150) + "\")";
            }
        } catch (err) { }
    };
    var c = 0;
    csdn.doAlpha = function () {
        c += 2;
        if (c > 20) { clearInterval(ad); return 0; }
        csdn.setOpacity(shield, c);
    };
    var ad = setInterval("csdn.doAlpha()", 1);
};
csdn.setStyle = function () {
    var lk = document.createElement("LINK");
    lk.type = "text/css";
    lk.rel = "stylesheet";
    lk.href = location.protocol + "//" + csdn.domain + "/content/loginbox/style.css?r=" + (new Date().getTime());
    var head = document.getElementsByTagName("head")[0];
    head.appendChild(lk);
};
csdn.isEnter = function (ev) {
    ev = ev || window.event;
    var code = (ev.keyCode || ev.which);
    return (code == 10 || code == 13);
};
csdn.getCookie = function (name) {
    var ck = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (ck) return ck[2];
    else return null;
};
csdn.setCookie = function (name, value, expires) {
    if (expires) expires = '; expires=' + new Date(expires).toUTCString();
    else expires = '';
    var path = '; path=/';
    var domain = '; domain=' + document.domain.replace('www.', '');

    document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain].join('');
}

csdn.openBox = function () {
    var text =
         "<div class='boxbody'>#body#</div>"

    return text;
};
csdn.loginForm = function () {
    var fromurl = encodeURIComponent(location.href);
    var text = "<div class='csdn_loginbox' style='z-index: 100'>"
+ "<div class='login_content'>"

+ "<input name='close' type='button' class='close'  onclick='javascript:csdn.closeLogin();return false;'  />"
+ "<p class='point' id='sperr'></p>"
+ "<input name='user_id'  id='u'  type='text' class='user_id' placeholder='用户ID/注册邮箱' />"
+ "<input name='password' id='p' type='password' class='password' placeholder='密码'/ >"
+ "<label><p class='remember clearfix'><input name='checkbox'  id='chkre' type='checkbox' value='checkbox' />记住我一周</p></label>"
+ "<div class='pw_lg'>"
+ "<a href='https://" + csdn.domain + "/account/forgotpassword' target='_blank' >忘记密码</a>|<a href='https://" + csdn.domain + "/account/register' target='_blank' class='pw_a'>注册</a>"
+ "</div>"
+ "<input name='button' type='button' onclick='javascript:csdn.login();return false;' value='登  录' class='login_bt'/>"
+ "<div class='lg_3 clearfix'>"
+ "<a href='https://" + csdn.domain + "/auth/baidu?from=" + fromurl + "' target='_blank' class='baidu'></a>"
+ "<a href='https://" + csdn.domain + "/auth/LinkedIn?from=" + fromurl + "' target='_blank' class='LinkedIn'></a>"
+ "<a href='https://" + csdn.domain + "/auth/Github?from=" + fromurl + "' target='_blank' class='github'></a>"
+ "<a href='https://" + csdn.domain + "/auth/google?from=" + fromurl + "' target='_blank' class='google'></a>"
+ "<a href='https://" + csdn.domain + "/auth/qq?from=" + fromurl + "' target='_blank' class='qq'></a>"
+ "<a href='https://" + csdn.domain + "/auth/sinat?from=" + fromurl + "' target='_blank' class='weibo'></a>"
+ "第三方登录："
+ "</div></div>"
+ "<iframe frameborder='no' allowtransparency='yes' style='position: absolute; width:100%; height: 311px; left: 0; top: 100px; border: 0; z-index: -1;'>"
+ "</div>";


    return text;
};

csdn.login = function () {
    if (csdn.doing) return;
    var u = csdn.$('u');
    var p = csdn.$('p');
    var er = csdn.$('sperr');
    if (!u.value) {
        er.innerHTML = '* 请输入用户名/邮箱。';
        return;
    }
    if (!p.value) {
        er.innerHTML = '* 请输入密码。';
        return;
    }
    csdn.doing = true;
    er.innerHTML = '正在登录...';
    var url = location.protocol + '//' + csdn.domain + '/ajax/accounthandler.ashx';
    var data = 't=log&u=' + encodeURIComponent(u.value)
        + '&p=' + encodeURIComponent(p.value)
        + '&remember=' + (csdn.$('chkre').checked ? 1 : 0)
        + '&callback=csdn.login_back'
        + '&r=' + (new Date().getTime());

    csdn.post(url + '?' + data);
};
csdn.login_back = function (data) {
    if (data.status) {
        var userName = data.data.userName;
        var userInfo = data.data.encryptUserInfo;
        var exp = csdn.$('chkre').checked ? 7 : 0;
        var url = location.protocol + '//' + csdn.domain + '/home/ssoindex'
            + '?userName=' + encodeURIComponent(userName)
            + '&userInfo=' + encodeURIComponent(userInfo)
            + '&exp=' + exp;

        csdn.load_frm(url, csdn.login_ok(data));
    } else {
        if (data.error.indexOf("激活") > -1) {
            csdn.$('sperr').innerHTML = '* 账户未激活，请先<a href="https://' + csdn.domain + '/account/active?from=' + encodeURIComponent(location + '') + '" target=_blank>激活</a>。';
        } else {
            csdn.$('sperr').innerHTML = '* ' + data.error;
        }
        csdn.doing = false;
    }
};
csdn.login_ok = function (data) {
    csdn.doing = false;
    csdn.$('sperr').innerHTML = '<span style="color:green;">登录成功！</span>';
    if (csdn.loginBack) csdn.loginBack(data);
    csdn.closeLogin();
};
csdn.post = function (url, callback) {
    var sc = document.createElement("script");
    sc.type = 'text/javascript';
    sc.async = true;
    sc.src = url;
    if (callback) {
        if (sc.onload) sc.onload = callback;
        else sc.onreadystatechange = callback;
    }
    document.body.appendChild(sc);
};
csdn.arr_isloaded = [];
csdn.load_frm = function (url, loaded) {
    var idx = csdn.arr_isloaded.length;
    csdn.arr_isloaded[idx] = false;
    var frm = document.createElement("iframe");
    frm.style.width = '1px';
    frm.style.height = '1px';
    frm.style.visibility = 'hidden';
    frm.src = url;
    if (loaded) {
        var call = function () {
            if (!csdn.arr_isloaded[idx]) {
                csdn.arr_isloaded[idx] = true;
                loaded();
            }
        };
        if (frm.onreadystatechange) {
            frm.onreadystatechange = call;
        } else {
            frm.onload = call;
        }
        setTimeout(call, 5000);
    }
    document.body.appendChild(frm);
};
/*加载样式表单*/
(function () {
    if (typeof jQuery != 'undefined') {
        jQuery(csdn.setStyle);
    } else {
        var ld = window.onload;
        window.onload = function () {
            if (ld) ld();
            csdn.setStyle();
        };
    }
})();


