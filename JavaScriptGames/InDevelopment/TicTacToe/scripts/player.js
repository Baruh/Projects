var player = (function () {

	function Player(playerCellSymbol) {
		this.name = 'player'; // Not used in current version
		this.score = 0; // Not used in current version
		this.cellSymbol = playerCellSymbol;
	}

	return {
		get: function (playerCellSymbol) {
			return new Player(playerCellSymbol);
		}
	};
}());