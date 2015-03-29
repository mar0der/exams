var imdb = imdb || {};

(function (scope) {
    var id = 1;
    function Review(author, content, date) {
        this._id = id++;
        this.author = author;
        this.content = content;
        this.date = date;
    }

    scope.getReview = function getReview(author, content, date) {
        return new Review(author, content, date);
    }

}(imdb));