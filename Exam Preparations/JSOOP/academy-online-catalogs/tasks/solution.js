/**
 * Created by HP on 9/9/2016.
 */

"use strict";

function solve() {

    function* idGenerator() {
        let lastId = 0,
            forever = true;

        while (forever) {
            yeld(lastId += 1);
        }
    }

    let itemsIdGenerator = idGenerator();

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

    class Item {
        constructor(name, description) {
            this.id = itemsIdGenerator.next().value;
            this.name = name;
            this.description = description;

        }

        get name() {
            return this._name;
        }

        set name(name) {
            if (!validator.isStringValid(name, 2, 40)) {
                throw new Error("Invalid Name");
            }
            this._name = name;
        }

        get description() {
            return this._description;
        }

        set description(description) {
            if (!validator.isStringValid(description)) {
                throw new Error("Invalid Description");
            }
            this.description = description;
        }

    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(isbn) {
            if (!validator.isStringValid(isbn, 10, 10) && !validator.isStringValid(isbn, 13, 13) && !validator.isNumberValid(+isbn)) {
                throw new Error("Invalid isbn")
            }
        }

        get genre() {
            return this._genre;
        }

        set genre(genre) {
            if (!validator.isStringValid(genre, 2, 20)) {
                throw new Error("Invalid genre");
            }
            return this._name = genre;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);
            this.rating = rating;
            this.duration = duration;
        }

        get rating() {
            return this._rating;
        }

        set rating(rating) {
            if (!validator.isNumberValid(rating, 1, 5)) {
                throw  new Error("Invalid rating");
            }

            this._rating = rating;
        }

        get duration() {
            return this._duration;
        }

        set duration(duration) {
            if (!validator.isNumberValid(duration, 1)) {
                throw new Error("Ivvalid duration");
            }

            this._duration = duration;
        }
    }

    let catalogIdGenerator = idGenerator();

    class Catalog {
        constructor(name) {
            this.id = catalogIdGenerator.next().value;
            this.name = name;
            this.itemes = [];
        }

        get name() {
            return this._name;
        }

        set name(name) {
            if (!validator.isStringValid(name, 2, 40)) {
                throw new Error("Invalid Name");
            }
            this._name = name;
        }

        add(...itemes) {
            if (Array.isArray(itemes[0])) {
                itemes = itemes[0];
            }

            if (!validator.isNonemptyArrayWithValidObjects(items)) {
                throw  new Error("Invalid Items")
            }

            this.itemes.push(...itemes);
        }

        find(...options) {

            if (typeof(options) === " undefined") {
                throw  new Error("Invalid find option");
            }

            let isSingleResult = false;
            if (typeof (options) === "number") {
                options = {
                    id: options
                };

                isSingleResult = true;
            }

            if (typeof (options !== "object")) {

                throw  new Error("Invalid Options");
            }

            let result = this.itemes.filter(item=> {
                return Object.keys(options)
                    .every(key=>item[key] === options[key]);
            });

            return (!isSingleResult) ? result : (result.length) ? result[0] : null;


            /*  Throws if:
             *	no arguments are passed
             *   `id` is not a number*/
        }

        search(pattern) {
            if (validator.isStringValid(pattern, 1)) {
                throw  new Error("Invalid Pattern");
            }

            pattern = pattern.toLowerCase();

            let result = this.itemes.filter(item=>item.name.toLowerCase().indexOf(pattern) >= 0 ||
            item.description.toLowerCase().indexOf(pattern) >= 0);

            result = this.itemes.filter(item=>
                item.name.toLowerCase().includes((pattern) || item.name.toLowerCase().includes(pattern)));

            return result;

        }

        itemLikeObjectValidation(item) {
            return typeof item.id === "number" &&
                typeof item.name === "string" &&
                typeof  item.description === "string";
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        itemLikeObjectValidation(item) {
            let isValidBook = (super.itemLikeObjectValidation(item) &&
                typeof item.isbn === "string" &&
                typeof item.genre === "string") || item instanceof Book;
            return isValidBook

        }

        add(...books) {

            if (Array.isArray(books[0])) {
                books = books[0];
            }


            books.forEach(function (item) {
                if (!(this.itemLikeObjectValidation(item))) {
                    throw new Error("All items must be books")
                }
            })

            books.forEach(item=>itemLikeObject(item) === true)

            return super.add(...books);

        }

        search(pattern) {

            return super.search(pattern) &&
                this.itemes.filter(book=>book.genre.toLowerCase().includes(pattern))
        }

        getGerne() {
            let genres = this.map(x=>x.genre.toLowerCase()),
                uniqueGenres = new Set(genres);

            return Array.from(uniqueGenres);
        }

        find(...options) {
            return super.find(...options);
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        itemLikeObjectValidation(media) {
            return super.itemLikeObjectValidation(media) &&
                ((media instanceof Media) || (typeof media.rating === "number" &&
                typeof media.duration === "number"));
        }

        add(...mediaArray) {

            mediaArray = mediaArray[0];

            mediaArray.forEach(function (media) {
                if (!(this.itemLikeObjectValidation(media))) {
                    throw new Error("All items must be media")
                }

                return super.add(...mediaArray);
            })
        }

        getTop(count) {

            if (!validator.isNumberValid(count, 1)) {
                throw  new Error("ïnvalid count")

            }

            let topCount = this.itemes.sort((x, y)=>x.rating - y.rating)
                .slice(0, count)
                .map(item=> {
                    return {
                        id: item.id,
                        name: item.name
                    };
                });

            return topCount;
        }

        getSortedByDuration() {
            return this.itemes.sort((a, b)=> {
                if (a.duration === b.duration) {
                    //ascending
                    return a.id < b.id;
                }
                // descending
                return a.duration > b.duration;
            })
        }
    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description)
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        }
    }
}