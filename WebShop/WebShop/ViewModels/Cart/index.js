function CartIndexViewModel() {
    var self = this,
        cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [],
        subtotal = 0,
        count = 0,
        vatRate = 0.23;

    ko.utils.arrayForEach(cart, function (item) {
        count += item.Quantity;
        subtotal += item.Price;
    });

    this.cart = ko.observableArray(cart);
    this.subtotal = ko.observable(subtotal);
    this.vat = ko.observable(subtotal * vatRate);
    this.total = ko.observable(subtotal + this.vat());
    this.count = ko.observable(count);
}
