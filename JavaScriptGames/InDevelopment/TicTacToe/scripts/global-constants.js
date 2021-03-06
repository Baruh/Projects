var cellTypeEnum = {
	EMPTY: 0,
	CROSS: 1,
	CIRCLE: 2
};

var difficultyEnum = {
	EASY: 0,
	NORMAL: 1,
	HARD: 2
};

var CIRCLE_THICKNESS = 2;
var	CIRCLE_COLOR = 'blue';

var CROSS_THICKNESS = 2;
var	CROSS_COLOR = 'red';

var CELL_THICKNESS = 0;
var CELL_COLOR = 'white';

var FINAL_LINE_COLOR = 'black';
var FINAL_LINE_THICKNESS = 10;

var STAGE_LINE_THICKNESS = 3;
var HALF_THICKNESS = STAGE_LINE_THICKNESS / 2;
var STAGE_LINE_COLOR = 'black';

var STAGE_START_X = 25;
var STAGE_START_Y = 25;

var STAGE_STEP = 150;

var COUNT_CELLS = 9;

var CELLS = [{
		x: STAGE_START_X,
		y: STAGE_START_Y,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	}, 	{
		x: STAGE_START_X + STAGE_STEP + HALF_THICKNESS,
		y: STAGE_START_Y,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	},	{
		x: STAGE_START_X + 2 * STAGE_STEP + HALF_THICKNESS,
		y: STAGE_START_Y,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	},	{
		x: STAGE_START_X,
		y: STAGE_START_Y + STAGE_STEP + HALF_THICKNESS,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	}, 	{
		x: STAGE_START_X + STAGE_STEP + HALF_THICKNESS,
		y: STAGE_START_Y + STAGE_STEP + HALF_THICKNESS,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	},	{
		x: STAGE_START_X + 2 * STAGE_STEP + HALF_THICKNESS,
		y: STAGE_START_Y + STAGE_STEP + HALF_THICKNESS,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	},	{
		x: STAGE_START_X,
		y: STAGE_START_Y + 2 * STAGE_STEP + HALF_THICKNESS,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	}, 	{
		x: STAGE_START_X + STAGE_STEP + HALF_THICKNESS,
		y: STAGE_START_Y + 2 * STAGE_STEP + HALF_THICKNESS,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	},	{
		x: STAGE_START_X + 2 * STAGE_STEP + HALF_THICKNESS,
		y: STAGE_START_Y + 2 * STAGE_STEP + HALF_THICKNESS,
		width: STAGE_STEP - HALF_THICKNESS,
		height: STAGE_STEP - HALF_THICKNESS,
		type: cellTypeEnum.EMPTY
	}];