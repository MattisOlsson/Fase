import $ from 'jquery';
import initElements from './utils/init-elements.js';
import Navigation from '../components/navigation/navigation.js';

export default class FaseApplication {
    constructor() {
        $(document).ready(() => this.init());
    }

    init() {
        initElements('[data-navigation]', Navigation, {
            isActive: false
        });
    }
}