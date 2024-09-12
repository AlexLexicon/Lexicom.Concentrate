window.lexicomConcentrateAmenitiesRegisterKeyboardCallback = (keyboardServiceReference) => {
    window.document.addEventListener('keydown', function (e) {
        keyboardServiceReference.invokeMethodAsync('OnJsInvokeAsync', e.key)
    });
}