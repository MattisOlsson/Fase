/* eslint-disable */

const SitemapGenerator = require('sitemap-generator');
const sitemapGenerator = SitemapGenerator('http://www.dryckeskultur.com', {
    stripQuerystring: true
});

module.exports = function (gulp) {
    return sitemapGenerator.start;
};