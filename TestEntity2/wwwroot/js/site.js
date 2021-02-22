// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

M.AutoInit();


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

// Toggle Msg when delete Action 
const jsDeletePosts = document.querySelectorAll(".jsDeletePosts")
console.log(jsDeletePosts)
if (jsDeletePosts.length > 0) {
    jsDeletePosts.forEach(btn => {
        btn.addEventListener('click', (e) => {
            const del = confirm("Voulez-vous vraiment supprimer cet article ?")
            if (!del) {
                e.preventDefault()
            }
        })
    })
} 