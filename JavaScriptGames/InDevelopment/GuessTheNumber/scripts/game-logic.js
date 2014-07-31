var gameLogic = (function($) {
	'use strict';
	var	score = 0,
		ramPoints = 1025,
		computerNumberString = computer.getNumberStringNotRepeatedDigits(),
		computerDigits = StringNumberToArrayOfDigits(computerNumberString),
		guessedNumbers = 0;

	// Visible functions
	function checkTheGuess() {
		var previousGuessedSheeps = [],
			rams = [],
			len = computerDigits.length,
			playerDigit,
			i;

		for (i = 0; i < len; i += 1) {

			playerDigit = $('#value' + i.toString()).val() | 0;
			if (hasRam(playerDigit, computerDigits[i])) {				
				
				rams.push({
					id: 'digit' + i.toString(),
					inputBoxID: 'value' + i.toString(),
					digit: computerDigits[i]
				});
				guessedNumbers++;

				computerDigits[i] = -1;
			} else if (hasSheep(playerDigit)) {
				if ($.inArray(playerDigit, previousGuessedSheeps) === -1) {
					previousGuessedSheeps.push(playerDigit);
				}
			}
		}

		// Decrease the given points after every round
		ramPoints -= 25;

		return { 
			sheepsCount: previousGuessedSheeps.length, 
			rams: rams
		};
	}	

	function getScore() {
		return guessedNumbers * ramPoints;
	}

	function isGameFinished() {
		return guessedNumbers === 4;
	}

	// Hidden halper functions
	function StringNumberToArrayOfDigits(numberString) {
		var myArray = [],
			i;

		for (i = 0; i < numberString.length; i += 1) {
			myArray.push(parseInt(numberString[i], 10));
		} 

		return myArray;
	}

	function hasSheep(digit) {
		var i;

		for (i = 0; i < computerDigits.length; i += 1) {
			if (digit === computerDigits[i]) {
				return true;
			}
		}

		return false;
	}

	function hasRam(playerDigit, computerDigit) {
		return playerDigit === computerDigit;
	}

	return {
		checkTheGuess: checkTheGuess,
		getScore: getScore,
		isGameFinished: isGameFinished
	}
}(jQuery));