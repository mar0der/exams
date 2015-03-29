var imdb = imdb || {};

(function (scope) {
    function loadHtml(selector, data) {
        var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data),
	        loadedMovie;

        container.appendChild(genresUl);

        genresUl.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI') {
                var genreId,
					genre,
					moviesHtml;

                genreId = parseInt(ev.target.getAttribute('data-id'));
                genre = data.filter(function (genre) {
                    return genre._id === genreId;
                })[0];

                moviesHtml = loadMovies(genre.getMovies());
                moviesContainer.innerHTML = moviesHtml.outerHTML;
                moviesContainer.setAttribute('data-genre-id', genreId);
            }
        });

        // Task 2 - Add event listener for movies boxes
        moviesContainer.addEventListener('click', function (ev) {
            var target = ev.target,
		        parent = target.parentElement,
		        movie = -1;

            function getMovieId(node) {
                return Number(node.getAttribute('data-id'));
            }

            function getMovieWithId(id) {
                var allMovies = scope.getAllMovies(),
                    i;
                //beacause arrya.forEach cannot be breaked with return and it should be stoped with some ugly eeptions.
                for (i = 0; i < allMovies.length; i++) {
                    if (allMovies[i]._id == id) {
                        return allMovies[i];
                    }
                }
                return -1;
            }

            if (target.tagName === 'LI') {
                movie = getMovieWithId(getMovieId(target));
            }

            if (parent.tagName === 'LI') {
                movie = getMovieWithId(getMovieId(parent));
            }

            if (movie != -1) {
                detailsContainer.innerHTML = '';
                detailsContainer.appendChild(loadActors(movie));
                detailsContainer.appendChild(loadReviews(movie));
                loadedMovie = movie;
            }
        });

        // Task 3 - Add event listener for delete button (delete movie button or delete review button)
        detailsContainer.addEventListener('click', function (ev) {
            var target = ev.target,
		        reviewId,
		        parentNode,
		        reviewNode;

            if (target.hasAttribute('review-id')) {
                reviewId = Number(target.getAttribute('review-id'));
                parentNode = target.parentNode;
                reviewNode = target.parentNode.parentNode;
                reviewNode.removeChild(parentNode);
                loadedMovie.deleteReviewById(reviewId);
            }
        });

    }

    function loadGenres(genres) {
        var genresUl = document.createElement('ul');
        genresUl.setAttribute('class', 'nav navbar-nav');
        genres.forEach(function (genre) {
            var liGenre = document.createElement('li');
            liGenre.innerHTML = genre.name;
            liGenre.setAttribute('data-id', genre._id);
            genresUl.appendChild(liGenre);
        });

        return genresUl;
    }

    function loadMovies(movies) {
        var moviesUl = document.createElement('ul');
        movies.forEach(function (movie) {
            var liMovie = document.createElement('li');
            liMovie.setAttribute('data-id', movie._id);

            liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
            liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
            liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
            liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
            liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
            liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';

            moviesUl.appendChild(liMovie);
        });

        return moviesUl;
    }

    function loadActors(movie) {
        var actors,
            header,
            ul;

        actors = document.createElement('div');
        header = document.createElement('h1');
        header.innerHTML = 'Actors';
        ul = document.createElement('ul');
        movie.getActors().forEach(function (actor) {
            var actorLi = document.createElement('li');
            actorLi.innerHTML = '<h2>' + actor.name + '</h2>';
            actorLi.innerHTML += '<div><strong>Bio: </strong>' + actor.bio + '</div>';
            actorLi.innerHTML += '<div><strong>Born: </strong>' + actor.born + '</div>';
            ul.appendChild(actorLi);
        });
        actors.appendChild(header);
        actors.appendChild(ul);

        return actors;
    }

    function loadReviews(movie) {
        var reviews,
            header,
            ul;

        reviews = document.createElement('div');
        header = document.createElement('h1');
        header.innerHTML = 'Reviews';
        ul = document.createElement('ul');
        movie.getReviews().forEach(function (review) {
            var reviewsLi = document.createElement('li');
            var deleteBtn = document.createElement('button');
            deleteBtn.setAttribute('review-id', review._id);
            deleteBtn.innerHTML = 'Delete Review';

            reviewsLi.innerHTML = '<h2>' + review.author + '</h2>';
            reviewsLi.innerHTML += '<div>' + review.content + '</div>';
            reviewsLi.innerHTML += '<div><strong>Date: </strong>' + review.date + '</div>';
            reviewsLi.appendChild(deleteBtn);
            ul.appendChild(reviewsLi);
        });
        reviews.appendChild(header);
        reviews.appendChild(ul);

        return reviews;
    }
    scope.loadHtml = loadHtml;
}(imdb));