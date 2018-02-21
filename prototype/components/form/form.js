import $ from 'jquery';
import extend from 'extend';
import Loader from '../loader/loader.js';

export default class Form {
    constructor(element, options) {
        this.options = extend({}, options);
        this.form = $(element);
        this.form.on('submit', (event) => this.submit(event));
    }

    submit(event) {
        event.preventDefault();

        this.form.find('.form__error').remove();

        $.ajax({
            url: this.form.attr('action'),
            data: this.form.serialize(),
            method: this.form.attr('method'),
            beforeSend: () => Loader.show()
        })
            .then((response) => this.handleResponse(response))
            .catch(error => this.handleError(error));

        return false;
    }

    handleResponse(response) {
        Loader.hide();

        if (response.Success) {
            window.location = response.Data.ReturnUrl;
        }
        else {
            var modelState = response.Data;

            if (modelState) {
                modelState.forEach((state) => this.handleState(state));
            }
            else {
                window.console.log(response.Message);
            }
        }
    }

    handleError(error) {
        Loader.hide();
        window.console && window.console.log(error);
    }

    handleState(state) {
        let formElement = this.form.find('[name="' + state.Name + '"]');
        let errorElement = this.form.find('#' + state.Name + '-error');

        if (errorElement.length === 0) {
            errorElement = $('<div/>')
                .attr('id', '#' + state.Name + '-error')
                .addClass('form__error')
                .css('visibility', 'hidden')
                .insertBefore(formElement);
        }

        let formElementWidth = formElement.outerWidth(true);

        errorElement
            .html(state.Errors.join(', '))
            .css({
                top: formElement.offset().top - errorElement.outerHeight(true) - 5,
                left: formElement.offset().left + ((formElementWidth - errorElement.outerWidth(true)) * 0.5),
                visibility: 'visible'
            });
    }
}