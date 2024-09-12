window.clipboard = {
    read: function () {
        return navigator.clipboard.readText();
    },
    write: function (text) {
        navigator.clipboard.writeText(text);
    }
};