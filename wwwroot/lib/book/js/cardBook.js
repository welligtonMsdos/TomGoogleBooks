function OpenDescription(isbn) {

    $.ajax({
        type: "GET",
        url: '/Book/GetDescription',
        data: {
            isbn: isbn
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialDetailBook').html(data);

            $('#detailsBook').modal('show');
        }
    })
}