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
    return true;
}

function handleMediaQueryChange(e) {
    if (e.matches) {
        return true;
    } else {
        return false;
    }
}
