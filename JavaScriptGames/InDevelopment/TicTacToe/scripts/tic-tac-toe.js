var cell = (function () {

	function GameCell(x, y, width, height, type) {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;

		if (cellTypeEnum.EMPTY === type || cellTypeEnum.CROSS === type || cellTypeEnum.CIRCLE === type) {
			this.type = type;
		} else {
			this.type = cellTypeEnum.EMPTY;
		}
	}

	GameCell.prototype = {
		getPosition: function() {
			return {
				x: this.x,
				y: this.y
			};
		},
		getWidth: function() {
			return this.width;
		},
		getHeight: function() {
			return this.height;
		},
		getType: function() {
			return this.type;
		},
		setType: function(type) {
			if (cellTypeEnum.EMPTY === type || cellTypeEnum.CROSS === type || cellTypeEnum.CIRCLE === type) {
				this.type = type;
			}
		}
	};

	return {
		get: function(x, y, width, height, type) {
			return new GameCell(x, y, width, height, type);
		}
	};
}());