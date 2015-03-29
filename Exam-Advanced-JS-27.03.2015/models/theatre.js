var imdb = imdb || {};

(function (scope) {
    function Theatre(title, length, rating, country, isPuppet) {
        scope.Movie.call(this, title, rating, country);
        this.isPuppet = isPuppet;
    }

    Theatre.extends(scope.Movie);

    scope.getTheatre = function getTheatre(title, length, rating, country, isPuppet) {
        return new Theatre(title, length, rating, country, isPuppet);
    }

}(imdb));