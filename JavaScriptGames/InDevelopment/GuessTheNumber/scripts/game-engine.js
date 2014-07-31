var gameEngine = (function($) {
	'use strict';
	var username;

	// Visible functions
	function start(name) {
		username = name;
		createTheGameSceen();
	}

	// Hidden helper functions
	function addEvents() {
		addPlayerInteractionsEvents();
	}

	function addPlayerInteractionsEvents() {
		$('#guess-button')
			.on('click', function() {

				guessesHadler();				
				if (gameLogic.isGameFinished()) {
					saveResult(gameLogic.getScore());
					gameRenderer.drawWin(gameLogic.getScore());
					$(this).off();
				}

				// FIXE: for the click sound
				$('embed').remove();
				$('body').append('<embed src="audio/click.mp3" autostart="true" hidden="true" loop="false">');
			});
	}

	function guessesHadler() {
		var result = gameLogic.checkTheGuess(),
			ramsCount = result.rams.length,
			i;

		if (ramsCount > 0) {
			for (i = 0; i < ramsCount; i += 1) {
				gameRenderer.drawGuessNumber(result.rams[i].id, result.rams[i].digit);
				makeInputBoxReadOnly(result.rams[i].inputBoxID);
			}
		}

		gameRenderer.drawGuessedSheeps(result.sheepsCount);		
	}


	function makeInputBoxReadOnly(inputBoxID) {
		$('#' + inputBoxID)
			.attr({
				'readonly': 'readonly'
			})
			.css({
				'border-color': '#F5CB6F',
				'background-color': '#F5CB6F',
				'text-align': 'center'
			});
	}

	function saveResult(score) {
		if (score < 0) {
			score = 0;
		}		
		scoreEngine.addScore(username, score);
	}

	function createTheGameSceen() {
		gameRenderer.clear();
		gameRenderer.drawComputerPartOfTheSceen();
		gameRenderer.drawPlayerPartOfTheSceen();
		gameRenderer.drawAllSheeps();
		addEvents();
	}

	return {
		start: start
	};
}(jQuery));