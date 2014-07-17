var gameCharacters = (function () {
	'use strict';

	var GameObject = (function() {

		function GameObject(x, y, size) {
			this.x = x;
			this.y = y;
			this.size = size;
		}

		GameObject.prototype.getPosition = function() {
			return {
				x: this.x,
				y: this.y
			};
		};

		GameObject.prototype.setPosition = function(x, y) {
			this.x = x;
			this.y = y;
		};

		GameObject.prototype.getSize = function() {
			return this.size;
		};

		return GameObject;
	}());
	
	var SnakePart = (function() {

		function SnakePart(x, y, size) {
			GameObject.call(this, x, y, size);
		}

		SnakePart.prototype = new GameObject();
		SnakePart.prototype.constructor = SnakePart;

		return SnakePart;
	}());
	
	var Snake = (function() {

		function Snake(x, y, partSize, partsCount, direction) {
			var i, part;

			GameObject.call(this, x, y, partsCount);	
			this.direction = direction || DirectionEnum.Left;
			this.hasToAdd = false;					
			this.body = [];
			
			for (i = 0; i < partsCount; i += 1) {
				part = new SnakePart(x + (2 * partSize * i), y, partSize);
				this.body.push(part);
			}
		}

		Snake.prototype = new GameObject();
		Snake.prototype.constructor = Snake;

		Snake.prototype.getHead = function() {
			return this.body[0];
		};

		Snake.prototype.move = function(speed) {
			var i, dx, dy, position, snakePart,
				lastPosition = this.body[this.size - 1].getPosition();

			if (this.direction === DirectionEnum.Up) {
				dx = 0;
				dy = -1;
			} else if (this.direction === DirectionEnum.Down) {
				dx = 0;
				dy = 1;
			} else if (this.direction === DirectionEnum.Right) {
				dx = 1;
				dy = 0;
			} else {
				dx = -1;
				dy = 0;
			}

			// move snake body
			for (i = this.size - 1; i > 0; i -= 1) {
				position = this.body[i - 1].getPosition();
				this.body[i].setPosition(position.x, position.y);
			};

			// move snake head
			position = this.getHead().getPosition();
			this.body[0].setPosition(position.x + dx * speed, position.y + dy * speed);

			// check if it is necessary to add new element to the tail
			if (this.hasToAdd) {
				snakePart = new SnakePart(lastPosition.x, lastPosition.y, this.body[0].size);
				this.body.push(snakePart);
				this.size += 1;
				this.hasToAdd = false;
			}
		};

		return Snake;
	}());
	
	var Food = (function() {

		function Food(x, y, size, point) {
			GameObject.call(this, x, y, size);
			this.point = point;
		}

		Food.prototype = new GameObject();
		Food.prototype.constructor = Food;

		return Food;
	}());

	return {
		createFood: function(x, y, size, point) {
			return new Food(x, y, size, point);
		},
		createSnake: function(startX, startY, sizeOfSnakePart, partsCount) {
			return new Snake(startX, startY, sizeOfSnakePart, partsCount);
		},
		FoodType: Food,
		SnakePartType: SnakePart,
		SnakeType: Snake
	};
}());
