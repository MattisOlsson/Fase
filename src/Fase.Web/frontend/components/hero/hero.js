import extend from 'extend';
import Animate from '../animate/animate.js';
import $ from 'jquery';
import root from 'window-or-global';

export default class Hero {
    constructor(element, options) {
        this.options = extend({}, options);
        this.element = $(element);
        this.loader = this.element.find('[data-hero__loader]');
        this.isVideo = this.element.hasClass('hero--video');

        if (this.isVideo) {
            this.initVideo();
        }
        else {
            root.setTimeout(() => {
                this.loader
                    .removeClass('hero__loader--active')
                    .removeClass('hero__loader--semi-active');
            }, 500);
        }
    }

    initVideo() {
        let isInitialized = false;

        root.setTimeout(() => {
            if (!isInitialized) {
                this.loader
                    .removeClass('hero__loader--semi-active')
                    .addClass('hero__loader--active');
            }
        }, 200);

        // To make sure the hero is shown even if video events is not fired.
        root.setTimeout(() => {
            if (!isInitialized) {
                new Animate(this.element.find('[data-hero__content__inner]'), { mode: 'onload' });
                this.loader
                    .removeClass('hero__loader--active')
                    .removeClass('hero__loader--semi-active');
            }
        }, 2000);

        const video = this.element.find('[data-hero__video]');
        const videoDom = video.get(0);

        video.find('source').each((_, source) => {
            source.setAttribute('src', source.getAttribute('data-src'));
        });

        const onVideoReady = () => {
            new Animate(this.element.find('[data-hero__content__inner]'), { mode: 'onload' });
            this.loader
                .removeClass('hero__loader--active')
                .removeClass('hero__loader--semi-active');
            videoDom.removeEventListener('canplaythrough', onVideoReady);
            isInitialized = true;
        };

        videoDom.addEventListener('canplaythrough', onVideoReady);
        videoDom.load();
    }
}