$(document).ready(function () {
    initObjects();
});

// method to send data to API controller
$.sendData = function(url, data, callback, type) {
    return $.ajax({
        url: url,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        type: type,
        success: callback,
        error: callback,
        data: JSON.stringify(data),
        dataType: 'json'
    });
};

// creating event to load locations after city change
function initObjects() {
    $('#City').on('change', function () {
        $.get('/Location/' + $(this).val(),
            function (data) {
                $('#Location').html("");

                for (var i = 0; i < data.length; i++) {
                    $('#Location').append('<option value="' + data[i].name + '">' + data[i].name + '</option>');
                }
            });
    });
}

// reload of sections list partial view
function reloadList() {
    $.get('/Home/List',
        function (data) {
            $('#main').html(data);
        });
}

// showing modal to create a new section
function add() {
    $('.modal-title').html("Add Section");
    $('#btn-add').show();
    $('#btn-save').hide();
    $('#btn-reg').hide();

    $.get('/Home/Create',
        function (data) {
            $('.modal-body').html(data);
            $('#main-modal').modal('show');

            initObjects();
        });
}

// showing modal to edit a chosen section
function edit(id) {
    $('.modal-title').html("Edit Section");
    $('#btn-add').hide();
    $('#btn-save').show();
    $('#btn-reg').hide();

    $.get('/Home/Edit?id=' + id,
        function (data) {
            $('.modal-body').html(data);
            $('#main-modal').modal('show');

            initObjects();
        });
}

// showing modal with information about a chosen section
function details(id) {
    $('.modal-title').html("Section Details");
    $('#btn-add').hide();
    $('#btn-save').hide();
    $('#btn-reg').hide();

    $.get('/Home/Details?id=' + id,
        function (data) {
            $('.modal-body').html(data);
            $('#main-modal').modal('show');
        });
}

// showing modal to make a registration for a section
function showRegister(id) {
    $('.modal-title').html("Registration");
    $('#btn-add').hide();
    $('#btn-save').hide();
    $('#btn-reg').show();

    $.get('/Home/Register?id=' + id,
        function (data) {
            $('.modal-body').html(data);
            $('#main-modal').modal('show');
        });
}

// creation of a new section
function addSection() {
    if (!$('#Name').val()) {
        alert('Please enter the name of section!');
        return;
    }

    var section = getSection();
    var abbr = getAbbreviation(section.Name);

    $.sendData('/conference/' + abbr + '/info',
        section,
        function (data) {
            $('#main-modal').modal('hide');
            reloadList();
        }, 'POST');
}

// editing of a chosen section's data
function editSection() {
    if (!$('#Name').val()) {
        alert('Please enter the name of section!');
        return;
    }

    var section = getSection();
    var abbr = getAbbreviation(section.Name);

    $.sendData('/conference/' + abbr + '/info',
        section,
        function (data) {
            $('#main-modal').modal('hide');
            reloadList();
        }, 'PUT');
}

// registering for a section
function register() {
    var data = {
        LastName: $('#LastName').val(),
        FirstName: $('#FirstName').val(),
        Email: $('#Email').val(),
        SectionId: $('#SectionId').val()
    };

    if (!data.LastName || !data.FirstName || !data.Email) {
        alert("All fields are required!");
        return;
    }

    $.sendData('/Home/Register',
        data,
        function (result) {
            if (result.success) {
                alert('Registration completed succesfully!');
                $('#main-modal').modal('hide');
            } else {
                alert('Please enter a valid email!');
            }
        }, 'POST');
}

// getter for a section's data
function getSection() {
    return {
        Name: $('#Name').val(),
        City: $('#City').val(),
        Location: $('#Location').val()
    };
}

// method to get an abbreviation of a string
function getAbbreviation(name) {
    var matches = name.match(/\b(\w)/g);
    var acronym = matches.join('');

    return acronym;
}