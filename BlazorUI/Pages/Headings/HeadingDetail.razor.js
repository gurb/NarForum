export function BlazorScrollToId(id) {
    const element = document.getElementById(id);
    if (element instanceof HTMLElement) {
        element.scrollIntoView({
            behavior: "smooth",
            block: "start",
            inline: "nearest"
        });
    }
}


export function GetBrowserName() {
    var BROWSER = new Array(
        ["Microsoft Edge", /edg/i],
        ["Microsoft Internet Explorer", /trident/i],
        ["Mozilla Firefox", /firefox|fxios/i],
        ["Opera", /opr\//i],
        ["UC Browser", /ucbrowser/i],
        ["Samsung Browser", /samsungbrowser/i],
        ["Google Chrome", /chrome|chromium|crios/i],
        ["Apple Safari", /safari/i],
        ["Unknown", /.+/i],
    ).find(([, value]) => value.test(window.navigator.userAgent)).shift();

    return BROWSER;
}