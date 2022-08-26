var links = document.getElementsByClassName("nav-btn");
for (var i = 0; i < links.length; i++) {
    links[i].addEventListener("click", function () {
        document.getElementsByClassName("active")[0].classList.remove("active");
        links[i].classList.add("active");
    });
}