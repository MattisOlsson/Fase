import $ from 'jquery';

export default class Hero {
    constructor(element) {
        this.element = $(element);
        window.setTimeout(() => this.element.addClass('hero--animate'), 250);
    }
}