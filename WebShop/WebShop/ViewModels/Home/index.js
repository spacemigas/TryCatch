function HomeIndexViewModel() {
    var self = this;

    this.page = ko.observable(1);
    this.pages = ko.observable(1);
    this.articles = ko.observableArray([]);
    this.selected = ko.observable(null);

    $().ready(function () {
        self.loadPage();
        self.updateCart();
        $.getJSON("/api/articles?pages", self.pages);
    });

    this.loadPage = function () {
        self.articles([]);
        $.getJSON("/api/articles?page=" + self.page(), self.articles);
    };

    this.previousPage = function () {
        self.page(self.page() - 1);
        self.loadPage();
    };

    this.nextPage = function () {
        self.page(self.page() + 1);
        self.loadPage();
    };

    this.select = function () {
        self.selected(this);
    };

    this.cancel = function () {
        self.selected(null);
    };

    this.addCart = function () {
        var cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [];
        cart.push(this);
        sessionStorage.cart = JSON.stringify(cart);
        self.selected(null);
        self.updateCart();
    };

    this.updateCart = function () {
        var cart = sessionStorage.cart ? JSON.parse(sessionStorage.cart) : [];
        $('.cart .count').text(cart.length ? cart.length + ' items' : 'empty');
    };
}
