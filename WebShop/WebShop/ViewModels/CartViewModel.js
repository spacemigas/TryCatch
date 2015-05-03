function CartViewModel() {
    var self = this,
        cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [],
        vatRate = 0.23;

    this.cart = ko.observableArray(cart);
    this.subtotal = ko.observable(0);
    this.vat = ko.observable(0);
    this.total = ko.observable(0);
    this.count = ko.observable(0);
    this.customer = ko.observable({
        FirstName: null,
        LastName: null,
        Email: null,
        Address: null,
        HouseNumber: null,
        City: null,
        ZipCode: null
    });

    this.round = function (value) {
        return Math.round(value * 100) / 100;
    };

    this.update = function () {
        var subtotal = 0,
            count = 0;
        ko.utils.arrayForEach(self.cart(), function (item) {
            count++;
            subtotal += item.Price;
        });
        self.subtotal(subtotal);
        self.vat(self.round(subtotal * vatRate));
        self.total(self.round(subtotal + self.vat()));
        self.count(count);
        sessionStorage.cart = JSON.stringify(cart);
    };

    this.remove = function () {
        self.cart.remove(this);
        self.update();
    };

    this.add = function (article) {
        cart.push(article);
        self.update();
    };

    this.submit = function () {
        var data = {
            customer: self.customer(),
            articles: []
        };
        ko.utils.arrayForEach(self.cart(), function (item) {
            data.articles.push(item.Id);
        });
        $.ajax({
            url: '/api/order',
            cache: false,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            statusCode: {
                201: function () {
                    sessionStorage.cart = JSON.stringify([]);
                },
                400: function (jqxhr) {
                }
            }
        });
    };

    this.update();
}
