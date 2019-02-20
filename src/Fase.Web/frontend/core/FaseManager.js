import $ from 'jquery';
import initElements from './utils/init-elements.js';
import ManagerBlock from '../components/manager-block/manager-block.js';

export default class FaseManager {
    constructor() {
        $(document).ready(() => this.init());
    }

    init() {
        initElements(document, ManagerBlock);
    }
}