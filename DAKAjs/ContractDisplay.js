$(document).ready(function () {
    var contract = sessionStorage.getItem('contract')
    $("#signtaure").jSignature();
    //$("#signtaure").jSignature("reset");
    $('#contractDisplay').attr('src',  contract );
    $('#saveSig').click(function () {
        var datapair = $("#signature").jSignature("getData")
        var svg = datapair;//[0] + "," + datapair[1] 
        InsertSignature(svg, contract);
    });
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
