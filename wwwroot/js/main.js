const heroSlider = new Splide('#heroSlider', {
    perPage: 8,
    gap: '30px',
    pagination: false,
    arrows: false,
    type: 'loop',
    drag: 'free',
    focus: 'center',
    autoScroll: {
        speed: 1,
    },
});

const popularSlider = new Splide('#popularSlider', {
    perPage: 4,
    gap: '30px',
    pagination: true
});

heroSlider.mount(window.splide.Extensions);
popularSlider.mount();

