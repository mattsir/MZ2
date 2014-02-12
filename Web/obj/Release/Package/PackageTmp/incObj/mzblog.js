function closepage() {
    $.fancybox.close();    //fancybox关闭窗口
    //Lightview.hide();   //关闭弹出窗口
}

function reloadpage() {
    window.parent.location.reload();
    $.fancybox.close();    //关闭弹出窗口
}

function SendParaToPage(conid, str) {
    document.getElementById(conid).value = str;
    $.fancybox.close();    //关闭弹出窗口
}