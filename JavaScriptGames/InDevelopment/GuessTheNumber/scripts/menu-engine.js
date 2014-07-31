var menuEngine = (function($) {
	'use strict';

	// Visible functions
	function resetMenu() {
		$('#username-field').off();
		$('#game-sceen').hide();
		$('#game-login').hide();
		$('#game-scores').hide();
		$('#game-help').hide();
		$('#game-menu').show();		
	}

	// Hidden helper functions
	function bindButtonsEvents() {

		// esc key event for going to start menu
		$(document).keyup(function(e) {
			if (e.keyCode === 27) {				
				resetMenu();
				// FIXE hack
				history.go(0);
			}
		});

		$('.menu-buttons')
		.on('click', function() {
			var id = this.id;

			$('embed').remove();
			$('body').append('<embed src="audio/click.wav" autostart="true" hidden="true" loop="false">');
			
			loadButtonRequest(id);
		});
	}

	function loadButtonRequest(buttonID) {
		switch (buttonID) {
			case 'play-button':
				loadInitializationPage();
				break;
			case 'help-button':
				loadHelp();
				break;
			case 'credits-button':
				loadScores();
				break;
			case 'start-button':
				loadTheGame();
				break;
		}
	}

	function loadInitializationPage() {
		$('#game-menu').hide();
		$('#game-login').show();
	}

	function loadTheGame() {
		var username = $('#username-field').val();

		if (isUsernameValid(username)) {
			$('#game-login').hide();

			// Enter point for the whole game
			startGame(username);
		} else {
			$('#username-field')
				.balloon({
					contents: 'Username need to be at least 3 symbols.',
					position: 'top',					
					showDuration: 500,
					css: {
						border: 'solid 4px #5baec0',
						padding: '5px',
						fontSize: '120%',
						fontWeight: 'bold',
					    lineHeight: '3',
					    backgroundColor: '#666',
					    color: 'red'
					  }					
				});
		}
	}

	function isUsernameValid(username) {
		if (3 <= username.length && username.length <= 35) {
			return true;
		}

		return false;
	}


	function loadHelp() {
		$('#game-menu').hide();
		$('#game-help').show();
	}

	function createHelp() {
		$('<p />')
			.attr({
				'id': 'description'
			})
			.css({
				'font-size': '1.9em',
				'color': '#f2e8d5'
			})
			.text('Simple number guessing game. The computer generates a random number with four ' + 
					'different digits. At each turn the player enters a four-digit number. ' +
					'For simplicity called xyzw. Sheep means that a digit from xyzw is contained in ' +
					'abcd, but not on the same position.' +
					'The game continues until the player guesses the number abcd.')
		.appendTo('#game-help');
	}

	function loadScores() {
		$('#game-menu').hide();
		$('#game-scores').show();
	}
	
	function createScoresList() {
		var scores = scoreEngine.getBestPlayers(),
			len = scores.length,
			$table = $('<table/>')
						.append('<caption>Best players</caption>')
						.append('<thead><tr><th>Username</th><th>Score</th></tr></thead>'),
			$tableBody = $('<tbody />'),
			i;

		for (i = 0; i < len; i += 1) {
			$tableBody.append('<tr><td>' + scores[i].player + '</td><td>' + scores[i].score + '</td></tr>');
		}

		$table.append($tableBody);
		$('#game-scores').append($table);
	}

	function startGame(username) {
		$('#game-sceen').show();

		gameEngine.start(username);
	}
	
	function initAllMenus() {
		createScoresList();
		createHelp();
	}

	return {
		startScreen: function() {			
			initAllMenus();
			resetMenu();
			bindButtonsEvents();
		},
		resetStartScreen: function() {			
			resetMenu();
		}
	};
}(jQuery));