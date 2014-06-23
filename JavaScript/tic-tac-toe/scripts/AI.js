var ai = (function (){	

	function Computer(computerCellSymbol, difficulty) {
		this.difficulty = difficulty;
		this.cellSymbol = computerCellSymbol;
	}

	function randomInt(min, max) {
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}

	function move(difficulty, cells) {
		switch (difficulty) {
			case difficultyEnum.EASY:
				return easyAI(cells);
			case difficultyEnum.NORMAL:
				return normalAI(cells);
			case difficultyEnum.HARD:
				return hardyAI(cells);
		}	
	}

	function easyAI(cells) {
		while (true) {
			var index = randomInt(0, 8);
			if (cells[index].type === cellTypeEnum.EMPTY) {
				return index;
			}
		}
	}

	function normalAI(cells) {
	}

	function hardyAI(cells) {
	}

	Computer.prototype = {
		getMove: function (cells) {
			return move(this.difficulty, cells);
		}
	};

	return {
		get: function (computerCellSymbol, difficulty) {
			return new Computer(computerCellSymbol, difficulty);
		}
	};
}());