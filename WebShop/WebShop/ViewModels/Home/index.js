function HomeIndexViewModel() {
    var self = this;

    this.page = ko.observable(1);
    this.pages = ko.observable(1);
    this.articles = ko.observableArray([]);
    this.selected = ko.observable(null);

    $().ready(function () {
        self.loadPage();
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

    this.unselect = function () {
        self.selected(null);
    };
}
