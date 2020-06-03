function moviesInfo(input) {

    let movies = [];

    for (const item of input) {

        if (item.includes('addMovie')) {

            let nameMovie = item.substring(9);
            movies.push({ name: nameMovie });
        }
        else if (item.includes('directedBy')) {

            let endIndexToMovie = item.indexOf('directedBy');
            let nameMovie = item.substring(0, endIndexToMovie - 1);
            let nameDirector = item.substring(endIndexToMovie + 11);

            let indexToMovie = movies.findIndex(m => m.name == nameMovie);

            if (indexToMovie > -1) {

                movies[indexToMovie].director = nameDirector;
            }
        }
        else if (item.includes('onDate')) {

            let endIndexToMovie = item.indexOf('onDate');
            let nameMovie = item.substring(0, endIndexToMovie - 1);
            let date = item.substring(endIndexToMovie + 7);

            let indexToMovie = movies.findIndex(m => m.name == nameMovie);

            if (indexToMovie > -1) {

                movies[indexToMovie].date = date;
            }
        }
    }

    for (const movie of movies) {

        if (Object.keys(movie).length == 3) {

            console.log(JSON.stringify(movie));
        }
    }
}

moviesInfo([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
)