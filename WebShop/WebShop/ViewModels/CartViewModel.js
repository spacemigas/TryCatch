function CartViewModel() {
    var self = this,
        cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [],
        lastOrder = sessionStorage.lastOrder ? JSON.parse(sessionStorage.lastOrder) : {},
        vatRate = 0.23;

    ko.validation.init({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        messageTemplate: null
    }, true);

    this.cart = ko.observableArray(cart);
    this.lastOrder = ko.observable(lastOrder);
    this.subtotal = ko.observable(0);
    this.vat = ko.observable(0);
    this.total = ko.observable(0);
    this.count = ko.observable(0);
    this.title = ko.observable();
    this.firstName = ko.observable();
    this.lastName = ko.observable();
    this.email = ko.observable();
    this.address = ko.observable();
    this.houseNumber = ko.observable();
    this.city = ko.observable();
    this.zipCode = ko.observable();
    this.errors = ko.validation.group(this);

    this.round = function (value) {
        return Math.round(value * 100) / 100;
    };

    this.update = function () {
        var subtotal = 0,
            count = 0;
        ko.utils.arrayForEach(self.cart(), function (item) {
            count++;
            subtotal += item.price;
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
        var order = {
            customer: {
                title: self.title(),
                firstName: self.firstName(),
                lastName: self.lastName(),
                email: self.email(),
                address: self.address(),
                houseNumber: self.houseNumber(),
                city: self.city(),
                zipCode: self.zipCode()
            },
            details: []
        };
        ko.utils.arrayForEach(self.cart(), function (item) {
            var detail = ko.utils.arrayFirst(order.details, function (detail) {
                return detail.articleID === item.articleID;
            });
            if (!detail) {
                detail = {
                    articleID: item.articleID,
                    price: item.price,
                    quantity: 0
                };
                order.details.push(detail);
            }
            detail.quantity++;
        });
        $.ajax({
            url: '/api/orders',
            cache: false,
            type: 'POST',
            data: JSON.stringify(order),
            contentType: 'application/json; charset=utf-8',
            statusCode: {
                200: self.success,
                201: self.success,
                204: self.success,
                400: self.error
            }
        });
    };

    this.success = function (order) {
        self.lastOrder(order);
        sessionStorage.lastOrder = JSON.stringify(order);
        sessionStorage.cart = JSON.stringify([]);
        window.location = 'thanks';
    };

    this.error = function () {
    };

    this.update();
}
