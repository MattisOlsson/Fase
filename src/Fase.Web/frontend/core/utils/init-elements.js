import $ from 'jquery';

function newClass(selector, Class, el, options) {
    let dataAttributeOptions;

    if (typeof(selector) === 'string') {
        dataAttributeOptions = getOptions(selector, el);
    }

    let mergedOptions = $.extend({}, options, dataAttributeOptions);
    return new Class(el, mergedOptions);
}

function getOptions(selector, el){
    var dataAttributeName = getDataAttributeName(selector);
    var options = dataAttributeName ? $(el).data(dataAttributeName) : {};
    return validateOptions(selector, options);
}

function validateOptions(selector, options){
    if(options && typeof options !== 'object'){
        throw new Error(`${selector} contains a ${typeof options}. Expected valid JSON.`);
    }
    return options;
}

function getDataAttributeName(selector){
    var match = selector.match(/\[data-(.*?)\]/);
    return match && match[1] ? match[1] : null;
}

export default (selector, Class, options = {}) => {
    var elements;

    if (typeof(selector) === 'string') {
        selector = selector.trim();
        elements = $(selector);
    } else {
        elements = $(selector);
    }

    return elements
        .toArray()
        .map(el => newClass(selector, Class, el, options));
};