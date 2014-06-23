var renderers = (function () {

	var drawStage = function (layer, x, y, step, thickness, color) {

		// vertical lines
		var firstVerticalLine = new Kinetic.Line({
			points: [x + step, y, x + step, y + 3 * step],
			stroke: color,
        	strokeWidth: thickness
		});

		var secondVerticalLine = new Kinetic.Line({
			points: [x + 2 * step, y, x + 2 * step, y + 3 * step],
			stroke: color,
        	strokeWidth: thickness
		});

		// horizontal lines
		var firstHorizontalLine = new Kinetic.Line({
			points: [x, y + step, x + 3 * step, y + step],
			stroke: color,
        	strokeWidth: thickness
		});

		var secondHorizontalLine = new Kinetic.Line({
			points: [x, y + 2 * step, x + 3 * step, y + 2 * step],
			stroke: color,
        	strokeWidth: thickness
		});
		
		layer.add(firstVerticalLine);
		layer.add(secondVerticalLine);
		layer.add(firstHorizontalLine);
		layer.add(secondHorizontalLine);
	};

	var drawCell = function (layer, cell) {
		switch (cell.type) {
			case cellTypeEnum.EMPTY:
				drawEmptyCell(layer, cell);
				break;
			case cellTypeEnum.CROSS:
				drawCrossCell(layer, cell);
				break;
			case cellTypeEnum.CIRCLE:
				drawCircleCell(layer, cell);
				break;
		}		
	};

	var drawEmptyCell = function (layer, cell) {
		var position = cell.getPosition();

		var emptyCell = new Kinetic.Rect({
			x: position.x,
			y: position.y,
			width: cell.getWidth(),
			height: cell.getHeight(),
			stroke: CELL_COLOR,
			strokeWidth: CELL_THICKNESS
		});

		layer.add(emptyCell);
	};

	var drawCrossCell = function (layer, cell) {
		var position = cell.getPosition();		
		var x1 = position.x,
			y1 = position.y,
			x2 = position.x + cell.width,
			y2 = position.y + cell.height,
			x3 = position.x + cell.width,
			y3 = position.y,
			x4 = position.x,
			y4 = position.y + cell.height;

		var firstLine = new Kinetic.Line({
			points: [x1, y1, x2, y2],
			stroke: CROSS_COLOR,
        	strokeWidth: CROSS_THICKNESS,
        	lineCap: 'round'
		});

		var secondLine = new Kinetic.Line({
			points: [x3, y3, x4, y4],
			stroke: CROSS_COLOR,
        	strokeWidth: CROSS_THICKNESS,
        	lineCap: 'round'
		});

		layer.add(firstLine);
		layer.add(secondLine);
	};

	var drawCircleCell = function (layer, cell) {
		var position = cell.getPosition();
		var size = Math.min(cell.getWidth(),  cell.getHeight());
		var radius = (size / 2) | 0;

		var circle = new Kinetic.Circle({
			x: position.x + radius,
			y: position.y + radius,
			radius: radius,
			stroke: CIRCLE_COLOR,
			strokeWidth: CIRCLE_THICKNESS
		});

		layer.add(circle);
	};

	var drawLine = function (layer, x1, y1, x2, y2) {
		var line = new Kinetic.Line({
			points: [x1, y1, x2, y2],
			stroke: FINAL_LINE_COLOR,
        	strokeWidth: FINAL_LINE_THICKNESS,
        	lineCap: 'round'
		});

		layer.add(line);
	};

	function CellsRenderer(stage) {
		if (true) {
			this.stage = stage;
		}
	}

	CellsRenderer.prototype = {
		draw: function (layers, cells) {
			// this function is overload to work with arrays and separate cells
			if ($.isArray(layers) && $.isArray(cells)) {
				for (var i = layers.length - 1; i >= 0; i--) {			
					drawCell(layers[i], cells[i]);
					this.stage.add(layers[i]);
					layers[i].batchDraw();
				}
			} else {
				drawCell(layers, cells);
				this.stage.add(layers);
				layers.batchDraw();
			}
		}
	};

	function StageRenderer(stage) {
		if (true) {
			this.stage = stage;		
		}
	}

	StageRenderer.prototype = {
		draw: function (layer, options) {
			// default values for thickness and color
			if (options.thickness === undefined) {
				options.thickness = STAGE_LINE_THICKNESS;
			}
			if (options.color === undefined) {
				options.color = STAGE_LINE_COLOR;
			}

			drawStage(layer, options.x, options.y, options.step, options.thickness, options.color);
			this.stage.add(layer);
			layer.draw();
		},
		drawWinnerLine: function (layer, x1, y1, x2, y2) {
			drawLine(layer, x1, y1, x2, y2);
			this.stage.add(layer);
			layer.batchDraw();
		}
	};

	return {
		getStageRenderer: function (stage) {
			return new StageRenderer(stage);
		},
		getCellsRenderer: function (stage) {
			return new CellsRenderer(stage);
		}
	};
}());