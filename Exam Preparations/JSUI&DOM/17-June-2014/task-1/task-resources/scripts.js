function createImagesPreviewer(selector, items) {

    // TODO Validate input if it is required;

    var root = document.querySelector(selector);
    var fragment = document.createDocumentFragment();
    var preview = document.createElement('div');
    preview.classList = 'image-preview';
    var aside = document.createElement('div');

    preview.style.display = 'inline-block';
    preview.style.width = '75%';
    preview.style.float = 'left';
    preview.style.textAlign = 'center';

    aside.style.display = 'inline-block';
    aside.style.width = '25%';
    aside.style.textAlign = 'center';
    aside.style.height = '500px';
    aside.style.overflowY = 'scroll';
    aside.style.border = '2px, solid, black';

    var previewTitle = document.createElement('h1');
    previewTitle.innerText = items[0].title;
    previewTitle.style.alignContent = 'center';

    var previewImage = document.createElement('img');
    previewImage.src = items[0].url;
    previewImage.style.width = '90%';
    previewImage.style.borderRadius = '10px';

    var filterText = document.createElement('h4');
    filterText.innerText = 'Filter';
    var filter = document.createElement('input');
    filter.style.width = '80%';

    var ul = document.createElement('ul');
    ul.style.listStyleType = 'none';
    var li = document.createElement('li');
    li.classList = 'image-container';
    li.style.paddingBottom = '10px';

    var title = document.createElement('h4');
    title.style.alignContent = 'center';

    var image = document.createElement('img');
    image.style.display = 'block';
    image.style.margin = ' 0 auto';
    image.style.width = '90%';
    image.style.height = '90%'
    image.style.borderRadius = '5px';


    for (var i = 0, len = items.length; i < len; i += 1) {
        var currentLi = li.cloneNode(true);
        var currentImage = image.cloneNode(true);
        var currentTitle = title.cloneNode(true);
        currentTitle.innerText = items[i].title;
        currentImage.src = items[i].url;

        currentLi.appendChild(currentTitle);
        currentLi.appendChild(currentImage);
        ul.appendChild(currentLi);
    }

    aside.appendChild(filterText);
    aside.appendChild(filter);
    aside.appendChild(ul);
    preview.appendChild(previewTitle);
    preview.appendChild(previewImage);

    fragment.appendChild(preview);
    fragment.appendChild(aside);
    root.appendChild(fragment);

    ul.addEventListener('mouseover', function (ev) {
        var target = ev.target;
        //  alert('hi')
        if (target.tagName === 'IMG') {
            target.parentElement.style.background = 'grey';
        }

        target.parentElement.style.cursor = 'pointer';

    }, false)

    ul.addEventListener('mouseout', function (ev) {
        var target = ev.target;

        // current.style.background='';

        if (target.tagName === 'IMG') {
            target.parentElement.style.background = '';
        }

    }, false)

    ul.addEventListener('click', function (ev) {
        var target = ev.target;
        if (target.tagName === 'IMG') {
            previewTitle.innerText = target.previousElementSibling.innerText;
            previewImage.src = target.src;
        }

    }, false)

    filter.addEventListener('keyup', function (ev) {

        var text = ev.target.value.toLowerCase();
        console.log(text);

        var list = ul.getElementsByClassName('image-container')
        for (var i = 0, len = list.length; i < len; i += 1) {
            var child = list[i];
            var header = child.firstElementChild.innerText;
            var picture = child.lastElementChild.innerHTML;
            console.log(child.innerText);

            if (header.toLocaleLowerCase().indexOf(text) >= 0) {
                child.style.display = 'block';
            }

            else {
                child.style.display = 'none';

            }
        }

    }, false)
}