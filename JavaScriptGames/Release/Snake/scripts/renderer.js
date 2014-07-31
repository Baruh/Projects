var renderers = (function () {
	'use strict';

	// Hidden variables
	var appleImage = new Image();
	appleImage.src = IMAGE_APPLE_PATH;

	var CanvasRenderer = (function() {

		function CanvasRenderer(canvas) {
			if (canvas instanceof HTMLCanvasElement) {
				this.canvas = canvas;
			} else {
				throw Error('Canvas is not a HTMLCanvasElement');
			}

			this.ctx = canvas.getContext('2d');
		}

		CanvasRenderer.prototype.draw = function(element) {		
			if (element instanceof gameCharacters.SnakeType) {
				drawSnake(this.ctx, element);
			} else if (element instanceof gameCharacters.FoodType) {
				drawFood(this.ctx, element, 'coin');
			}
		};

		CanvasRenderer.prototype.drawGameOver = function(imagePath) {
			var image = new Image(),
				self = this;

			image.onload = function() {
				self.ctx.drawImage(image, 100, 150);
			};

			image.src = imagePath || IMAGE_GAME_OVER_PATH;			
		};

		CanvasRenderer.prototype.drawScore = function(score) {
			var text = 'SCORE: ';

			score = score || 0;
			text += score.toString();

			this.ctx.font = '36px Georgia';
			this.ctx.fillStyle = 'white';
			this.ctx.fillText(text, 150, 270);

			this.ctx.lineWidth = 2;
			this.ctx.strokeStyle = 'gray';
			this.ctx.strokeText(text, 150, 270);
		};

		CanvasRenderer.prototype.drawGameBar = function(score) {
			this.ctx.clearRect(0, 0, this.canvas.width, MENU_BAR_HEIGHT);
			this.ctx.fillStyle = 'rgba(225,225,225,0.75)';
			this.ctx.fillRect(0, 0,  this.canvas.width , MENU_BAR_HEIGHT);
			drawCurrentScore(this.ctx, score);
		}

		CanvasRenderer.prototype.drawInputBox = function(callback) {
			var input = new CanvasInput({
						canvas: this.canvas,
						x: 150,
						y: 285,
						fontSize: 18,
						fontFamily: 'Arial',
						fontColor: '#212121',
						fontWeight: 'bold',
						width: 200,
						padding: 8,
						borderWidth: 1,
						borderColor: '#000',
						borderRadius: 3,
						placeHolder: 'Enter your name...'
					});
			
			if (callback) {
				input.onsubmit(callback);
			}
			
		}

		CanvasRenderer.prototype.clear = function() {
			this.ctx.clearRect(0, MENU_BAR_HEIGHT, this.canvas.width, this.canvas.height);
		};

		return CanvasRenderer;
	}());
	
	// Helper functions for drawing
	function drawSnake(ctx, snake) {
		drawSnakeHead(ctx, snake.getHead());
		drawSnakeBody(ctx, snake);
	}

	function drawSnakeHead(ctx, snakeHead) {
		var	oldFillStyle = ctx.fillStyle,
			oldStrokeStyle = ctx.strokeStyle;

		ctx.beginPath();
		ctx.arc(snakeHead.x, snakeHead.y, snakeHead.size, 0, 2 * Math.PI);			
		ctx.fillStyle = 'red';
		ctx.fill();		
		ctx.strokeStyle = '#000000';
		ctx.stroke();

		ctx.fillStyle = oldFillStyle;
		ctx.fillStyle = oldFillStyle;
	}

	function drawSnakeBody(ctx, snake) {
		var i,
			oldFillStyle = ctx.fillStyle,
			oldStrokeStyle = ctx.strokeStyle;

		for (i = 1; i < snake.size; i += 1) {
			ctx.beginPath();
			ctx.arc(snake.body[i].x, snake.body[i].y, snake.body[i].size, 0, 2 * Math.PI);			
			ctx.fillStyle = '#5FCC3B';
			ctx.fill();		
			ctx.strokeStyle = '#000000';
			ctx.stroke();
		}

		ctx.fillStyle = oldFillStyle;
		ctx.fillStyle = oldFillStyle;
	}

	function drawFood(ctx, element, foodType) {
		foodType = foodType || 'coin';

		switch (foodType) {
			case 'coin':
				drawCoin(ctx, element);
				break;
			case 'apple':
				drawAppleSprite(ctx, element);
				break;
		}
	}

	function drawCoin(ctx, element) {		
		var oldFillStyle = ctx.fillStyle,
			oldStrokeStyle = ctx.strokeStyle;

		ctx.beginPath();
		ctx.arc(element.x, element.y, element.size, 0, 2 * Math.PI);			
		ctx.fillStyle = 'orange';
		ctx.fill();	
		ctx.fillStyle = oldFillStyle;
	}

	function drawCurrentScore(ctx, score) {			
		var text = 'Score: ';

		score = score || 0;
		text += score.toString();

		ctx.font = '16px Impact';
		ctx.fillStyle = 'red';
		ctx.fillText(text, 15, 16);
	}

	function drawAppleSprite(ctx, element) {
		ctx.drawImage(appleImage, 0, 0, 13, 15, element.x - 6.5, element.y - 6.5, 13, 13);		
	}

	return {
		createCanvas: function(canvas) {
			return new CanvasRenderer(canvas);
		}		
	};
}());
