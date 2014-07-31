var gameEngine = (function () {

	var line = {};

	function Engine(renderer, stage) {		
		this.renderer = renderer;
		this.stage = stage;
		this.cells = createCells();
		this.cellsLayers = createCellsLayers();
		this.stageOptions = createStageOptions();
		this.stageLayer = createStageLayer();	
		this.computer = ai.get(cellTypeEnum.CIRCLE, difficultyEnum.EASY);
		this.player = player.get(cellTypeEnum.CROSS);
	}

	function createCells() {
		var cells = [];
		for (var i = 0; i < COUNT_CELLS; i += 1) {
			cells.push(cell.get(CELLS[i].x, CELLS[i].y, CELLS[i].width, CELLS[i].height, cellTypeEnum.EMPTY));
		};

		return cells;
	}

	function createCellsLayers() {
		var layers = [];
		for (var i = 0; i < COUNT_CELLS; i += 1) {
			var layer = new Kinetic.Layer();			
			layers.push(layer);
		}

		return layers;
	}

	function createStageOptions() {
		return  {
			x: STAGE_START_X,
			y: STAGE_START_Y,
			step: STAGE_STEP,
			thickness: STAGE_LINE_THICKNESS,
			color: STAGE_LINE_COLOR
		};
	}

	function setWinnerLineCoords(startCell, endCell, key) {
		
		switch (key) {
			case 'v': 	// vertical line
				line.x1 = startCell.x + startCell.width / 2;
				line.y1 = startCell.y;
				line.x2 = endCell.x + endCell.width / 2;
				line.y2 = endCell.y + endCell.height;
				break;
			case 'h': 	// horizontal line
				line.x1 = startCell.x;
				line.y1 = startCell.y + startCell.height / 2;
				line.x2 = endCell.x + startCell.width;
				line.y2 = endCell.y + endCell.height / 2;
				break;
			case 'd':
				line.x1 = startCell.x;
				line.y1 = startCell.y;
				line.x2 = endCell.x + endCell.width;
				line.y2 = endCell.y + endCell.height;
				break;

		}
	}
	
	function hasWinner(cells) {
		var length = cells.length, i;

		for (i = 0; i < length; i += 3) { // check all rows
			if (cells[i].type !== cellTypeEnum.EMPTY && cells[i].type === cells[i + 1].type && cells[i].type === cells[i + 2].type) {	
				setWinnerLineCoords(cells[i], cells[i + 2], 'h');			
				return true;
			}
		}

		for (i = 0; i < 3; i += 1) { // check all columns
			if (cells[i].type !== cellTypeEnum.EMPTY && cells[i].type === cells[i + 3].type && cells[i].type === cells[i + 6].type) {	
				setWinnerLineCoords(cells[i], cells[i + 6], 'v');				
				return true;
			}
		};

		// Check diagonals
		if (cells[0].type !== cellTypeEnum.EMPTY && cells[0].type === cells[4].type && cells[0].type === cells[8].type) {
			setWinnerLineCoords(cells[0], cells[8], 'd');		
			return true;
		}

		if (cells[2].type !== cellTypeEnum.EMPTY && cells[2].type === cells[4].type && cells[2].type === cells[6].type) {
			setWinnerLineCoords(cells[2], cells[6], 'd');
			return true;
		}

		return false;
	}

	function isGameOver(cells) {
		if (hasWinner(cells)) {
			return true;
		}

		for (var i = cells.length - 1; i >= 0; i--) {
			if (cells[i].type === cellTypeEnum.EMPTY) {
				return false;
			}
		};

		return true;
	}

	function createStageLayer() {
		return new Kinetic.Layer();
	}

	function isCurrentCell(currentLayer, cell) {		
		return cell.x === currentLayer.x && cell.y === currentLayer.y && 
			cell.width === currentLayer.width && cell.height === currentLayer.height;		
	}
	
	function unbindEventFromCorrespondingCellLayer(cell, cellsLayers) {
		console.dir(cellsLayers);
		var $arr = $(cellsLayers).first(function (index, item) {				
			if (isCurrentCell(item, cell)) {				
				return true;
			}
		});
		//console.dir(cellsLayers[0]);
		//cell.listening(false);	
		console.dir($arr.children());
		//$arr.off('click');
	}

	function playerMove(cells, targetCell, player) {
		for (var j = cells.length - 1; j >= 0; j -= 1) {
			if (isCurrentCell(targetCell, cells[j]) && cells[j].type === cellTypeEnum.EMPTY) {							
				cells[j].type = player.cellSymbol;												
				return;
			}
		}
	}

 	function computerMove(cells, cellsLayers, computer) {
 		var nextMove = computer.getMove(cells);
		cells[nextMove].type = computer.cellSymbol;
		unbindEventFromCorrespondingCellLayer(cells[nextMove], cellsLayers);
	}

	Engine.prototype = {
		start: function (playerSymbol, computerSymbol, difficulty) {
			if (playerSymbol === cellTypeEnum.CIRCLE) { // changes the default values
				this.player.cellSymbol = playerSymbol;	
				this.computer.cellSymbol = cellTypeEnum.CROSS;
			}

			if (difficulty === difficultyEnum.EASY || difficulty === difficultyEnum.NORMAL ||  difficulty === difficultyEnum.HARD) { // changes the default values
				this.computer = this.computer;
			}

			this.renderer.getCellsRenderer(this.stage)
						.draw(this.cellsLayers, this.cells);

			this.renderer.getStageRenderer(this.stage)
						.draw(this.stageLayer, this.stageOptions);
		},
		reset: function () {

		},
		isEnd: function () {

		},
		hasWinner: function () {

		},
		stop: function () {

		},
		bindClickEvents: function() {
			var self = this;
			for (var i = self.cellsLayers.length - 1; i >= 0; i -= 1) {

				self.cellsLayers[i].on('click', function (e) {

					// this cell can't be clicked again 
					e.target.listening(false);
					console.dir(e.target);	
					var currentCell = e.target.attrs;
					playerMove(self.cells, currentCell, self.player);

					if (!isGameOver(self.cells)) {	

						computerMove(self.cells, self.cellsLayers, self.computer);

						if (hasWinner(self.cells)) {
							
							self.renderer.getStageRenderer(self.stage)
											.drawWinnerLine(self.stageLaye,
																line.x1,
																line.y1,
																line.x2,
																line.y2);										

						}
					}

					self.renderer.getCellsRenderer(self.stage)
										.draw(self.cellsLayers, self.cells);
					
				});
			};
		}
	};

	return {
		get: function (renderer, stage) {
			return new Engine(renderer, stage);
		}
	}
}());