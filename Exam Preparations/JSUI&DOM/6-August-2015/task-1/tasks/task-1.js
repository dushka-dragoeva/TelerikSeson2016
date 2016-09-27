function solve() {
    return function (selector, isCaseSensitive) {

        isCaseSensitive = false;

        var root = document.querySelector(selector);
        var fragment = document.createDocumentFragment();

        var form=document.createElement('div');
        form.classList.add('items-control');

        var commonDiv = document.createElement('div');
        var button = document.createElement('button');
        var commonTitle = document.createElement('label');
        var commonInput = document.createElement('input');
        var listItem=document.createElement('li');
        var liContent=document.createElement('p');
        var list =document.createElement('ul');
        var listField=document.createElement('div');

        var addForm = createAddForm();
        var searchForm = createSearchForm();

       //  var el = createElement('Gore');
       // addElement(el);
       //
       //  var anotherel=createElement('FDSRTYU');
       //  addElement(anotherel);
       //  var listItems =createListOfElements();


        function createAddForm() {
            var addField = commonDiv.cloneNode(true);
            addField.classList.add('add-controls');
           // var addContainer = document.createElement('div');
            var title = commonTitle.cloneNode(true);
            title.innerHTML = 'Enter text';
            var input = commonInput.cloneNode(true);
            var addBbutton = document.createElement('button');
            addBbutton.classList.add('button');
            addBbutton.innerText = 'Add';
            addField.appendChild(title);
            addField.appendChild(input);
           // addField.appendChild(addContainer);
            addField.appendChild(addBbutton);

            return addField;
        }

        function createSearchForm() {

            var searchField = commonDiv.cloneNode(true);
            //var fieldContainer = document.createElement('div');
            commonDiv.classList.add('search-controls');
            var title = commonTitle.cloneNode(true);
            title.innerHTML = 'Search';
            var input = commonInput.cloneNode(true);
            var listElement=document.createElement('li');
            commonDiv.appendChild(title);
            commonDiv.appendChild(input);
          //  searchField.appendChild(fieldContainer);

            return commonDiv;

        }

        function createListOfElements() {

            listField.classList.add('result-controls');

            list.classList.add('items-list');
            listField.appendChild(list);

            return listField;

        }

        function  createElement(content) {

            var currentItem=listItem.cloneNode(true);
            currentItem.classList.add('list-item');
            var currentButton=button.cloneNode(true);
            currentButton.classList.add('button');
            currentButton.innerText='X';
            var currentContent=liContent.cloneNode(true);
            currentContent.classList.add('add-controls');
            currentContent.innerText=content;
            currentItem.appendChild(currentButton);
            currentItem.appendChild(currentContent);

            return currentItem;
        }

        function addElement(element) {

            list.appendChild(element);
            return list;

        }

        function RemoveElement(element) {

        }

        function searchElement(element, isCaseSensitive) {

            isCaseSensitive = false;
        }


        form.appendChild(addForm);
        form.appendChild(searchForm);
        form.appendChild(listField);
        fragment.appendChild(form);


        root.appendChild(fragment);
    };
}


// module.exports = solve;