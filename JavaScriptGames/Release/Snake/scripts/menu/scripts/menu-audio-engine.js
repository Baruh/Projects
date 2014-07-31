var menuAudioEngine = (function($) {
	'use strict';
	var clickSound,
		mouseoverSound;

	if (hasMP3Support()) {
		clickSound = new Audio('scripts/menu/audio/click.mp3');
		mouseoverSound = new Audio('scripts/menu/audio/mouseover.mp3');
	} else {
		clickSound = new Audio('scripts/menu/audio/click.wav');
		mouseoverSound = new Audio('scripts/menu/audio/mouseover.wav');
	}

	// Visible functions
	function addClickEvents(selector) {
		selector = selector || '.menu-buttons';

		$(selector)
			.on('click', function() {
				clickSound.play();
			});
	}

	function addMouseoverEvents(selector) {
		selector = selector || '.menu-buttons';

		$(selector)
			.on('mouseover', function() {
				mouseoverSound.play();
			});
	}

	// Hidden helper functions
	function hasMP3Support() {
		var a = document.createElement('audio');
		return !!(a.canPlayType && a.canPlayType('audio/mpeg;').replace(/no/, ''));
	}

	return {
		addClickEvents: addClickEvents,
		addMouseoverEvents: addMouseoverEvents
	};
}(jQuery));