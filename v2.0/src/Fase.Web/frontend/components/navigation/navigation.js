import extend from 'extend';
import $ from 'jquery';

export default class Navigation {
    static get defaults() {
        return {
            isActive: false,
            activeCssClass: 'navigation--active',
            itemActiveCssClass: 'navigation__item--active',
            itemExpandedCssClass: 'navigation__item--expanded',
            itemHasChildrenCssClass: 'navigation__item--has-children',
        };
    }

    constructor(element, options) {
        this.options = extend({}, this.constructor.defaults, options);
        this.element = $(element);
        this.menu = this.element.find('[data-navigation__menu]');
        this.menuLinks = this.menu.find('[data-navigation__link]');
        this.button = this.element.find('[data-navigation__toggle]');
        this.button.on('click', () => this.toggleMenu());
        this.menuLinks.on('click', (event) => this.onMenuLinkClick(event));
        this.htmlElement = $('html');
    }

    toggleMenu() {
        this.element.toggleClass(this.options.activeCssClass);
    }

    onMenuLinkClick(event) {
        const menuItem = $(event.currentTarget).parent();
        this.toggleSubMenu(menuItem);

        if (this.htmlElement.hasClass('touch-device') && menuItem.hasClass(this.options.itemHasChildrenCssClass)) {
            event.preventDefault();
            return false;
        }

        return true;
    }

    toggleSubMenu(menuItem) {
        menuItem.toggleClass(this.options.itemExpandedCssClass);
    }
}