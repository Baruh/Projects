var audioDirector = (function() {
	'use strict';

	var AudioEngine = (function() {

		// Hidden variables and functions
		var basicThemePath = 'audio/snake_game_main_theme.mp3',
			eatSoundPath = 'audio/coin.wav',
			deathSoundPath = 'audio/game_over.mp3';
			

		function stopAudio(audio) {
			audio.pause(); 
			audio.currentTime = 0;
		};

		function AudioEngine() {		
			this._basicTheme = new Audio(basicThemePath);			
		   this._basicTheme.loop = true;
			this._eatSound = new Audio(eatSoundPath);
			this._deathSound = new Audio(deathSoundPath);
		}

		AudioEngine.prototype.stop = function(sound) {
			switch (sound) {
				case 'theme':
					stopAudio(this._basicTheme);
					break;
				case 'eat':
					stopAudio(this._eatSound);
					break;
				case 'death':
					stopAudio(this._deathSound);
					break;
			}						
		};

		AudioEngine.prototype.play = function(sound) {
			switch (sound) {
				case 'theme':
					this._basicTheme.play();
					break;
				case 'eat':
					this._eatSound.play();
					break;
				case 'death':
					this._deathSound.play();
					break;
				default:
					this._basicTheme.play();
			}
		};

		return AudioEngine
	}());

	return {
		createAudioEngine: function () {
			return new AudioEngine();
		}
	}
}());
