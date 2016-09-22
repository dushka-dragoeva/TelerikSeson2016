var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY)
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }



    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(resolve)
                .fail(reject);
        })
    }

    function threadsAdd(title) {

            var promise = new Promise((resolve, reject) => {
                let username = userGetCurrent()
                    .then((username) => {
                        let body = {title, username};
                        $.ajax({
                            method: 'POST',
                            url: 'api/threads',
                            data: JSON.stringify(body),
                            contentType: 'application/json',
                        }).done((data)=>resolve(data))
                            .fail((err)=>reject(err));
                    })
            });

            return promise;
    }

    // function threadGetCurrent(id) {
    //     return Promise.resolve(threadsGet().find(thread.id===id));
    //
    // }


    function threadById(id) {

        // return new Promise((resolve, reject) => {
        //     $.getJSON('api/threads/#{id}')
        //         .done(resolve(id))
        //         .fail(reject);
        // }).then(console.log(data))


        var promise = new Promise((resolve, reject) => {
            let username = userGetCurrent()
                .then((username,id) => {

                    $.ajax({
                        method: 'GET',
                        url: 'api/threads/#/{id}',
                        contentType: 'application/json',
                    }).done((data)=>resolve(data))
                        .fail((err)=>reject(err));
                })
       });

        return promise.then(console.log(data));

    }

    function threadsAddMessage(threadId, content) {

        var promise = new Promise((resolve, reject) => {
            let username = userGetCurrent()
                .then((username) => {
                    let body = {content, username};
                    $.ajax({
                        method: 'POST',
                        url: 'api/threads/#{threadId}/messages',
                        data: JSON.stringify(body),
                        contentType: 'application/json',
                    }).done((data)=>resolve(data))
                        .fail((err)=>reject(err));
                })
        });

        return promise;

    }

// end threads

// start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

    }

// end gallery

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet,
        }
    }
})
();