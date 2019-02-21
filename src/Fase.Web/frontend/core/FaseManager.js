import $ from 'jquery';
import initElements from './utils/init-elements.js';
import ManagerBlock from '../components/manager-block/manager-block.js';
import root from 'window-or-global';

class FaseManager {
    constructor() {
        $(root.document).ready(() => this.init());
    }

    init() {
        initElements(root.document, ManagerBlock);
    }
}

const app = new FaseManager();
export default app;