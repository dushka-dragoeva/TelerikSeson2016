/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing  =>
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function solve() {

  return function (element, contents) {
    var
      parentElement,
      createdDiv,
      currentDiv,
      fragment,
      len,
      i;

    // if (typeof (element) !== 'string' || !(element instanceof Element)) {
    //   throw 'Invalid element!';
    // }

    if (typeof (element) === 'string') {
      parentElement = document.getElementById(element);
    } else {
      parentElement = element;
      // if (parentElement === null) {
      //   throw 'Dom element doesn\'t exist';
      // }
    }

      if (!Array.isArray(contents) || contents.some(function (item) {
        return typeof (item) !== 'string' && typeof (item) !== 'number';
      })) {
        throw 'Invalid content!';
      }


       parentElement.innerHTML = '';

       len = contents.length;
       createdDiv = document.createElement('div');
       fragment = document.createDocumentFragment();

      for (i = 0; i < len; i += 1) {
        currentDiv = createdDiv.cloneNode(true);
        currentDiv.innerHTML = contents[i];
        fragment.appendChild(currentDiv);
      }
      parentElement.appendChild(fragment);

     

    };
  };