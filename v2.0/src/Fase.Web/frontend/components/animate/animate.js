import $ from 'jquery';
import inViewport from '../in-viewport/in-viewport';

export default class Animate {
    static get defaults() {
        return {
            mode: 'in-viewport',
        };
    }

    constructor(element, options) {
        this.element = $(element);
        this.groups = this.element.children().addClass('animate__group');
        this.options = $.extend({}, this.constructor.defaults, options);

        if (this.options.mode === 'in-viewport') {
            this.groups.each((_, group) => this.initGroup(group));
        }
        else if (this.options.mode === 'onload') {
            window.setTimeout(() => this.groups.addClass('animate__group--active'), 250);
        }
    }

    initGroup(group) {
        inViewport(group, { offset: -100 }, () => this.onIsInViewport(group));
    }

    onIsInViewport(group) {
        $(group).addClass('animate__group--active');
    }
}