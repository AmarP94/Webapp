$(document).ready(function () {



    tinymce.init({
        selector: 'textarea',
        plugins: [
            "advlist autolink lists link image charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste"
        ],
        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link"
    });

    SetSortable();
    //Delete foto from gallery in edit obavijesti
    SetConfirmDeleteFoto();
    SetConfirmDeleteDoc();
    SetConfirmDeleteDocI();
    SetConfirmDeleteDocL();
    SetConfirmDeleteDocZ();
    SetConfirmDeleteDocR();
    SetConfirmDeleteDocNa()

    $('#btnYesDocR').click(function () {
        var id = $('#ModalDeleteDocR').data('id');
        $.ajax({
            type: "POST",
            url: "/Registri/DeleteDoc",
            type: "GET",
            traditional: true,
            data: {
                idDoc: id,
                idRegistra: $('#idRegistra').val()
            },
            success: function (data) {
                $("#UpdateDocR").html(data);
            }
        });
        $('#ModalDeleteDocR').modal('hide');
    });

    $('#btnYes').click(function () {
        var id = $('#ModalDeleteFoto').data('id');
        $.ajax({
            type: "POST",
            url: "/Obavijesti/DeleteFoto",
            type: "GET",
            traditional: true,
            data: {
                idFoto: id,
                idObavijesti: $('#idObavijesti').val()
            },
            success: function (data) {
                $("#UpdateGallery").html(data);
            }
        });
        $('#ModalDeleteFoto').modal('hide');
    });

    $('#btnYesDoc').click(function () {
        var id = $('#ModalDeleteDoc').data('id');
        $.ajax({
            type: "POST",
            url: "/Obavijesti/DeleteDoc",
            type: "GET",
            traditional: true,
            data: {
                idDoc: id,
                idObavijesti: $('#idObavijesti').val()
            },
            success: function (data) {
                $("#UpdateDoc").html(data);
            }
        });
        $('#ModalDeleteDoc').modal('hide');
    });
    $('#btnYesDocI').click(function () {
        var id = $('#ModalDeleteDocI').data('id');
        $.ajax({
            type: "POST",
            url: "/Dokumenti/DeleteDoc",
            type: "GET",
            traditional: true,
            data: {
                idDoc: id,
                idDokumenti: $('#idDokumenti').val()
            },
            success: function (data) {
                $("#UpdateDocI").html(data);
            }
        });
        $('#ModalDeleteDocI').modal('hide');
    });
    $('#btnYesDocNa').click(function () {
        var id = $('#ModalDeleteDocNa').data('id');
        $.ajax({
            type: "POST",
            url: "/Nostrifikacije/DeleteDoc",
            type: "GET",
            traditional: true,
            data: {
                idDoc: id,
                idNostrifikacije: $('#idNostrifikacije').val()
            },
            success: function (data) {
                $("#UpdateDocNa").html(data);
            }
        });
        $('#ModalDeleteDocNa').modal('hide');
    });

    $('#btnYesDocL').click(function () {
        var id = $('#ModalDeleteDocL').data('id');
        $.ajax({
            type: "POST",
            url: "/Konkursi/DeleteDoc",
            type: "GET",
            traditional: true,
            data: {
                idDoc: id,
                idKonkursa: $('#idKonkursa').val()
            },
            success: function (data) {
                $("#UpdateDocL").html(data);
            }
        });
        $('#ModalDeleteDocL').modal('hide');
    });
    $('#btnYesDocZ').click(function () {
        var id = $('#ModalDeleteDocZ').data('id');
        $.ajax({
            type: "POST",
            url: "/Zajmovi/DeleteDoc",
            type: "GET",
            traditional: true,
            data: {
                idDoc: id,
                idZajma: $('#idZajma').val()
            },
            success: function (data) {
                $("#UpdateDocZ").html(data);
            }
        });
        $('#ModalDeleteDocZ').modal('hide');
    });

    paginantionPage();

});
function paginantionPage() {
    debugger;
    if ($('#pagination-container')[0]) {
        var url = window.location.href;
        url = url.substr(0, url.lastIndexOf('/')) + '/GetData';
        $('#pagination-container').pagination({

            dataSource: url,
            totalNumberLocator: function (response) {
                // you can return totalNumber by analyzing response content
                return response.total;
            },
            ajax: {
                beforeSend: function () {
                    $('#data-container').html('Učitavam podatke sa servera ...');
                }
            },
            callback: function (data, pagination) {
                debugger;
                // template method of yourself
                var html = simpleTemplating(data);
                $('#data-container').html(html);
            },
            pageSize: 10,
            locator: 'items'
        });
    }
}
function simpleTemplating(data) {
    var keys = Object.keys(data[0]);
    var url = window.location.href;
    url = url.substr(0, url.lastIndexOf('/'))
    var html = '<table class="table table-hover container"><tr>';
    for (var i = 1; i < keys.length; i++) {
        html += '<th>' + keys[i] + '</th>';
    }
    html += '<th>Akcije</th></tr>';
    for (var i = 0; i < data.length; i++) {
        html += '<tr>';
        for (var z = 1; z < keys.length; z++) {
            if (data[i][keys[z]]) {
                html += '<td>' + data[i][keys[z]] + '</td>';
            } else {
                html += '<td></td>';
            }
           
        }
        html += '<td> <a href="' + url + '/Edit/' + data[i][keys[0]] + '">Izmjena</a> | <a href="' + url + '/Delete/" onclick="return confrmBrisat(this)" id="' + data[i][keys[0]] +'">Brisati</a>' +'</td>';
        html += '</tr>';
    }
    
    html += '</table>';
    return html;
}
debugger;
//===========================//


//Validacija obavijesti
function validateNaslov() {

    $("#naslov").closest("div").removeClass("has-error");
    if (!$.trim($("#newObavijest input[name=naslov]").val())) {
        $("#newObavijest input[name=naslov]").closest("div").addClass("has-error");
        return false;
    }
    else {
        return true;
    }

}

function validateNaslovI(id) {

    $("#naslov").closest("div").removeClass("has-error");
    if (!$.trim($(id + " input[name=naslov]").val())) {
        $(id + " input[name=naslov]").closest("div").addClass("has-error");
        return false;
    }
    else {
        return true;
    }

}
function checkEmail(email) {
    var filter = /([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)/;
    if (!filter.test(email)) {
        return false;
    }

    return true;
}
function validateUser() {
    var frmK = document.forms["newUser"];
    var email = document.getElementById('email').value;
    var pass = document.getElementById('password').value;
    var passCo = document.getElementById('potPassword').value;

    if (!email) {
        sfm_show_error_msg("Unesite email adresu.", frmK.email);
        return false;
    }
    else if (!checkEmail(email)) {
        sfm_show_error_msg("Email adresa nije ispravna.", frmK.email);
        return false;
    }

    if (!pass) {
        sfm_show_error_msg("Unesite lozinku.", frmK.password);
        return false;
    }
    if (!passCo) {
        sfm_show_error_msg("Unesite potvrdu lozinke.", frmK.passCo);
        return false;
    }
    if (passCo != pass) {
        sfm_show_error_msg("Lozinka i potvrda lozinke moraju biti iste.", frmK.password);
        return false;
    }
    return true;
}

function validateUserUp() {
    var frmK = document.forms["IzmjenaKorisnika"];
    var email = document.getElementById('email').value;
    var pass = document.getElementById('password').value;
    var passCo = document.getElementById('potPassword').value;

    if (!email) {
        sfm_show_error_msg("Unesite email adresu.", frmK.email);
        return false;
    }
    else if (!checkEmail(email)) {
        sfm_show_error_msg("Email adresa nije ispravna.", frmK.email);
        return false;
    }

    if (passCo != pass) {
        sfm_show_error_msg("Lozinka i potvrda lozinke moraju biti iste.", frmK.password);
        return false;
    }
    return true;
}
function ValidacijaEditoraKonkursi() {
    var frmK = document.forms["newKonkurs"];
    var Body = tinyMCE.get('textKonkursa').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst konkursa ne može biti prazan.", frmK.textKonkursa);
        return false;
    }
    return true;
}

function ValidacijaEditoraFAQ() {
    var frmK = document.forms["newFAQ"];
    var Body = tinyMCE.get('odgovor').getContent();

    if (!Body) {
        sfm_show_error_msg("Odgovor ne može biti prazan.", frmK.odgovor);
        return false;
    }
    return true;
}
function ValidacijaEditoraFAQI() {
    var frmK = document.forms["FAQEdit"];
    var Body = tinyMCE.get('odgovor').getContent();

    if (!Body) {
        sfm_show_error_msg("Odgovor ne može biti prazan.", frmK.odgovor);
        return false;
    }
    return true;
}
function ValidacijaEditoraZajamSazetak() {
    var frmK = document.forms["newZajam"];
    var Body = tinyMCE.get('sazetakZajma').getContent();

    if (!Body) {
        sfm_show_error_msg("Sažetak ne može biti prazan.", frmK.sazetakZajma);
        return false;
    }
    return true;
}

function ValidacijaEditoraZajamSazetakI() {
    var frmK = document.forms["IzmjenaZajma"];
    var Body = tinyMCE.get('sazetakZajma').getContent();

    if (!Body) {
        sfm_show_error_msg("Sažetak ne može biti prazan.", frmK.sazetakZajma);
        return false;
    }
    return true;
}

function ValidacijaEditoraSektoriI() {
    var frmK = document.forms["sektorEdit"];
    var Body = tinyMCE.get('sadrzajSektora').getContent();

    if (!Body) {
        sfm_show_error_msg("Sadržaj ne može biti prazan.", frmK.sadrzajSektora);
        return false;
    }

    return true;
}

function ValidacijaEditoraSektori() {
    var frmK = document.forms["newSektor"];
    var Body = tinyMCE.get('sadrzajSektora').getContent();

    if (!Body) {
        sfm_show_error_msg("Sadržaj ne može biti prazan.", frmK.sadrzajSektora);
        return false;
    }

    return true;
}

function ValidacijaEditoraSektoriP() {
    var frmK = document.forms["newSektor"];
    var poz = document.getElementById('pozicija').value;

    if (!poz) {
        sfm_show_error_msg("Sadržaj ne može biti prazan.", frmK.pozicija);
        return false;
    } else {

        poz = parseInt(document.getElementById('pozicija').value);
        if (!Number.isInteger(poz)) {
            sfm_show_error_msg("Mora biti cijeli broj.", frmK.pozicija);
            return false;
        }
    }

    return true;
}

function ValidacijaEditoraSektoriPI() {
    var frmK = document.forms["sektorEdit"];
    var poz = document.getElementById('pozicija').value;

    if (!poz) {
        sfm_show_error_msg("Sadržaj ne može biti prazan.", frmK.pozicija);
        return false;
    } else {

        poz = parseInt(document.getElementById('pozicija').value);
        if (!Number.isInteger(poz)) {
            sfm_show_error_msg("Mora biti cijeli broj.", frmK.pozicija);
            return false;
        }
    }

    return true;
}


function ValidacijaEditoraZajamTekst() {
    var frmK = document.forms["newZajam"];
    var Body = tinyMCE.get('textZajma').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst ne može biti prazan.", frmK.textZajma);
        return false;
    }
    return true;
}

function ValidacijaEditoraZajamTekstI() {
    var frmK = document.forms["IzmjenaZajma"];
    var Body = tinyMCE.get('textZajma').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst ne može biti prazan.", frmK.textZajma);
        return false;
    }
    return true;
}

function ValidacijaEditoraKalendar() {
    var frmK = document.forms["newKalendar"];
    var Body = tinyMCE.get('textObjave').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst ne može biti prazan.", frmK.textObjave);
        return false;
    }
    return true;
}

function ValidacijaEditoraKalendarI() {
    var frmK = document.forms["IzmjenaKalendara"];
    var Body = tinyMCE.get('tekstObavjesti').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst ne može biti prazan.", frmK.tekstObavjesti);
        return false;
    }
    return true;
}

function ValidacijaDatum() {
    var frmK = document.forms["newMedij"];
    var datum = document.getElementById('datetimepicker_mask').value;
    var formats = [
        moment.ISO_8601,
        "DD.MM.YYYY HH:mm"
    ];
    if (moment(datum, formats, true).isValid()) {
        return true;
    } else {
        sfm_show_error_msg("Unesite datum.", frmK.datum);
        return false;
    }
}

function ValidacijaDatumK() {
    var frmK = document.forms["newKalendar"];
    var datum = document.getElementById('datetimepicker_mask').value;
    var formats = [
        moment.ISO_8601,
        "DD.MM.YYYY HH:mm"
    ];
    if (moment(datum, formats, true).isValid()) {
        return true;
    } else {
        sfm_show_error_msg("Unesite datum.", frmK.datum);
        return false;
    }
}

function ValidacijaEditoraKonkursiI() {
    var frmK = document.forms["IzmjenaKonkursa"];
    var Body = tinyMCE.get('tekstKonkursa').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst konkursa ne može biti prazan.", frmK.tekstKonkursa);
        return false;
    }
    return true;
}

function ValidacijaEditoraMediji() {
    var frmK = document.forms["newMedij"];
    var Body = tinyMCE.get('textNajave').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst medija ne može biti prazan.", frmK.textNajave);
        return false;
    }
    return true;
}

function ValidacijaEditoraMedijiI() {
    var frmK = document.forms["IzmjenaMedija"];
    var Body = tinyMCE.get('tekstMedija').getContent();

    if (!Body) {
        sfm_show_error_msg("Tekst medija ne može biti prazan.", frmK.tekstMedija);
        return false;
    }
    return true;
}

function ValidacijaEditora() {
    var frm = document.forms["newObavijest"];
    var bodySazetak = tinyMCE.get('sazetakObavijesti').getContent();
    var bodySadrzaj = tinyMCE.get('sadrzajObavijesti').getContent();

    if (!bodySazetak && !bodySadrzaj) {
        sfm_show_error_msg("Sažetak obavijesti ne može biti prazan.", frm.sazetakObavijesti);
        sfm_show_error_msg("Sadržaj obavijesti ne može biti prazan.", frm.sadrzajObavijesti);
        return false;
    }
    if (!bodySazetak) {
        sfm_show_error_msg("Sažetak obavijesti ne može biti prazan.", frm.sazetakObavijesti);
        return false;
    }
    if (!bodySadrzaj) {
        sfm_show_error_msg("Sadržaj obavijesti ne može biti prazan.", frm.sadrzajObavijesti);
        return false;
    }
    else {
        return true;
    }

}

function validateNaslovEdit() {

    $("#naslov").closest("div").removeClass("has-error");
    if (!$.trim($("#IzmjenaObavijest input[name=naslov]").val())) {
        $("#IzmjenaObavijest input[name=naslov]").closest("div").addClass("has-error");
        return false;
    }
    else {
        return true;
    }

}
function ValidacijaEditoraEditObavijesti() {
    var frm = document.forms["IzmjenaObavijest"];
    var bodySazetak = tinyMCE.get('sazetakObavijesti').getContent();
    var bodySadrzaj = tinyMCE.get('sadrzajObavijesti').getContent();

    if (!bodySazetak && !bodySadrzaj) {
        sfm_show_error_msg("Sažetak obavijesti ne može biti prazan.", frm.sazetakObavijesti);
        sfm_show_error_msg("Sadržaj obavijesti ne može biti prazan.", frm.sadrzajObavijesti);
        return false;
    }
    if (!bodySazetak) {
        sfm_show_error_msg("Sažetak obavijesti ne može biti prazan.", frm.sazetakObavijesti);
        return false;
    }
    if (!bodySadrzaj) {
        sfm_show_error_msg("Sadržaj obavijesti obavijesti ne može biti prazan.", frm.sadrzajObavijesti);
        return false;
    }
    else {
        return true;
    }

}

//Postavljanje mogućnosti sortiranja galerije
function SetSortable() {

    $("#sortable").sortable();
    $("#sortable").disableSelection();

    var sortedIDs = $("#sortable").sortable("toArray");
    $("#sortable").on("sortbeforestop", function (event, ui) {
        sortedIDs = $("#sortable").sortable("toArray");


        $.ajax({
            type: "POST",
            url: "/Obavijesti/ChangeOrderPhoto",
            dataType: "json",
            traditional: true,
            data: {
                sortedIDs: sortedIDs,
                obavijest: $('#idObavijesti').val()
            }

        });
    });
}
//Postavljanje mogućnosti brisanja slika
function SetConfirmDeleteFoto() {
    $('.confirm-delete').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteFoto').data('id', id).modal('show');
    });
}
function SetConfirmDeleteDocR() {
    $('.confirm-delete-docR').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteDocR').data('id', id).modal('show');
    });
}
function SetConfirmDeleteDoc() {
    $('.confirm-delete-doc').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteDoc').data('id', id).modal('show');
    });
}

function SetConfirmDeleteDocI() {
    $('.confirm-delete-docI').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteDocI').data('id', id).modal('show');
    });
}

function SetConfirmDeleteDocL() {
    $('.confirm-delete-docL').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteDocL').data('id', id).modal('show');
    });
}

function SetConfirmDeleteDocZ() {
    $('.confirm-delete-docZ').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteDocZ').data('id', id).modal('show');
    });
}
function SetConfirmDeleteDocNa() {
    $('.confirm-delete-docNa').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#ModalDeleteDocNa').data('id', id).modal('show');
    });
}
//Show Modal
function ShowModal(idModal) {

    $(idModal).modal('show');
}

function confrmBrisat(obj) {
    if (confirm("Jeste li sigurni da želite obrisati?")) {
        var url = obj.getAttribute("href");
        $.ajax({
            method: "POST",
            url: url,
            data: { id: obj.getAttribute("id") }
        })
            .done(function (data) {
                alert(data);
                paginantionPage();
            }).fail(function () {
                alert("Neuspjesna operacija!");
            });
    }
    return false;
}