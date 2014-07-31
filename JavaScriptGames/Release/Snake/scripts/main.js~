(function($){
	'use strict';
	var game, canvas, contex;
		
	// Create the main canvas
	$('<canvas />')
		.attr({
			'width': '500px',
			'height': '500px',
			'id': 'main-canvas'
		})
		.css({	
			'background': '#5FCC3B'						
		})
	.appendTo('#game-wrapper');

	// Create the game menu
	$('<button>Start</button><button>Reset</button>')
		.addClass('styled-button')
		.on('click', function() {
			initGame();
		})
	.appendTo($('#menu-wrapper'));
	/*
	$('<div />')
		.addClass('onoffswitch')
		.append(
			$('<input checked>')
				.attr({
					'type': 'checkbox',
					'name': 'onoffswitch',
					'id': 'myonoffswitch'
				})
				.addClass('onoffswitch-checkbox')
		)
		.append(
			$('<label />')
				.attr({
					'for': 'myonoffswitch'
				})
				.addClass('onoffswitch-label')
				.append('<span />')
					.addClass('onoffswitch-inner')
				.append('<span />')
					.addClass('onoffswitch-switch')
				
		)
		.appendTo($('#menu-wrapper'));
   */
	canvas = document.getElementById('main-canvas');
	contex = canvas.getContext('2d');

	function initGame() {		
		contex.clearRect(0, 0, canvas.width, canvas.height);
	 	game = engine;
	 	game.start(canvas);
	 }

}(jQuery));
