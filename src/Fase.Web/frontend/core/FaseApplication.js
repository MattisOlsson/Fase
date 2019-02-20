import $ from 'jquery';
import initElements from './utils/init-elements.js';
import AnchorLink from '../components/anchor/anchor-link.js';
import Header from '../components/header/header.js';
import Navigation from '../components/navigation/navigation.js';
import Form from '../components/form/form.js';
import Animate from '../components/animate/animate.js';

export default class FaseApplication {
    constructor() {
        this.attachGlobalEvents();
        $(document).ready(() => this.init());
        $(window).on('load', () => this.load());
    }

    attachGlobalEvents() {
        window.addEventListener('touchstart', () => this.onTouchStart(), false);
    }

    onTouchStart() {
        $('html').addClass('touch-device');
        window.removeEventListener('touchstart', this.onTouchStart, false);
    }

    init() {
        initElements('[data-header]', Header);
        initElements('[data-navigation]', Navigation, {
            isActive: false
        });

        initElements('[data-anchor-link]', AnchorLink);
        initElements('[data-form]', Form);
    }

    load() {
        initElements('[data-animate]', Animate);
    }
}