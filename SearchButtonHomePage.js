$(document).ready(function () {
    // Search functionality
    $('#productSearch').on('keyup', function () {
        var searchTerm = $(this).val().toLowerCase();

        $('.product-card').each(function () {
            var card = $(this);
            var title = card.data('title');
            var author = card.data('author');
            var price = card.data('price').toString();
            var discount = card.data('discount').toString();

            if (title.includes(searchTerm) ||
                author.includes(searchTerm) ||
                price.includes(searchTerm) ||
                discount.includes(searchTerm)) {
                card.show();
            } else {
                card.hide();
            }
        });
    });
});