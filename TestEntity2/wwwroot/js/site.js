// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const toastComponent = document.querySelector("#toastComponent")
if (toastComponent) {
    const isSave = toastComponent.getAttribute("data-save")
    if (isSave) {
        if (isSave > 0) {
            const message = toastComponent.getAttribute("data-message")
            M.toast({ html: message })

        }
    }
}

