var imdb = imdb || {};

(function (scope) {
    var id = 1;
    function Actor(name, bio, born) {
        this._id = id++;
        this.name = name;
        this.bio = bio;
        this.born = born;
    }
    
    scope.getActor = function getActor(name, bio, born) {
        return new Actor(name, bio, born);
    }

}(imdb));