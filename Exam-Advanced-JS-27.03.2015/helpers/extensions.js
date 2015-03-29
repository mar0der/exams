var imdb = imdb || {};

(function (scope) {
    function getAllMovies() {
        var allMovies = [],
            allGenres = scope.getGenres();
        allGenres.forEach(function(x) {
            allMovies = allMovies.concat(x.getMovies());
        });
        return allMovies;
    }

    scope.getAllMovies = function() {
        return getAllMovies();
    }

}(imdb));

Function.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.constructor = this;
}