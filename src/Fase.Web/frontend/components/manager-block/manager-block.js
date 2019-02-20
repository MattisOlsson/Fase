import $ from 'jquery';

export default class ManagerBlock {
    static get defaults() {
        return {
        };
    }

    constructor(element, options) {
        this.element = $(element);
        this.options = $.extend({}, this.constructor.defaults, options);
        this.element.on('mouseenter', '.manager-block', (event) => this.onMouseOver(event));
        this.element.on('mouseleave', '.manager-block', (event) => this.onMouseLeave(event));
    }

    onMouseOver(event) {
        const block = $(event.currentTarget);
        this.createLabel(block);
        block.addClass('manager-block--hover');
    }

    onMouseLeave(event) {
        const block = $(event.currentTarget);
        block.removeClass('manager-block--hover');
    }

    createLabel(block) {
        const label = block.find('[data-manager-block__label]');

        if (label.length === 0) {
            $('<span/>')
                .addClass('manager-block__label')
                .attr('data-manager-block__label', '')
                .text(block.attr('data-property-label'))
                .appendTo(block);
        }
    }
}