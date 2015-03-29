var imdb = imdb || {};

(function (scope) {
    var id = 1;
    function Movie(title, length, rating, country) {
        this._id = id++;
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];

    }

    Movie.prototype.addActor = function addActor(actor) {
        this._actors.push(actor);
    }

    Movie.prototype.getActors = function getActors() {
        return this._actors;
    }

    Movie.prototype.addReview = function addReview(review) {
        this._reviews.push(review);
    }

    Movie.prototype.deleteReview = function deleteReview(review) {
        this._reviews.remove(review);
    }

    Movie.prototype.deleteReviewById = function deleteReviewById(id) {
        this._reviews = this._reviews.filter(function(review) {
            return review._id !== id;
        });
    }

    Movie.prototype.getReviews = function getReviews() {
        return this._reviews;
    }

    scope.Movie = Movie;
    scope.getMovie = function getMovie(title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }

}(imdb));