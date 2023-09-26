function PrintElem()
{
    const mywindow = window.open('','PRINT', 'height=400,width=600');
    mywindow.document.write('<html lang="vi"><head><title>' + document.title  + '</title> <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">');
    mywindow.document.write('</head><body>');
    mywindow.document.write($('#contentEdit').html());
    mywindow.document.write('</body></html>');
    mywindow.print();
}

function formatMoney(value){
    return value.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
}

function parseMoney(formattedNumber){
    const plainNumber = formattedNumber.replace(/\./g, '').replace(',', '.');
    return parseFloat(plainNumber);
}

