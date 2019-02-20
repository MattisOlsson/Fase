import extend from 'extend';
import $ from 'jquery';

export default class AnchorLink {
    constructor(element, options) {
        this.options = extend({}, options);
        this.element = $(element);
        this.element.on('click', () => this.onClick());
    }

    onClick() {
        let target = $(document).find(this.element.attr('href'));
        window.console.log(target.offset());
    }
}