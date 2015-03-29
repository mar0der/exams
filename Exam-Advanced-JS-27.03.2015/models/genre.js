var imdb = imdb || {};

(function (scope) {
    var id = 1;
    function Genre(name) {
        this.name = name;
        this._id = id++;
        this._movies = [];
    }

    Genre.prototype.addMovie = function addMovie(movie) {
        this._movies.push(movie);
    }

    Genre.prototype.deleteMovie = function deleteMovie(movie) {
        this._movies.remove(movie);
    }

    Genre.prototype.deleteMovieById = function deleteMovieById(id) {
        this._movies = this._movies.filter(function(movie) {
            return movie._id !== id;
        });
    }

    Genre.prototype.getMovies = function getMovies() {
        return this._movies;
    }

    scope.getGenre = function getGenre(name) {
        return new Genre(name);
    }

}(imdb));