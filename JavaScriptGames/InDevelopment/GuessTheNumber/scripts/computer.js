var computer = (function() {
	'use strict';
	
	// Visible functions
	function getNumberString() {
		var numberString = generateRandomInt(1).toString(),
			i;

		for (i = 1; i <= 3; i += 1) {
			numberString += generateRandomInt(0, 9).toString();
		}

		return numberString;
	}

	function getNumberStringNotRepeatedDigits() {
		var numberString = generateRandomInt(1).toString(),
			temp,
			i;

		for (i = 1; i <= 3; i += 1) {
			while (true) {
				temp = generateRandomInt(0, 9).toString();
				if (numberString.indexOf(temp) === -1) {
					numberString += temp
					break;
				}
			}			
		}

		return numberString;
	}

	// Hidden helper functions
	function generateRandomInt(min, max) {
		var num;

		min = min || 0;
		max = max || 9;

		num = Math.floor(Math.random() * (max - min + 1)) + min;
		return num;
	}

	return {
		getNumberString: getNumberString,
		getNumberStringNotRepeatedDigits: getNumberStringNotRepeatedDigits
	};
}());