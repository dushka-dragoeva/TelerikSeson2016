function solve() {
    return function (element, contents) {
        var
            domElement,
            fragment,
            len,
            i,
            createdDiv,
        patternDiv;


        if (typeof (element) !== 'string' && !(element instanceof HTMLElement)) {
            throw 'invalid element';
        }

        if (typeof (element) === 'string') {
            domElement = document.getElementById(element);
        } else {
            domElement = element;
            if (domElement === null) {
                throw 'ID is not Existing';
            }
        }

        if ((!Array.isArray(contents)) || contents.some(function (item) {
      return (typeof (item) !== 'string' && typeof (item) !== 'number');
        })) {
            throw '';
        }

        domElement.innerHTML = '';

        patternDiv = document.createElement('div');
        fragment = document.createDocumentFragment();
        len = contents.length;
        for (i = 0; i < len; i += 1) {
            createdDiv = patternDiv.cloneNode(true);
            createdDiv.innerHTML = contents[i];
            fragment.appendChild(createdDiv);
        }
        domElement.appendChild(fragment);


    };
}