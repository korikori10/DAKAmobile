﻿var EmpCont = new Object();
var contAmount = new Object();

$(document).ready(function () {
    //get contracts from sessin
    var results = JSON.parse(sessionStorage.getItem('contract'));
    //initiate signature plugin
    $("#signtaure").jSignature();
    //build docs display
    renderDocs(results);
    //create signature modal and canvas
    $('#sign').click(function () {
       
        $('#sigModal').modal('show');
     

    });
    $('#saveSig').click(function () {
        var datapair = $("#signature").jSignature("getData")
        var svg = datapair;//[0] + "," + datapair[1] 
        InsertSignature(svg, results, insertContract);
        
    });
    //$('#dltSig').click(function () {

    //    $('#bod').empty();
    //});
});
//build contract cards
function renderDocs(results) {
  
    $('#EmpDocs').attr('id');
    var doctype = "5";
    var dl = $('#DynamicDocsList');
    dl.empty();
    $.each(results, function (i, row) {
        var p = row.split('/');
        var name = p[p.length - 1];
        dynamicLi = '<a href="#" id="' + row + '" name="displayContract"><h3>' + name + '</h3>  <i class="icon-arrow-left"></i></a>';
        dl.append(dynamicLi);
    });
    $('[name="displayContract"]').on('click', function () {
        var url = $(this).attr("id");;
        window.open(url, '_blank', 'location=yes');
    });

    $.each(results, function (i, row) {

      
        if (i == 0) {
        
            $("#doc1").find('iframe').attr('id', 'docimg1');
            var img = $('#docimg1').attr('src', row);
   
        }
        else {
            id = createContractForm();
  
            var img = $("#" + id).find('iframe').attr('id', 'img' + id);
             $('#img' + id).attr('src', row);

        }

        // }

    });
}

function createContractForm() {
    // get the last DIV which ID starts with ^= "contact"
    var $div = $('div[id^="doc"]:last');

    // Read the Number from that DIV's ID (i.e: 3 from "klon3")
    // And increment that number by 1
    var num = parseInt($div.prop("id").match(/\d+/g), 10) + 1;
    var id = 'doc' + num;

    // Clone it and assign the new ID (i.e: from num 4 to ID "contact4")
    var docs = '<div class="docCards col-xl-4 col-md-6 col-xs-12" id="' + id + '">' + $div.html() + '</div>'; //$div.clone().prop('id', id);

    // Finally insert $klon wherever you want
    $(docs).insertBefore('#sign');
    //  $(contact).insertBefore('#addContact');
    // rolesSelect();
    return id;
}

//save all contracts with signature
function insertContract(results) {
    results = $.parseJSON(results.d);
    contAmount = results;
    EmpCont.Doctype_id = '5';
    EmpCont.Employee_pass_id = sessionStorage.getItem("empInfo");
    $.each(results, function (i, row) {

        EmpCont.Doc_id = EmpCont.Employee_pass_id + makeid();
        EmpCont.Img_url = row;
    InsertConts({ FileInfo: JSON.stringify(EmpCont) }, i, finished);

    })
    $('#sigModal').modal('toggle');
}

function finished(i) {

    if (contAmount.length <= (i + 1)) {

        swal({
            title: "בוצע!",
            text: "כל הנתונים נשמרו בהצלחה",
            type: "success",
            confirmButtonText: "חזור למסך הבית",
        },

            function (isConfirm) {

                window.location = "Dash.html"

            })
    }
};
//build signature canvas
$('#sigModal').on('shown.bs.modal', function (e) {
    $("#signature").jSignature();
    $("#signature").resize();
});
//random id for contract id
function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 5; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}