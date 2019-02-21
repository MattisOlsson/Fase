import $ from 'jquery';
import inViewport from '../in-viewport/in-viewport';
import root from 'window-or-global';

export default class Animate {
    static get defaults() {
        return {
            mode: 'in-viewport',
            offset: -75,
            groupCssClass: 'animate__group',
            groupActiveCssClass: 'animate__group--active',
        };
    }

    constructor(element, options) {
        this.element = $(element);
        this.options = $.extend({}, this.constructor.defaults, options);
        this.groups = this.element.children().addClass(this.options.groupCssClass);

        if (this.options.mode === 'in-viewport') {
            this.groups.each((_, group) => this.initGroup(group));
        }
        else if (this.options.mode === 'onload') {
            root.setTimeout(() => this.groups.addClass(this.options.groupActiveCssClass), 250);
        }
    }

    initGroup(group) {
        inViewport(group, { offset: this.options.offset }, () => this.onIsInViewport(group));
    }

    onIsInViewport(group) {
        $(group).addClass(this.options.groupActiveCssClass);
    }
}