function colorChange() {
    var x = document.getElementById("colorSel");
    var result = x.options[x.selectedIndex].text;
    document.getElementById("demo").innerHTML = "<div style='border-radius:15px;box-shadow:2px 2px 2px silver;border-radius:4px;width:45px;height:20px;background-color:" + result + "'></div>";
}

function iframeChange() {
    var result = document.getElementById("iframeId").value;
    document.getElementById("pDemo").innerHTML = "<iframe src=" + result + " height='200' width='400'></iframe>";
}


var openDivBtn = document.getElementById("subAdd").style.display;
function subAdd() {
    if (openDivBtn == "none") {
        document.getElementById("subAdd").style.display = "block";
        document.getElementById("newSubCat").innerHTML = "Bağla";
        document.getElementById("newSubCat").className = "btn btn-danger";
    }
    else {
        document.getElementById("subAdd").style.display = "none";
        document.getElementById("newSubCat").innerHTML = "Yeni";
        document.getElementById("newSubCat").className = "btn btn-success";
    }
}

function openEditBtn() {
    document.getElementById("subAdd").style.display = "block";
    document.getElementById("newSubCat").innerHTML = "Bağla";
    document.getElementById("newSubCat").className = "btn btn-danger";
}

function openNav() {
    var x = document.getElementById("mySidebar").style.width;
    if (x == "0px") {
        document.getElementById("mySidebar").style.width = "270px";
        document.getElementById("main").style.marginLeft = "270px";
    } else {
        document.getElementById("mySidebar").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";

    }
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}


var element = document.getElementsByClassName("btnItem");
var onElement;
var subBtnsrc;
function myConfirm(value) {
    if (value == 'Bəli') {
        if (element != null) {
            element[onElement - 1].href = element[onElement - 1].getAttribute('data-cmd');
            subBtnsrc = element[onElement - 1];
        }
    }
    else {
        var result = document.getElementById("closeBtn");
        result.click();
    }
}
function subBtnFnc(value) {
    myConfirm(value);
    var test = value;
    alert(test);
    document.getElementById('subBtn').href = subBtnsrc;
}

function slctBtn(value) {
    onElement = value;
}
