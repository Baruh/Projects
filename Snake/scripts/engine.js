var engine = (function($) {
	'use strict';	
	var snake, food, renderer, fieldWidth, fieldHeight, image, initEngine, score,
		audioPlayer = audioDirector.createAudioEngine(),
		isGameOver = false;

	// Helper functions
	function checkCollisions() {
		if (isSnakeGetFood()) {
			audioPlayer.play('eat');
			score += food.point;
			snake.hasToAdd = true;
			setRandomFood();
		}
		if (isSnakeHitWall() || hasCrossHerself()) {
			isGameOver = true;
		}
	}

	function isSnakeGetFood() {
		var i, distance;

		for (i = 0; i < snake.size; i += 1) {
			distance = findDistanceBetweenCentres(snake.body[i], food);
			if (distance < snake.body[i].size + food.size) {
				return true;
			}
		}

		return false;
	}

	function isSnakeHitWall() {
		var i;

		for (i = 0; i < snake.size; i += 1) {			
			if (fieldWidth <= snake.body[i].x + snake.body[i].size
				|| BORDER_WIDTH >= snake.body[i].x - snake.body[i].size
				|| fieldHeight <= snake.body[i].y + snake.body[i].size
				|| BORDER_WIDTH >= snake.body[i].y - snake.body[i].size) {
				return true;
			}
		}

		return false;
	}

	function hasCrossHerself() {
		var i, distance, snakeHead = snake.getHead();
		
		for (i = 1; i < snake.size; i += 1) {
			distance = findDistanceBetweenCentres(snake.body[i], snakeHead);
			if (distance < snake.body[i].size + snakeHead.size) {
				return true;
			}
		} 
	}

	function findDistanceBetweenCentres(obj1, obj2) {
		var distance = Math.sqrt((obj2.x - obj1.x) * (obj2.x - obj1.x) + (obj2.y - obj1.y) * (obj2.y - obj1.y));
		return distance;
	}

	function setRandomFood() {
		var position;

		// It is necessary, because otherwise we can hit the snake
		while (true) {
			position = {
				x: getRandomInt(FOOD_BORDER_PADDING, fieldWidth - FOOD_BORDER_PADDING),
				y: getRandomInt(FOOD_BORDER_PADDING, fieldHeight - FOOD_BORDER_PADDING)
			};

			food = gameCharacters.createFood(position.x, position.y, FOOD_RADIUS, FOOD_POINTS);

			if (!isSnakeGetFood()) {
				break;
			}
		}
	}

	function getRandomInt(min, max) {
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}

	function registerEvents() {		
		$(document).on('keydown', function(e) {
			if ((e.keyCode >= 37 && e.keyCode <= 40) 
				 || e.keyCode === 65 || e.keyCode === 68 || e.keyCode === 83 || e.keyCode === 87) {
				snake.direction = getDirection(e.keyCode);				
			}
		});
	}

	function getDirection(keyCode) {
		switch (keyCode) {
			case 37:	// Left Arrow
			case 65:	// A Key
				return DirectionEnum.Left;
			case 38:	// Up Arrow 
			case 87:	// W Key
				return DirectionEnum.Up;
			case 39:	// Right Arrow 
			case 68:	// D Key
				return DirectionEnum.Right;
			case 40:	// Down Arrow 
			case 83:	// S Key	
				return DirectionEnum.Down;		
		}
	}

	function clearAllIntervals() {
		for (var i = 1; i < 9999; i += 1) {
        	window.clearInterval(i);
        }
	}

	function initEngine(canvas) {
		clearAllIntervals();
		audioPlayer.stop('death'); // if the engine is aready init
		audioPlayer.stop('theme');
		audioPlayer.play('theme');
		score = 0;
		fieldWidth = canvas.width - BORDER_WIDTH;
		fieldHeight = canvas.height - BORDER_WIDTH;
		renderer = renderers.createCanvas(canvas);	
		snake = gameCharacters.createSnake(SNAKE_START_POSITION.x, SNAKE_START_POSITION.y, SNAKE_PART_RADIUS, SNAKE_LENGTH);
		setRandomFood();
		registerEvents();
	}

	return {
		start: function(canvas) {			
			initEngine(canvas);

			var gameLoop = setInterval(function() {
				renderer.clear();
				checkCollisions();
				renderer.draw(food);
				renderer.draw(snake);
				snake.move(10);

				if (isGameOver) {					
					clearInterval(gameLoop);
					renderer.drawGameOver();
					renderer.drawScore(score);
					audioPlayer.stop('theme');
					audioPlayer.play('death');
					isGameOver = false;
				}
			}, 80);
		}
	};
}(jQuery));
