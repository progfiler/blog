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
// Start filter 
const categoryFilter = document.querySelector("#jsFilter")
const categoryFilterInstance = M.FormSelect.getInstance(categoryFilter)
const cards = document.querySelectorAll(".jsPostCard")
categoryFilter.addEventListener('change', () => {
    const categories = categoryFilterInstance.getSelectedValues()
    fetch(`https://localhost:44349/Filtered?ids=${categories.toString()}`)
        .then(response => response.json())
        .then(json => {
            const arrayOfId = []
            json.forEach(j => {
                arrayOfId.push(j.id)
            })
            cards.forEach(card => {
                let id = card.getAttribute("data-id")
                if (arrayOfId.includes(parseInt(id))) {
                    card.style.display = "block"
                } else {
                    card.style.display = "none"
                }
            })
        })
})


