// JavaScript source code

function _ClickON_TheButton() {
    var currentWindow = window,
        currentBrowser = currentWindow.navigator.appCodeName,
        isMozilla = browser == "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}

_ClickON_TheButton();
