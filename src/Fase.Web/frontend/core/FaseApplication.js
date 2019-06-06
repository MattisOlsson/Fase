import $ from 'jquery';
import initElements from './utils/init-elements.js';
import AnchorLink from '../components/anchor/anchor-link.js';
import Header from '../components/header/header.js';
import Hero from '../components/hero/hero.js';
import Navigation from '../components/navigation/navigation.js';
import Form from '../components/form/form.js';
import Animate from '../components/animate/animate.js';
import root from 'window-or-global';

const onTouchStart = () => {
    root.removeEventListener('touchstart', onTouchStart, false);
    $('html').addClass('touch-device');
};

class FaseApplication {
    constructor() {
        this.attachGlobalEvents();
        $(root.document).ready(() => this.init());
        $(root).on('load', () => this.load());
    }

    attachGlobalEvents() {
        root.addEventListener('touchstart', onTouchStart, false);
    }

    init() {
        initElements('[data-header]', Header);
        initElements('[data-hero]', Hero);
        this.navigations = initElements('[data-navigation]', Navigation, {
            isActive: false
        });

        initElements('[data-anchor-link]', AnchorLink);
        initElements('[data-form]', Form);
    }

    load() {
        initElements('[data-animate]', Animate);
    }
}

const app = new FaseApplication();
export default app;