$(document).ready(function () {
    var contract = sessionStorage.getItem('contract')
    $("#signtaure").jSignature();
    //$('#contractDisplay').attr('src', "http://docs.google.com/gview?url="+ contract +"&embedded=true");
});

 function sign () {
    $('#sigModal').modal('show');
    //var $sigdiv = $("#signature")
    // $sigdiv.jSignature() // inits the jSignature widget.
   //  $sigdiv.jSignature("reset")
};

$('#sigModal').on('shown.bs.modal', function (e) {
    $("#signature").jSignature();
    $("#signature").resize();
});