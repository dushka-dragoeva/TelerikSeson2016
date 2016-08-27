function checkIfMozilla() {
    var myWindow = window,
        currentBrowser = myWindow.navigator.appCodeName,
        isMozilla = currentBrowser === "Mozilla";

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}

checkIfMozilla();