/* globals $ */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`

 */
function solve() {
    return function (selector) {

        var CONST = {
            class: {
                content: 'content',
                button: 'button'
            },
            buttonInnerHtml:{
                onHidden:'show',
                onVisible:'hide'
            },
            display:{
                hidden:'none',
                visible:''
            }
        }

        var $root;

        if (typeof selector !== 'string') {
            throw 'invalid selector';
        }

        if (!(cssSelector instanceof jQuery)) {
            throw 'invalid jqObj';
        }

        if (typeof selector === 'string') {
            $root = $(selector);
        } else {
            $root = selector;
        }

        var $buttons = $root.find('.button');
        var $conntent = $root.find('.button');


       var buttonEvent = function () {
           $(this).textContent(CONST.buttonInnerHtml.onVisible)
               .click(function(){
                   var $clicked = $(this),
                       $content;


               })


        }


    };
};

//module.exports = solve;