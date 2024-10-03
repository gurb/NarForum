console.log("---------------yüklendi");
export function BlazorScrollToId(id) {
    console.log("---------------divvvvv");
    const element = document.getElementById(id);
    console.log("---------------");
    console.log(element);
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