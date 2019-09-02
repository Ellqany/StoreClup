function filterFunction(id, mid) {
    var input, filter, ul, li, a, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    div = document.getElementById(id);
    a = div.getElementsByTagName(mid);
    for (i = 0; i < a.length; i++) {
        if (a[i].innerHTML.toUpperCase().indexOf(filter) > -1) {
            a[i].style.display = "";
        } else {
            a[i].style.display = "none";
        }
    }
}

function FilterDivItem(inputid, listid) {
    // Declare variables
    var input, filter, div, li, a, i;
    input = document.getElementById(inputid);
    filter = input.value.toUpperCase();
    div = document.getElementById(listid);
    li = div.getElementsByTagName('div');

    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("p")[0];
        if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function readIMG(input, demo, img) {
    if (input.files && input.files[0]) {
        var mimeType = input.files[0]['type'];
        if (mimeType.split('/')[0] === 'image') {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(demo).attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
            document.getElementById(img).innerHTML = '';
        } else {
            document.getElementById(img).innerHTML = "Please Choose Image to upload.";
            $(input).val(null);
        }

    }
}

//Slide Show

var slideIndex = 0;

carousel();

function plusDivs(n) {
    showDivs(slideIndex += n);
}

function currentDiv(n) {
    slideIndex = n;
    showDivs(slideIndex);
}

function showDivs(n) {
    var i;
    var x = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("demo");
    if (n > x.length) { slideIndex = 1; }
    if (n < 1) { slideIndex = x.length; }
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" w3-blue", "");
    }
    x[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " w3-blue";
}

function carousel() {
    slideIndex++;
    showDivs(slideIndex);
    setTimeout(carousel, 9000);
}