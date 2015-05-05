/*
	Landed by HTML5 UP
	html5up.net | @n33co
	Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)
*/

(function($) {

	skel.init({
		reset: 'full',
		breakpoints: {
			global: { href: 'css/style.css', containers: '70em', grid: { gutters: ['2.5em', 0] } },
			xlarge: { media: '(max-width: 1680px)', href: 'css/style-xlarge.css' },
			large: { media: '(max-width: 1280px)', href: 'css/style-large.css', containers: '90%', viewport: { scalable: false } },
			medium: { media: '(max-width: 980px)', href: 'css/style-medium.css', containers: '100%!' },
			small: { media: '(max-width: 736px)', href: 'css/style-small.css' },
			xsmall: { media: '(max-width: 480px)', href: 'css/style-xsmall.css' }
		},
		plugins: {
			layers: {

				// Config.
					config: {
						mode: function() { return ((skel.vars.isMobile || skel.vars.browser == 'safari') ? 'transform' : 'position'); }
					},

				// Navigation Panel.
					navPanel: {
						animation: 'pushX',
						breakpoints: 'small',
						clickToHide: true,
						height: '100%',
						hidden: true,
						html: '<div data-action="navList" data-args="nav"></div>',
						orientation: 'vertical',
						position: 'top-left',
						side: 'left',
						width: 250
					},

				// Title Bar.
					titleBar: {
						breakpoints: 'small',
						height: 44,
						html: '<span class="toggle" data-action="toggleLayer" data-args="navPanel"></span><span class="title" data-action="copyText" data-args="logo"></span>',
						position: 'top-left',
						side: 'top',
						width: '100%'
					}

			}
		}
	});

	$(function () {
	    // Dropdowns.
	    $('#nav > ul').dropotron({
	        alignment: 'right',
	        hideDelay: 350
	    });

	})

})(jQuery);