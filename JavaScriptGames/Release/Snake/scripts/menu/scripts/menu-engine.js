var menuEngine = (function($) {
	'use strict';

	// Hidden helper functions
	function resetMenu() {
		$('#game-input-form').hide();
		$('#game-sceen').hide();
		$('#game-credits').hide();
		$('#game-highScores').hide();
		$('#game-help').hide();
		$('#game-wrapper').hide();
		$('#game-menu').show();		
	}

	function bindEscKeyEvent(selector) {
		selector = selector || document;

		// Esc key event for going to start menu
		$(selector).on('keyup', function(e) {
			if ((e.keyCode | 0) === 27) {				
				resetMenu();
			}
		});
	}

	function unbindEscKeyEvent(selector) {
		selector = selector || document;
		$(selector).off('keyup');
	}

	function bindButtonsEvents(selector) {
		selector = selector || '.menu-buttons';

		$(selector).on('click', function() {
			loadButtonRequest(this.id);
		})
	}

	function loadButtonRequest(buttonID) {
		switch (buttonID) {
			case 'newgame-button':
				// Entry point for the whole game
				loadTheGame();
				break;
			case 'highScores-button':
				loadHighScores();				
				break;
			case 'help-button':
				loadHelp();
				break;
			case 'credits-button':
				loadCredits();
				break;
		}
	}


	function loadCredits() {
		$('#game-menu').hide();
		$('#game-credits').show();
	}

	function createCredits() {
		$('<section/>')
			.append($('<h3/>').text('Credits'))
			.append($('<ul/>')
						.append($('<li/>')
									.append($('<span/>').text('Developed'))
									.append($('<span/>').text('Aleksandar Dimov'))
								)
						.append($('<li/>')
									.append($('<span/>').text('Music'))
									.append($('<span/>').text('Ilko Birov'))
								)
					)
			.append($('<footer/>').text('(C) Copyright 2014 by Yashmak Hack'))
		.appendTo($('#game-credits'));				
	}

	function loadTheGame() {
		$('#game-menu').hide();
		unbindEscKeyEvent();
		$('#game-wrapper').show();
		createTheGame('#game-wrapper');		
	}

	function createTheGame(selector) {
		engine.start(selector);
	}

	function loadHelp() {
		$('#game-menu').hide();
		$('#game-help').show();
	}

	function createHelp() {
		var $help = $('<section/>')
						.append($('<h3/>').text('How to Play'))
						.append($('<article/>')
									.text('Snake is a video game concept which originated during the late 1970s in arcades.'
											+ ' The goal is to get as many coins and to make the snake as long as possible.'
											+ ' The player loses when the snake runs the screen border or a trail.')
						);

		$('#game-help').append($help);
	}

	function loadHighScores() {
		$('#game-menu').hide();
		$('#game-highScores').show();
	}
	
	function createScoresList() {
		var scores = scoreEngine.getBestPlayers(),
			len = scores.length,
			$list = $('<ul/>'),
			i;

		for (i = 0; i < len; i += 1) {
			$list.append('<li><span>' + scores[i].player + '</span><span>' + scores[i].score + '</span></li>');
		}

		$('#game-highScores')
			.append($('<h3/>').text('High Scores'))
			.append($list);
	}
	
	function initAllMenus() {
		createScoresList();
		createHelp();
	}

	return {
		initMenu: function() {
			menuAudioEngine.addClickEvents('.menu-buttons');
			menuAudioEngine.addMouseoverEvents('.menu-buttons');
			bindEscKeyEvent();
			bindButtonsEvents();
			createScoresList();
			createHelp();
			createCredits();			
			resetMenu();			
		},
		resetStartScreen: function() {			
			resetMenu();
		}
	};
}(jQuery));