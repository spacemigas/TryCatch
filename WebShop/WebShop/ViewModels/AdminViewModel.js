function AdminViewModel() {
    var self = this;

    this.articles = ko.observableArray([]);

    $().ready(function () {
        $.getJSON("/api/articles", self.articles);
    });
}
