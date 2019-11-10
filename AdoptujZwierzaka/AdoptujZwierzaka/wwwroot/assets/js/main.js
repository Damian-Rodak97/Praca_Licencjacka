(function($) {
"use strict";

/*------------------------------------------------------------------
[Table of contents]

1. my pie chart function
2. my owl function
3. custom function
4. Preloader
5. blog grid item list
6. portfolio gird
7. number counter and skill bar animation
8. waypoint init
9. skill bar and number counter
10. mega navigation menu init
11. video popup
12. image popup
13. xs pie chart list
14. slider wating to adopt
15. client slider
16. back to top
17. Contact From dynamic
18. image popup for adoption feature
19. map window opener add class
20. wow animation init
21. Skrollr Init
22. Newsletter
23. current menu item add class active
24. XpeedStudio multipile Maps
25. XpeedStudio Maps


-------------------------------------------------------------------*/

/*======================================================================
		1. my pie chart function
======================================================================*/
$.fn.myChart = function (options) {
	var settings = $.extend ({
		lineWidth: 5,
		size: 100,
		trackColor: "#ececec",
		barColor: "#4dc177",
		scaleColor: "transparent"
	}, options);

	return this.easyPieChart ({
		lineWidth: settings.lineWidth,
		size: settings.size,
		trackColor: settings.trackColor,
		barColor: settings.barColor,
		scaleColor: settings.scaleColor
	})
}

/*======================================================================
		2. my owl function
======================================================================*/
$.fn.myOwl = function (options) {
	var settings = $.extend({
		items: 3,
		loop: true,
		center: false,
		margin: 0,
		stagePadding: 0,
		smartSpeed: 250,
		responsive: {},
		mouseDrag: true,
		touchDrag: true,
		animateOut: '',
		animateIn: '',
		dots: false,
		nav: false,
		navText: ['', ''],
		autoplay: false,
		autoplayTimeout: 5000,
		autoplayHoverPause: true,
		responsive: {}
	}, options);

	return this.owlCarousel ({
		items: settings.items,
		loop: settings.loop,
		center: settings.center,
		margin: settings.margin,
		stagePadding: settings.stagePadding,
		smartSpeed: settings.smartSpeed,
		mouseDrag: settings.mouseDrag,
		touchDrag: settings.touchDrag,
		dots: settings.dots,
		nav: settings.nav,
		navText: settings.navText,
		autoplay: settings.autoplay,
		autoplayTimeout: settings.autoplayTimeout,
		autoplayHoverPause: settings.autoplayHoverPause,
		animateOut: settings.animateOut,
		animateIn: settings.animateIn,
		responsive: settings.responsive,
	})
}
/*==========================================================
			3. custom function
======================================================================*/
function xsFunction() {
	var xsContact = $('.xs-contact-form-wraper'),
		xsMap = $('.map-wraper-v2'),
		donateImg = $('.donate-card.highlight .donate-card-image'),
		donateContent = $('.donate-card.highlight .donate-content'),
		tree = $('.tree-svg-shape'),
		svgShape = $('.xs-svg-shape-bg'),
		treeWraper = $('.tree-shape'),
		wWidth = $(window).width();

		if (wWidth < 2000) {
			svgShape.removeAttr('height');
			svgShape.removeAttr('width');
			tree.removeAttr('width');
			treeWraper.css('left', -100+'px');
		} else {
			svgShape.attr('height', 100+'%');
			svgShape.attr('width', wWidth);
			tree.attr('width', wWidth);
			tree.attr('height', (100+'%'));
			treeWraper.css('left', 0+'px');
		}

		xsMap.css('height', xsContact.outerHeight());
		$(window).on('resize', function () {
			$(window).width() > 1024 ? donateContent.css('height', donateImg.outerHeight()) : donateContent.css('height', 'auto')
		});
}


$(window).on('load', function() {

	/*==========================================================
				4. Preloader
	=======================================================================*/
	setTimeout(() => {
		$('#preloader').addClass('loaded');
	}, 1000);


	//my custom function init
	xsFunction();

	/*==========================================================
			5. blog grid item list			
	=======================================================================*/
	if($('.xs-news-feed-grid').length >0) {
		var $portfolioGrid = $('.xs-news-feed-grid'),
		colWidth = function () {
		  var w = $portfolioGrid.width(), 
			columnNum = 1,
			columnWidth = 0;
		  if (w > 1200) {
			columnNum  = 4;
		  } else if (w > 900) {
			columnNum  = 4;
		  } else if (w > 600) {
			columnNum  = 2;
		  } else if (w > 450) {
			columnNum  = 1;
		  } else if (w > 385) {
			columnNum  = 1;
		  }
		  columnWidth = Math.floor(w/columnNum);
		  $portfolioGrid.find('.xs-news-feed-grid-item').each(function() {
			var $item = $(this),
			  multiplier_w = $item.attr('class').match(/xs-news-feed-grid-item-w(\d)/),
			  multiplier_h = $item.attr('class').match(/xs-news-feed-grid-item-h(\d)/),
			  width = multiplier_w ? columnWidth*multiplier_w[1] : columnWidth,
			  height = multiplier_h ? columnWidth*multiplier_h[1]*0.4-12 : columnWidth*0.5;
			$item.css({
			  width: width,
			  //height: height
			});
		  });
		  return columnWidth;
		},
		isotope = function () {
		  $portfolioGrid.isotope({
			resizable: false,
			itemSelector: '.xs-news-feed-grid-item',
			masonry: {
			  columnWidth: colWidth(),
			  gutterWidth: 3
			}
		  });
		};
	  isotope();
	  $(window).resize(isotope);
	  } // End if

	/*==========================================================
			6. portfolio gird
	======================================================================*/
	if($('.xs-portfolio-grid').length >0) {
		var $portfolioGrid = $('.xs-portfolio-grid'),
		colWidth = function () {
		  var w = $portfolioGrid.width(), 
			columnNum = 1,
			columnWidth = 0;
		  if (w > 1200) {
			columnNum  = 3;
		  } else if (w > 900) {
			columnNum  = 3;
		  } else if (w > 600) {
			columnNum  = 2;
		  } else if (w > 450) {
			columnNum  = 2;
		  } else if (w > 385) {
			columnNum  = 1;
		  }
		  columnWidth = Math.floor(w/columnNum);
		  $portfolioGrid.find('.xs-portfolio-grid-item').each(function() {
			var $item = $(this),
			  multiplier_w = $item.attr('class').match(/xs-portfolio-grid-item-w(\d)/),
			  multiplier_h = $item.attr('class').match(/xs-portfolio-grid-item-h(\d)/),
			  width = multiplier_w ? columnWidth*multiplier_w[1] : columnWidth,
			  height = multiplier_h ? columnWidth*multiplier_h[1]*0.4-12 : columnWidth*0.5;
			$item.css({
			  width: width,
			  //height: height
			});
		  });
		  return columnWidth;
		},
		isotope = function () {
		  $portfolioGrid.isotope({
			resizable: false,
			itemSelector: '.xs-portfolio-grid-item',
			masonry: {
			  columnWidth: colWidth(),
			  gutterWidth: 0
			}
		  });
		};
	  isotope();
	  $(window).resize(isotope);
	  } // End if

}); // END load Function 

$(document).ready(function() {

	//my custom function init
	xsFunction();

	/*==========================================================
			7. number counter and skill bar animation
	=======================================================================*/

	var number_percentage = $(".number-percentage");
	function animateProgressBar(){
		number_percentage.each(function() {
		$(this).animateNumbers($(this).attr("data-value"), true, parseInt($(this).attr("data-animation-duration"), 10));
				var value = $(this).attr("data-value");
				var duration = $(this).attr("data-animation-duration");
		$(this).closest('.xs-skill-bar').find('.xs-skill-track').animate({
			width: value + '%'
			}, 4500);
		});
	}

	/*==========================================================
			8. waypoint init
	=======================================================================*/
	if ($('.waypoint-tigger').length > 0) {
		var waypoint = new Waypoint({
			element: document.getElementsByClassName('waypoint-tigger'),
			handler: function(direction) {
				animateProgressBar();
			}
		});
	}

	/*==========================================================
			9. skill bar and number counter
	=======================================================================*/
	$.fn.animateNumbers = function(stop, commas, duration, ease) {
		return this.each(function() {
			var $this = $(this);
			var start = parseInt($this.text().replace(/,/g, ""), 10);
			commas = (commas === undefined) ? true : commas;
			$({
				value: start
			}).animate({
				value: stop
			}, {
				duration: duration == undefined ? 500 : duration,
				easing: ease == undefined ? "swing" : ease,
				step: function() {
					$this.text(Math.floor(this.value));
					if (commas) {
						$this.text($this.text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
					}
				},
				complete: function() {
					if (parseInt($this.text(), 10) !== stop) {
						$this.text(stop);
						if (commas) {
							$this.text($this.text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
						}
					}
				}
			});
		});
	};

	/*==========================================================
			10. mega navigation menu init
	======================================================================*/
	if ($('.xs-menus').length > 0) {
		$('.xs-menus').xs_nav({
			mobileBreakpoint: 992,
		});
	}


	/*=============================================================
					11. video popup
	=========================================================================*/
	if ($('.xs-video-popup').length > 0) {
		$('.xs-video-popup').magnificPopup({
			disableOn: 700,
			type: 'iframe',
			mainClass: 'mfp-fade',
			removalDelay: 160,
			preloader: false,
			fixedContentPos: false
		});
	}

	/*=============================================================
					12. image popup
	=========================================================================*/
	$('.xs-image-popup').magnificPopup({
		type: 'image',
		closeOnContentClick: false,
		closeBtnInside: false,
		mainClass: 'mfp-with-zoom mfp-img-mobile',
		gallery: {
			enabled: true
		},
		zoom: {
			enabled: true,
			duration: 300, // don't foget to change the duration also in CSS
		}
		
	});

	/*=============================================================
					13. xs pie chart list
	=========================================================================*/
	if ($('.xs-chart').length > 0) {
		$('.xs-chart').myChart({
			size: 160
		});	
	}
	if ($('.xs-chart-v2').length > 0) {
		$('.xs-chart-v2').myChart({
			size: 120
		});	
	}
	if ($('.xs-chart-v3').length > 0) {
		$('.xs-chart-v3').myChart();	
	}
	  
	/*==========================================================
				14. slider wating to adopt
	======================================================================*/
	if ( $( '.slider-wating-to-adopt' ).length > 0 ) {
		var watingToAdopt = $( ".slider-wating-to-adopt" );
		watingToAdopt.myOwl( {
			items: 4,
			nav: true,
			navText: ['<i class="icon icon-left-arrow2 xs-round-nav"></i>','<i class="icon icon-right-arrow2 xs-round-nav"></i>'],
			responsive : {
				// breakpoint from 0 up
				0 : {
					nav: false,
					items: 1,
				},
				// breakpoint from 480 up
				480 : {
					nav: false,
					items: 2,
				},
				// breakpoint from 768 up
				768 : {
					nav: false,
					items: 2,
				},
				992 : {
					nav: true,
					items: 4,
				}
			}
		});
	}

	/*==========================================================
				15. client slider
	======================================================================*/
	if ( $( '.xs-client-slider' ).length > 0 ) {
		var sixColumn = $( ".xs-client-slider" );
		sixColumn.myOwl( {
			items: 6,
			responsive : {
				// breakpoint from 0 up
				0 : {
					items: 1,
				},
				// breakpoint from 480 up
				480 : {
					items: 3,
				},
				// breakpoint from 768 up
				768 : {
					items: 3,
				},
				992 : {
					items: 6,
				}
			}
		});
	}

	if ($('.banner-slider').length > 0) {
		$('.banner-slider').myOwl({
			nav: true,
			navText: ['<i class="fa fa-angle-left xs-round-nav"></i>','<i class="fa fa-angle-right xs-round-nav"></i>'],
			items: 1,
			responsive: {
				0: {
					nav: false
				},
				1024: {
					nav: true
				}
			}
		})
	}

	/*==========================================================
			16. back to top
	======================================================================*/ 
	$(document).on('click', '.xs-back-to-top', function(event) {
		event.preventDefault();
		/* Act on the event */

		$('html, body').animate({
			scrollTop: 0,
		}, 1000);
	});

	/*=====================================================
			17. Contact From dynamic
	 =====================================================*/
	 if ($('#xs-contact-form').length > 0) {
		$('#xs-contact-form').on('submit', function(event) {
			event.preventDefault();
	
			$('.xpeedStudio_success_message').remove();
	
			var name = $('#xs-name'),
				email = $('#xs-email'),
				massage = $('#xs-massage'),
				submit = $('#xs-submit'),
				error = false;
			
			if(name.val() === '') {
				error = true;
				name.parent().addClass('invaild');
				name.focus();
				return false;
			} else {
				name.parent().removeClass('invaild');
			}
			if (!email_patern(email.val().toLowerCase())) {
				error = true;
				email.parent().addClass('invaild');
				email.focus();
				return false;
			} else if(email.val() === '') {
				error = true;
				email.parent().addClass('invaild');
				email.focus();
				return false;
			} else {
				email.parent().removeClass('invaild');
			}
			if(massage.val() === '') {
				error = true;
				massage.parent().addClass('invaild');
				massage.focus();
				return false;
			} else {
				massage.parent().removeClass('invaild');
			}
	
			if (error === false) {
				$.ajax({
						type: "POST",
						url: "assets/php/contact-form.php",
						data: {
						'name' : name.val(),
						'email' : email.val(),
						'massage' : massage.val()
					},
					success: function(result){
						submit.after('<p class="xpeedStudio_success_message">' + result + '</p>').fadeIn();
						setTimeout(() => {
							$('.xpeedStudio_success_message').fadeOut();
						}, 3000);
						$('#xs-contact-form')[0].reset();
					}
				});
			}
		});
	}

	/*=============================================================
					18. image popup for adoption feature
	=========================================================================*/
	if ( $( '.xs-image-popup-2' ).length > 0 ) {
		$( '.xs-image-popup-2' ).magnificPopup( {
			type: 'image',
			removalDelay: 500, //delay removal by X to allow out-animation
			callbacks: {
				beforeOpen: function ( ) {
				// just a hack that adds mfp-anim class to markup
					this.st.image.markup = this.st.image.markup.replace( 'mfp-figure', 'mfp-figure mfp-with-anim' );
					this.st.mainClass = 'mfp-zoom-in';
				}
			},
			closeOnContentClick: true,
			midClick: true,
			gallery: {
				enabled: true,
			},
		});
	}

	/*==========================================================
			19. map window opener add class
	======================================================================*/
	$(document).on('click', '.xs-window-opener', function() {
		event.preventDefault();

		var main_wraper = $('.xs-widnow-wraper'),
			active_class= 'active';

		if ($(this).parent().parent().hasClass(active_class)) {
			$(this).parent().parent().removeClass(active_class);
		} else {
			main_wraper.removeClass(active_class);
			$(this).parent().parent().addClass(active_class);
		}
	});

	/*=============================================================
					20. wow animation init
	=========================================================================*/
	$(function(){
		var wow = new WOW({
			boxClass: 'wow',
			animateClass: 'animated',
			offset: 0,
			mobile: false,
			live: true,
			scrollContainer: null,
		});
		wow.init();
	});

	/*=============================================== 
      			21. Skrollr Init
  	================================================*/
	var mySkrollr = skrollr.init({
		forceHeight: false,
		easings: {
			easeOutBack: function (p, s) {
				s = 1.70158;
				p = p - 1;
				return (p * p * ((s + 1) * p + s) + 1);
			}
		},
		mobileCheck: function() {
			return false;
		}
	});

	/*==========================================================
				22. Newsletter
	=======================================================================*/
	if ($('#newsletter-form').length > 0) {
		$('#newsletter-form').ajaxChimp({
			url: 'https://facebook.us8.list-manage.com/subscribe/post?u=85f515a08b87483d03fee7755&amp;id=66389dc38b'
		});
	}

	$('.preloader-cancel-btn').on('click', function(event) {
		event.preventDefault();
		if (!$('#preloader').hasClass('loaded')) {
			$('#preloader').addClass('loaded');
		}
	});

	/*==========================================================
				23. current menu item add class active
	=======================================================================*/
	let url = window.location.pathname,
    	activePage = url.substr(url.lastIndexOf('/')+1);
    $('.xs-menus .nav-menu li a').each(function(){  
        var currentPage = this.href.substr(this.href.lastIndexOf('/')+1);

        if (activePage == currentPage) {
			$(this).addClass("active");
			if ($(this).parent().parent('.nav-dropdown')) {
				$(this).parent().parent().parent('li').addClass('active');
			}
			$(this).parent().addClass('active');
        } 
	});
}); // end ready function

$(window).on('scroll', function() {

}); // END Scroll Function 

$(window).on('resize', function() {

	//my custom function init
	xsFunction();

}); // End Resize

/*==========================================================
			24. XpeedStudio multipile Maps
======================================================================*/

if (($('#xs-multiple-map-1').length > 0) && ($('#xs-multiple-map-2').length > 0) && ($('#xs-multiple-map-3').length > 0)) {

	var latlng = new google.maps.LatLng(28.561287,-81.444465),
		latlng2 = new google.maps.LatLng(28.507561,-81.482359),
		latlng3 = new google.maps.LatLng(29.125285,-82.048823);

	var myOptions = {
		zoom: 3,
		center: latlng,
		scrollwheel: false,
		navigationControl: false,
		mapTypeControl: true,
		scaleControl: false,
		draggable: true,
		disableDefaultUI: true,
		mapTypeId: google.maps.MapTypeId.ROADMAP,
	};

	var myOptions2 = {
		zoom: 3,
		center: latlng,
		scrollwheel: false,
		navigationControl: false,
		mapTypeControl: true,
		scaleControl: false,
		draggable: true,
		disableDefaultUI: true,
		mapTypeId: google.maps.MapTypeId.ROADMAP,
	};

	var myOptions3 = {
		zoom: 3,
		center: latlng,
		scrollwheel: false,
		navigationControl: false,
		mapTypeControl: true,
		scaleControl: false,
		draggable: true,
		disableDefaultUI: true,
		mapTypeId: google.maps.MapTypeId.ROADMAP,
	};


	var map = new google.maps.Map(document.getElementById("xs-multiple-map-1"), myOptions),
		map2 = new google.maps.Map(document.getElementById("xs-multiple-map-2"), myOptions2),
		map3 = new google.maps.Map(document.getElementById("xs-multiple-map-3"), myOptions3);

	var myMarker = new google.maps.Marker({
		position: latlng,
		map: map,
		title:"Barnett Park"
	});

	var myMarker2 = new google.maps.Marker({
		position: latlng2,
		map: map2,
		title:"Bill Fredrick Park at Turkey Lake"
	});

	var myMarker3 = new google.maps.Marker( {
		position: latlng3,
		map: map3,
		title:"Dogwood Park"
	});
}

/*==========================================================
			25. XpeedStudio Maps
======================================================================*/

if($('#xs-map').length > 0) {
	// When the window has finished loading create our google map below
	google.maps.event.addDomListener(window, 'load', init);
}
function init() {
	// Basic options for a simple Google Map
	
	var mapOptions = {
		// How zoomed in you want the map to start at (always required)
		zoom: 11,
		scrollwheel: false,
		navigationControl: false,
		mapTypeControl: true,
		scaleControl: false,
		draggable: true,
		disableDefaultUI: true,

		// The latitude and longitude to center the map (always required)
		center: new google.maps.LatLng(40.6700, -73.9400), // New York

		// How you would like to style the map. 
		// This is where you would paste any style found on Snazzy Maps.
		styles: [{"featureType":"water","elementType":"geometry","stylers":[{"color":"#e9e9e9"},{"lightness":17}]},{"featureType":"landscape","elementType":"geometry","stylers":[{"color":"#f5f5f5"},{"lightness":20}]},{"featureType":"road.highway","elementType":"geometry.fill","stylers":[{"color":"#ffffff"},{"lightness":17}]},{"featureType":"road.highway","elementType":"geometry.stroke","stylers":[{"color":"#ffffff"},{"lightness":29},{"weight":0.2}]},{"featureType":"road.arterial","elementType":"geometry","stylers":[{"color":"#ffffff"},{"lightness":18}]},{"featureType":"road.local","elementType":"geometry","stylers":[{"color":"#ffffff"},{"lightness":16}]},{"featureType":"poi","elementType":"geometry","stylers":[{"color":"#f5f5f5"},{"lightness":21}]},{"featureType":"poi.park","elementType":"geometry","stylers":[{"color":"#dedede"},{"lightness":21}]},{"elementType":"labels.text.stroke","stylers":[{"visibility":"on"},{"color":"#ffffff"},{"lightness":16}]},{"elementType":"labels.text.fill","stylers":[{"saturation":36},{"color":"#333333"},{"lightness":40}]},{"elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"transit","elementType":"geometry","stylers":[{"color":"#f2f2f2"},{"lightness":19}]},{"featureType":"administrative","elementType":"geometry.fill","stylers":[{"color":"#fefefe"},{"lightness":20}]},{"featureType":"administrative","elementType":"geometry.stroke","stylers":[{"color":"#fefefe"},{"lightness":17},{"weight":1.2}]}]
	};

	// Get the HTML DOM element that will contain your map 
	// We are using a div with id="map" seen below in the <body>
	var mapElement = document.getElementById('xs-map');

	// Create the Google Map using our element and options defined above
	var map = new google.maps.Map(mapElement, mapOptions);

	// Let's also add a marker while we're at it
	var marker = new google.maps.Marker({
		position: new google.maps.LatLng(40.6700, -73.9400),
		map: map,
		title: 'Snazzy!'
	});
}

})(jQuery);