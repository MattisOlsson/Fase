import $ from 'jquery';

export default class Loader {
    static show() {
        $('body').addClass('state--loading');
    }

    static hide() {
        $('body').removeClass('state--loading');
    }
}