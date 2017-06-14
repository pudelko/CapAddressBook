
$(document).ready(function () {
    
    $('#datatable tfoot th').each(function () {
        $(this).html('<input type="text" />');
    });

    var oTable = $('#datatable').DataTable({
        
        "dom": 'frtiS',
        "scrollY": 500,
        "scrollX": true,
        "scrollCollapse": true,
        "scroller": {
            loadingIndicator: false
        },
        "processing": true,
        "paging": true,
        "deferRender": true,
        "columns": [
       { "data": "Name" },
       { "data": "City" },
       { "data": "Postal" },
       { "data": "Email" },
       { "data": "Company" },
       { "data": "Account" },
       { "data": "CreditCard" }
        ],
        "order": [0, "asc"]

    });

    oTable.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
                .search(this.value)
                .draw();
        });
    });

});