

window.onclick = function (event) {
    if (!event.target.matches('.dropth') ){
        var dropdowns = document.getElementsByClassName("dropdown-menu");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
        /*console.log("clicked")*/
    }
}

function myFunction(event) {
    var dropdowns = document.getElementsByClassName("dropdown-menu");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('show')) {
            openDropdown.classList.remove('show');
        }
    }
    event.target.nextElementSibling.classList.toggle("show");
   // console.log(element);
    //document.getElementById("dairy").classList.toggle("show");


}
