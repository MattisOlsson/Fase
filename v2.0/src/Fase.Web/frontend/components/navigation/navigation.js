import extend from 'extend';
import $ from 'jquery';

export default class Navigation {
    static get defaults() {
        return {
            isActive: false
        };
    }

    constructor(element, options) {
        this.options = extend({}, this.constructor.defaults, options);
        this.element = $(element);
        this.button = this.element.find('[data-navigation__toggle]');
        this.button.on('click', () => this.toggleMenu());
    }

    toggleMenu() {
        this.element.toggleClass('navigation--active');
    }
}