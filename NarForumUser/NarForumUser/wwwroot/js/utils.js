function GetBrowserName() {
    var BROWSER = new Array(
        ["Edge", /edg/i],
        ["Internet Explorer", /trident/i],
        ["Firefox", /firefox|fxios/i],
        ["Opera", /opr\//i],
        ["UC Browser", /ucbrowser/i],
        ["Samsung Browser", /samsungbrowser/i],
        ["Chrome", /chrome|chromium|crios/i],
        ["Safari", /safari/i],
        ["Others", /.+/i],
    ).find(([, value]) => value.test(window.navigator.userAgent)).shift();

    return BROWSER;
}

function SetCookiePolicyAccepted() {
    localStorage.setItem('CookiePolicyAccepted', "true");
}

function SetCookiePolicyRejected() {
    localStorage.setItem('CookiePolicyAccepted', "false");
}

function GetCookiePolicyAccepted() {
    const cookiePolicy = localStorage.getItem('CookiePolicyAccepted');
    if (cookiePolicy === "true" || cookiePolicy === "false") {
        return cookiePolicy;
    }
    else {
        return null;
    }
}

function setTheme(theme) {
    document.querySelector("html").setAttribute("data-theme", theme);
}

var theme = localStorage.getItem('theme');
if (theme != null) {
    setTheme(theme);
}
