let mediaQuery;
export function RegisterChangeCallback(dotnetHelper) {
    window.addEventListener('resize', () => {
        dotnetHelper.invokeMethodAsync('OnResize');
    });
}

export function MinWidthPx(px) {
    mediaQuery = window.matchMedia("(min-width:" + px + "px)");
}

export function CheckQuery() {
    if (mediaQuery != null) {
        return handleMediaQueryChange(mediaQuery);
    }
    return false;
}

function handleMediaQueryChange(e) {
    if (e.matches) {
        console.log(true);
        return true;

    } else {
        console.log(false);
        return false;
    }
}
