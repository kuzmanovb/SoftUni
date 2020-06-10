function wordsTracker(input) {

    let keys = input.shift().split(' ');
    let words = {};

    for (const key of keys) {
        words[key] = 0;
    }

    for (const w of input) {

        if (Object.keys(words).some(x => x == w)) {
            words[w]++;
        }
    }

    for (const [key, value] of Object.entries(words).sort((a, b) => b[1] - a[1])) {
        
        console.log(`${key} - ${value}`);
    }
}

wordsTracker([
    'this sentence', 'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurances', 'of', 'the'
    , 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    , 'sentence','sentence'
]
)