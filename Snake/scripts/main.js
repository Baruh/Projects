(function($){
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
		
	canvas = document.getElementById('main-canvas');
	contex = canvas.getContext('2d');

	function initGame() {		
		contex.clearRect(0, 0, canvas.width, canvas.height);
	 	game = engine;
	 	game.start(canvas);
	 }

}(jQuery));