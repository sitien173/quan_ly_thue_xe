$(function() {
    const $dtTable = $('#datatable').DataTable()
    $('#table-footer td').attr('colspan', $('#datatable thead tr th').length - 1);

    $('#remove-all').click(removeAll);
    $('.checkbox').change(setFooter);
    processSelectAll();
});

function removeAll(){
    if (!confirm("Xác nhận xoá")) {
        return;
    }
    $.ajax({
        url: $(this).data('url'),
        method: "POST",
        data: {
            ids: $('.checkbox:checked').map(function() {
                return $(this).val();
            }).get()
        }
    }).done(function() {
        location.reload();
    });
}
function processSelectAll(){
    $('#select-all').click(function () {
        $('.checkbox').prop('checked', this.checked);
        setFooter();
    });

    $('.checkbox').change(function () {
        const itemsChecked = $('.checkbox:checked').length;
        const check = (itemsChecked === $(this).length);
        $('#select-all').prop("checked", check);
        setFooter(itemsChecked);
    });
}

function setFooter(itemsChecked = $('.checkbox:checked').length){
    const $tableFooter= $('#table-footer');
    if (itemsChecked < 1) {
        $tableFooter.addClass('d-none');
        return;
    }

    $tableFooter.removeClass('d-none');
    $('#selected-items').text(itemsChecked);
}