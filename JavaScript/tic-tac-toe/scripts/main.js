var stage = function (ctx) {
	var START_X = 25,
		START_Y = 25,
		STEP = 150,
		THICKNESS = 3,
		COLOR = 'black';

	// horizontal lines
	drawLine(ctx, START_X + STEP, START_Y, START_X + STEP, START_Y + 3 * STEP, THICKNESS, COLOR);
	drawLine(ctx, START_X + 2 * STEP, START_Y, START_X + 2 * STEP, START_Y + 3 * STEP, THICKNESS, COLOR);

	// vertical lines
	drawLine(ctx, START_X, START_Y + STEP, START_X + 3 * STEP, START_Y + STEP, THICKNESS, COLOR);
	drawLine(ctx, START_X, START_Y + 2 * STEP, START_X + 3 * STEP, START_Y + 2 * STEP, THICKNESS, COLOR);
}