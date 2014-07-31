var gameRenderer = (function($) {
	'use strict';
	var computerNumberLength = 4;

	// Visible functions
	function drawPlayerPartOfTheSceen() {
		var i,
			$playerDiv = $('<div />').addClass('player-digits');							
	
		for (i = 0; i < 4; i += 1) {
			$('<input />')
				.attr({
					'type': 'number',
					'min': i > 0 ? 0 : 1,
					'max': 9,
					'value': i > 0 ? 0 : 1,
					'id': 'value' + i.toString()
				})
				.css({
					'width': '40px',
					'height': '40px',
					'font-size': '32px',
					'margin-left': '10px'
				})
			.appendTo($playerDiv);
		}

		$playerDiv.appendTo('#game-sceen');
		$('<div />')
			.attr({
				'id': 'guess-button'
			})
			.text('Guess')
			.addClass('menu-buttons')			
		.appendTo('#game-sceen');
	}

	function drawComputerPartOfTheSceen() {
		var i,
			$computerDiv = $('<div />')
								.attr({
									'id': 'computer-digits-container'
								});

		for (i = 0; i < computerNumberLength; i += 1) {
			$('<div />')
				.attr({
					'id': 'digit' + i.toString()
				})
				.css({
					'display': 'inline-block',
					'margin-left': '10px',
					'border': '3px solid black',
					'width': '60px',
					'font-size': '40px',
					'color': 'lightblue'
				})
				.text('X')
				.addClass('computer-digit')
			.appendTo($computerDiv);
		}

		$computerDiv.appendTo('#game-sceen');
	}

	function drawGuessNumber(id, digit) {
		$('#' + id)
			.css({
				'color': 'red'
			})
			.text(digit);
	}

	function drawAllSheeps() {
		var $sheep = $('<div />')
						.css({
							'display': 'inline-block'
						})
						.addClass('sheep-wrapper')
						.append(	
							$('<img />')
								.attr({
									'src': 'images/sheep.png',
									'alt': 'Sheep',
									'width': 110,
									'height': 91
								})
							),
			$div = $('<div />')
						.attr({
							'id': 'sheep-images-wrapper'
						}),
			i;

		for (i = 0; i < 4; i += 1) {
			$div.append($sheep.clone());
		}

		$('#game-sceen').append($div);
			
		$('.sheep-wrapper').hide();
	}

	function drawGuessedSheeps(count) {
		$('.sheep-wrapper').hide().slice(0, count).show();	
	}

	function drawWin(score) {
		clear();
		$('#game-sceen')
			.append(
				$('<p />')
					.css({
						'font-size': '64px',
						'font-family': '"Times New Roman", Times, serif'
					})
					.text('SCORE: ' + score)
			);
	}

	function clear() {
		$('#game-sceen').empty();
	}

	return {
		clear: clear,
		drawAllSheeps: drawAllSheeps,
		drawComputerPartOfTheSceen: drawComputerPartOfTheSceen,
		drawGuessNumber: drawGuessNumber,
		drawPlayerPartOfTheSceen: drawPlayerPartOfTheSceen,
		drawGuessedSheeps: drawGuessedSheeps,
		drawWin: drawWin
	};
}(jQuery));