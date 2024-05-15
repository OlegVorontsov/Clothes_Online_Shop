const productMain = new Splide('#productMain', {
    height: '787px',
    type: 'fade',
    heightRatio: 0.5,
    pagination: false,
    arrows: false,
    cover: true,
});

const productThumbnail = new Splide('#productThumbnail', {
    direction: 'ttb',
    height: '742px',
    wheel: true,
    rewind: true,
    fixedWidth: 68,
    fixedHeight: 102,
    isNavigation: true,
    gap: 20,
    focus: 'center',
    pagination: false,
    cover: true,
    dragMinThreshold: {
        mouse: 4,
        touch: 10,
    },
    breakpoints: {
        640: {
            fixedWidth: 66,
            fixedHeight: 38,
        },
    },
});

productMain.sync(productThumbnail);
productMain.mount();
productThumbnail.mount();

