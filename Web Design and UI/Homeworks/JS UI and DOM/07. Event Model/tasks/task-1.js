function solve() {
    var CONST = {
            class: {
                button: 'button',
                content: 'content'
            },
            display: {
                hidden: 'none',
                visible: ''
            },
            buttonInnerHTML: {
                onHidden: 'show',
                onVisible: 'hide'
            }
        },
        validator = {
            validateInput: function (input) {
                if (typeof (input) !== 'string' && !(input instanceof HTMLElement)) {
                    throw {
                        name: 'InvalidArgumentError',
                        message: 'InvalidArgumentError'
                    };
                }
            },
            getValidElement: function (item) {
                var result = item;
                if (typeof item === 'string') {
                    result = document.getElementById(item);

                    if (result === null) {
                        throw {
                            name: 'InvalidIdError',
                            message: 'InvalidIdError'
                        };
                    }

                    return result;
                }
            }

        };

    function buttonEvent(event) {
        var clicked = event.target,
            canToggleVisibility,
            contentElement,
            nextElement = clicked.nextElementSibling;

        while (nextElement) {
            if (nextElement.className == CONST.class.content) {
                contentElement = nextElement;

                while (nextElement) {
                    if (nextElement.className == CONST.class.button) {
                        canToggleVisibility = true;
                        break;
                    }

                    nextElement = nextElement.nextElementSibling;
                }

                break;
            } else {
                nextElement = nextElement.nextElementSibling;
            }
        }

        if (canToggleVisibility) {
            if (contentElement.style.display == CONST.display.hidden) {
                contentElement.style.display = CONST.display.visible;
                clicked.innerHTML = CONST.buttonInnerHTML.onVisible;
            } else {
                contentElement.style.display = CONST.display.hidden;
                clicked.innerHTML = CONST.buttonInnerHTML.onHidden;
            }
        }
    }

    return function (selector) {
        var element, buttons, togglableButtons, i, len;
        validator.validateInput(selector);
        element = validator.getValidElement(selector);

        var buttons = element.getElementsByClassName(CONST.class.button);
        console.log(buttons);
        buttons = [].slice.call(buttons);
        buttons.map(function (button) {
            button.innerHTML = CONST.buttonInnerHTML.onVisible;
            button.addEventListener('click',buttonEvent);

        });
         };
}

module.exports = solve;
