
function LoadingOverlayShow(id)//PARA CARGAR EL LOADING
{
    $(id).LoadingOverlay("show", {
        color: "rgba(255,255,255,0.5)",
        image: "/Content/loadingg.gif",
        imageResizeFactor: 0.7,
    });
}

function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}


