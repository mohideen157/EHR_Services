var uri = 'http://localhost:1484/api/Values';
let todos = null;
function getCount(data) {
    const el = $('#counter');
    let name = 'to-do';
    if (data) {
        if (data > 1) {
            name = 'to-dos';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getData();
    $("#btngetmeth2").on("click", function () {
       
        getData2();
    })
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        crossDomain: true,
        success: function (data) {
            alert("This GetMethod1");
            $('#todos').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                const checked = item.isComplete ? 'checked' : '';

                $('<tr><td><input disabled="true" type="checkbox" ' + checked + '></td>' +
                    '<td>' + item.name + '</td>' +
                    '<td><button onclick="editItem(' + item.id + ')">Edit</button></td>' +
                    '<td><button onclick="deleteItem(' + item.id + ')">Delete</button></td>' +
                    '</tr>').appendTo($('#todos'));
            });

            todos = data;
        }
    });
}
function getData2() {
    $.ajax({
        type: 'GET',
        url: uri+"/2",
        crossDomain: true,
        success: function (data) {
            alert(data);
        },
        error: function () {
            alert(Error);
        }
    });
}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'isComplete': false,
        dd: {"type":0}
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        crossDomain: true,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
           // getData();
            alert(result);
           // $('#add-name').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        crossDomain: true,
        success: function (result) {
            alert(result);
            //getData();
        }
    });
}

function editItem(id) {
    $.each(todos, function (key, item) {
        if (item.id === id) {
            $('#edit-name').val(item.name);
            $('#edit-id').val(item.id);
            $('#edit-isComplete').val(item.isComplete);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'name': $('#edit-name').val(),
        'isComplete': $('#edit-isComplete').is(':checked'),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + 2,
        type: 'PUT',
        crossDomain: true,
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            alert(result);
            //getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}