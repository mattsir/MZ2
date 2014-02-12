function head(boardid) {
    //var id = getQueryStringRegExp("id");
    //alert(id);
    switch (boardid) {
        case "3":
            document.getElementById("menutitle").innerHTML = "<a href=\"/html.html?id=3\" title=\"生活\"><img src=\"/images/icon_life32.png\"  border=\"0\" /></a>";
            var menu = "<a href=\"/html.html?id=4\" title=\"八卦\"><img src=\"/images/icon_Gossip32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";

            menu = menu + "<a href=\"/html.html?id=5\" title=\"源码\"><img src=\"/images/icon_code32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html.html?id=6\" title=\"图片\"><img src=\"/images/icon_pic32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html/2011/147.html\" title=\"关于我\"><img src=\"/images/icon_me32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a> ";
            menu = menu + "<a href=\"/html/2011/149.html\" title=\"关于她\"><img src=\"/images/icon_she32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            document.getElementById("menubox").innerHTML = menu;
            break;
        case "4":
            document.getElementById("menutitle").innerHTML = "<a href=\"/html.html?id=4\" title=\"八卦\"><img src=\"/images/icon_Gossip32.png\"  border=\"0\" /></a>";
            var menu = "<a href=\"/html.html?id=3\" title=\"生活\"><img src=\"/images/icon_life32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";

            menu = menu + "<a href=\"/html.html?id=5\" title=\"源码\"><img src=\"/images/icon_code32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html.html?id=6\" title=\"图片\"><img src=\"/images/icon_pic32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html/2011/147.html\" title=\"关于我\"><img src=\"/images/icon_me32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a> ";
            menu = menu + "<a href=\"/html/2011/149.html\" title=\"关于她\"><img src=\"/images/icon_she32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            document.getElementById("menubox").innerHTML = menu;
            break;
        case "5":
            document.getElementById("menutitle").innerHTML = "<a href=\"/html.html?id=5\" title=\"源码\"><img src=\"/images/icon_code32.png\"  border=\"0\" /></a>";
            var menu = "<a href=\"/html.html?id=3\" title=\"生活\"><img src=\"/images/icon_life32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";

            menu = menu + "<a href=\"/html.html?id=4\" title=\"八卦\"><img src=\"/images/icon_Gossip32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html.html?id=6\" title=\"图片\"><img src=\"/images/icon_pic32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html/2011/147.html\" title=\"关于我\"><img src=\"/images/icon_me32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a> ";
            menu = menu + "<a href=\"/html/2011/149.html\" title=\"关于她\"><img src=\"/images/icon_she32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            document.getElementById("menubox").innerHTML = menu;
            break;
        case "6":
            document.getElementById("menutitle").innerHTML = "<a href=\"/html.html?id=6\" title=\"图片\"><img src=\"/images/icon_pic32.png\"  border=\"0\" /></a>";
            var menu = "<a href=\"/html.html?id=3\" title=\"生活\"><img src=\"/images/icon_life32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";

            menu = menu + "<a href=\"/html.html?id=4\" title=\"八卦\"><img src=\"/images/icon_Gossip32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html.html?id=5\" title=\"源码\"><img src=\"/images/icon_code32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html/2011/147.html\" title=\"关于我\"><img src=\"/images/icon_me32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a> ";
            menu = menu + "<a href=\"/html/2011/149.html\" title=\"关于她\"><img src=\"/images/icon_she32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            document.getElementById("menubox").innerHTML = menu;
            break;
        default:
            var menu = "<a href=\"/html.html?id=3\" title=\"生活\"><img src=\"/images/icon_life32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";

            menu = menu + "<a href=\"/html.html?id=4\" title=\"八卦\"><img src=\"/images/icon_Gossip32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html.html?id=5\" title=\"源码\"><img src=\"/images/icon_code32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html.html?id=6\" title=\"图片\"><img src=\"/images/icon_pic32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            menu = menu + "<a href=\"/html/2011/147.html\" title=\"关于我\"><img src=\"/images/icon_me32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a> ";
            menu = menu + "<a href=\"/html/2011/149.html\" title=\"关于她\"><img src=\"/images/icon_she32.png\" alt=\"\" border=\"0\" style=\"padding-left:20px;\" /></a>";
            document.getElementById("menubox").innerHTML = menu;
            break;
    }
}