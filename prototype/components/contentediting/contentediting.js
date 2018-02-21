import $ from 'jquery';

export default class ContentEditing {
    constructor() {
        this.contentTools = window.ContentTools;

        this.contentTools.StylePalette.add([
            new this.contentTools.Style('Author', 'author', ['p'])
        ]);

        this.editor = this.contentTools.EditorApp.get();
        this.editor.addEventListener('saved', (event) => this.onSaved(event));
        this.editor.init('*[data-editable]', 'data-name');
    }

    onSaved(event) {
        let detail = event.detail();
        let passive = detail.passive;
        let regions = detail.regions;

        this.editor.busy(true);

        let payload = {};

        payload['__page__'] = this.getLocationPathName();

        for (var name in regions) {
            payload[name] = regions[name];
        }

        $.ajax({
            url: '/contentediting/save',
            method: 'post',
            data: payload,
            dataType: 'json'
        })
            .then(() => { this.editor.busy(false); })
            .catch(() => { this.editor.busy(false); });
    }

    getLocationPathName() {
        let htmlFileName = window.location.pathname;

        if (htmlFileName === '/')
            htmlFileName = '/index.html';

        return htmlFileName;
    }
    /*
    makeEditable() {
        this.main.find(this.options.editableElements)
            .attr('contenteditable', true)
            .addClass('content-editable')
            .on('blur.contentediting', () => this.onEditableElementBlur());
    }

    makeReadonly() {
        this.main.find(this.options.editableElements)
            .attr('contenteditable', null)
            .removeClass('content-editable')
            .off('blur.contentediting');
    }

    onEditableElementBlur() {
        this.makeReadonly();
        this.saveCurrentDocument();
        this.makeEditable();
    }

    saveCurrentDocument() {
        let html = this.main.html();
        let htmlFileName = window.location.pathname;

        if (htmlFileName === '/')
            htmlFileName = '/index.html';

        let postData = {
            file: htmlFileName,
            html: html
        };

        $.ajax({
            url: '/contentediting/save',
            method: 'post',
            data: JSON.stringify(postData),
            contentType: 'application/json; charset=UTF-8',
            dataType: 'json'
        });

        window.console.log(postData);
    }
    */
}