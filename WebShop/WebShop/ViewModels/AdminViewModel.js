function AdminViewModel() {
    var self = this;

    ko.validation.init({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        messageTemplate: null
    }, true);

    this.articles = ko.observableArray([]);
    this.selected = ko.observable();
    this.articleID = ko.observable();
    this.title = ko.observable();
    this.picture = ko.observable();
    this.description = ko.observable();
    this.category = ko.observable();
    this.price = ko.observable();
    this.articleID = ko.observable();
    this.errors = ko.validation.group(this);

    this.load = function () {
        $.getJSON("/api/articles", self.articles);
    };

    this.delete = function () {
        $.ajax({url: '/api/articles/' + this.articleID, cache: false, type: 'DELETE'});
        self.load();
    };

    this.update = function () {
        self.selected(this);
        self.articleID(this.articleID);
        self.title(this.title);
        self.picture(this.picture);
        self.category(this.category);
        self.price(this.price);
        self.description(this.description);
    };

    this.submit = function () {
        var article = {
            articleID: self.articleID(),
            title: self.title(),
            picture: self.picture(),
            category: self.category(),
            price: self.price(),
            description: self.description()
        };
        $.ajax({
            url: '/api/articles',
            cache: false,
            type: 'POST',
            data: JSON.stringify(article),
            contentType: 'application/json; charset=utf-8',
            success: self.load
        });
        self.selected(null);
    };

    this.cancel = function () {
        self.selected(null);
    };

    $().ready(function () {
        self.load();
    });
}
