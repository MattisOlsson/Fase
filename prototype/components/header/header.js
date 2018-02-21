import extend from 'extend';
import $ from 'jquery';

export default class Header {
    constructor(element, options) {
        this.options = extend({}, options);
        this.element = $(element);
        this.body = $('body');
        this.hero = $('.hero');
        $(document).on('scroll.header', () => this.onScroll());

        // Set state on load
        this.setState();
    }

    onScroll() {
        this.setState();
    }

    setState() {
        var scrollTop = this.body.scrollTop();
        var heroHeight = this.hero.offset().top + this.hero.outerHeight();

        if (scrollTop > heroHeight - this.element.outerHeight()) {
            this.element.removeClass('header--transparent');
        }
        else {
            this.element.addClass('header--transparent');
        }
    }
}