function solve() {
    if (!Array.prototype.find) {
        Array.prototype.find = function (predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.find called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return value;
                }
            }
            return undefined;
        };
    }
    if (!Array.prototype.findIndex) {
        Array.prototype.findIndex = function (predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.findIndex called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return i;
                }
            }
            return -1;
        };
    }


    function* idGenerator() {
        let lastId = 0,
            forever = true;

        while (forever) {
            yeld(lastId += 1);
        }
    }

    const validator = {
        isStringValid(str, min = 1, max = Number.MAX_VALUE){
            return (typeof str === "string") &&
                str.length >= min && str.length <= max
        },

        isNumberValid(n, min = 0, max = Number.MAX_VALUE){
            return (typeof n === "number") &&
                min <= n && n <= max;
        },

        isNonemptyArrayWithValidObjects(array, validFunc){
            validFunc = validFunc || function () {
                    return true
                };
            return Array.isArray(array) && array.length > 0 &&
                array.every(validFunc);
        }
    };
    let playerIdGenerator = new idGenerator();
    let playableIdGenerator = new idGenerator();
    let playListIdGenerator = new idGenerator();

    class Player {

        constructor(name) {
            this.id = playerIdGenerator.next().value();
            this.name = name;
            this.playLists = [];
        }

        get id() {
            return this._id;
        }

        get name() {
            return this._name;
        }

        set name(name) {
            if (!validator.isStringValid(name, 3, 25)) {
                throw new Error("Invalid Name");
            }
            this._name = name;
        }

        addPlaylist(playlistToAdd) {
            if (!(playlistToAdd instanceof PlayList)) {
                throw  new Error("Invalid playlist")
            }

            this.playLists.add(playlistToAdd);
            return this;
        }

        getPlayListById(id) {

            let playListToReturn = this.playLists.filter(p=>p.id === id);
            if (playListToReturn !== null) {
                return playListToReturn;
            } else {
                return null;
            }
        }

        removePlayable(id) {
            let playListToRemove = this.getPlayListById(id);
            if (playListToRemove === null) {
                throw new Error("Invalid id");
            }

            let index = this.playLists.indexOf(playListToRemove);

            this.playLists.splice(index, 1);

            return this;
        }

        removePlayable(playable) {
            let playableToRemove = this.playables.filter(p=>p.id === playable.id);
            if (playableToRemove === null) {
                throw new Error("Invalid id");
            }

            this.playables.remove(playable);

            //  this.playables = this.playables.filter(p => playableToRemove.indexOf(p) === -1);
            return this;
        }
    }


    class PlayList {
        constructor(name) {
            this.id = playListIdGenerator.next().value();
            this.name = name;
            this.playables = [];
            //???
        }

        get id() {
            return this._id;
        }

        get name() {
            return this._name;
        }

        set name(name) {
            if (!validator.isStringValid(name, 3, 25)) {
                throw new Error("Invalid Name");
            }
            this._name = name;
        }


//	The same playable can be added multiple times=???
        addPlayable(playable) {
            if (!(playable instanceof Playable)) {
                throw new Error("Invalid playable");
            }

            let playableToAdd = playable;
            this.playables.add(playableToAdd);
            return this;
        }

        getPlayableById(id) {

            let playableToReturn = this.playables.filter(p=>p.id === id);
            if (playableToReturn !== null) {
                return playableToReturn;
            } else {
                return null;
            }
        }

        removePlayable(id) {
            let playableToRemove = this.getPlayableById(id);
            if (playableToRemove === null) {
                throw new Error("Invalid id");
            }

            this.playables.remove(playableToRemove);
            return this;
        }

        removePlayable(playable) {
            let playableToRemove = this.playables.filter(p=>p.id === playable.id);
            if (playableToRemove === null) {
                throw new Error("Invalid id");
            }

            this.playables.remove(playable);

            //  this.playables = this.playables.filter(p => playableToRemove.indexOf(p) === -1);
            return this;
        }
    }

    class Playable {
        constructor(title, author) {
            this.id = playableIdGenerator.next().value;
            this.title = title;
            this.author = author;
        }

        get id() {
            return this._id;
        }

        get title() {
            return this._title;
        }

        set title(title) {
            if (!validator.isStringValid(title, 3, 25)) {
                throw new Error("Invalid title");
            }
            this._title = title;
        }

        get author() {
            return this._author;
        }

        set author(author) {
            if (!validator.isStringValid(author, 3, 25)) {
                throw new Error("Invalid author");
            }
            this._author = author;
        }

        play() {
            return `${this.id}. ${this.title} - ${this.author}`;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }


        get length() {
            return this._length;
        }

        set length(length) {
            if (!validator.isNumberValid(length, 1)) {
                throw  new Error("Invalid length");
            }

            this._lenghth = lenghth;
        }

        play() {
            return super.play() + ` - ${this.length}`;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            this.imdbRating = imdbRating;
        }


        get imdbRating() {
            return this._imdbRating;
        }

        set imdbRating(imdbRating) {
            if (!validator.isNumberValid(imdbRating, 1, 5)) {
                throw  new Error("Invalid imdbRating");
            }

            this._imdbRating = imdbRating;
        }

        play() {
            return super.play() + ` - ${this.imdbRating}`;
        }
    }

    return {
        getPlayer: function (name) {
            return Object.create(player).init(name);
        },
        getPlaylist: function (name) {
            return Object.create(playlist).init(name);
        },
        getAudio: function (title, author, length) {
            return Object.create(audio).init(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return Object.create(video).init(title, author, imdbRating);
        }
    };
}

var result = solve();
var audio = result.getAudio('asd', 'sdf', 4);
audio = result.getAudio('asd', 'sdf', 4);
console.log(audio.play());

/*var pl = result.getPlaylist('asd');

 var playable = {id: 1, name: 'Rock', author: 'Stephen'};
 pl.addPlayable(playable);
 console.log(pl.getPlayableById(1));

 console.log(pl.listPlayables(0, 10));
 pl.removePlayable(1);
 console.log(pl.getPlayableById(1));

 var list = result.getPlaylist('Rock');
 for (var i = 0; i < 35; i += 1) {
 list.addPlayable({id: (i + 1), name: 'Rock' + (9 - (i % 10))});
 }

 //console.log(list.listPlayables(0, 10));

 /*returnedPlayables = list.listPlaylables(2,10);
 returnedPlayables = list.listPlaylables(3,10);
 console.log(returnedPlayables);*/

module.exports = solve;