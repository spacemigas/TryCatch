function CartIndexViewModel() {
    var self = this,
        cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [];

    this.items = ko.observableArray(cart);

    $().ready(function () {
        self.updateCart();
    });

    this.updateCart = function () {
        var cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [];
        $('.cart .count').text(cart.length ? cart.length + ' items' : 'empty');
    };
}
