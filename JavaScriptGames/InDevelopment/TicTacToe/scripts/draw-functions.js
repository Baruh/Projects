// The point (x, y) is the position of the top left corner of the cross
function drawCross(ctx, x, y, width, height, thickness, color) {

	if (thickness === undefined) {
		thickness = 1;
	}
	if (color === undefined) {
		color = 'black';
	}

	var x1 = x,
		y1 = y,
		x2 = width + x,
		y2 = height + y,
		x3 = width + x,
		y3 = y,
		x4 = x,
		y4 = height + y;

	drawLine(ctx, x1, y1, x2, y2, thickness, color);
	drawLine(ctx, x3, y3, x4, y4, thickness, color);
}

function drawCircle(ctx, x, y, r, thickness, color, fillColor) {
	
	if (color === undefined) {
		color = 'black';	
	}
		
	if (thickness === undefined) {
		thickness = 1;	
	}
	
	if (fillColor === undefined) {
		fillColor = 'white';	
	}
	
	ctx.beginPath();
	ctx.arc(x, y, r, 0, 2 * Math.PI, true);
	
	ctx.strokeStyle = color;
	ctx.lineWidth = thickness;
	ctx.stroke();
	
	ctx.fillStyle = fillColor;
	ctx.fill();
	
	// return all styles to default values because the canvas is common for all drawing functions
	resetStyles(ctx);			
}

// (x1, y1) - start position; (x2, y2) - end position
function drawLine(ctx, x1, y1, x2, y2, thickness, color) {
	
	if (color === undefined) {
		color = 'black';	
	}
	
	if (thickness === undefined) {
		thickness = 1;	
	}
	
	ctx.beginPath(); 
	ctx.moveTo(x1, y1);
	ctx.lineTo(x2, y2);
	
	ctx.strokeStyle = color;
	ctx.lineWidth = thickness;
	ctx.stroke();

	// reset all styles to default values because the canvas is common for all drawing functions
	resetStyles(ctx);
}

function resetStyles(ctx) {	
	ctx.strokeStyle = 'black';
	ctx.lineWidth = 1;
	ctx.fillStyle = 'white';
}