const heroSlider = new Splide('#heroSlider', {
  perPage: 3,
  gap: '30px',
  pagination: false,
    arrows: false,
    type: 'loop',
    drag: 'free',
    focus: 'center',
    autoScroll: {
        speed: -1,
    },
})

heroSlider.mount(window.splide.Extensions)

