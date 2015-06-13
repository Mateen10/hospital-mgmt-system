// JavaScript Document
$(document).ready(function()
{
	$("button").click(function()
	{
		$("abc").animate(
		{
			height: 'toggle'
		});
	});
});


window.onload = function () {
	var chart = new CanvasJS.Chart("chartContainer",
	{
		title:{
			text: "Pi chart"
		},
		legend: {
			maxWidth: 350,
			itemWidth: 120
		},
		data: [
		{
			type: "pie",
			showInLegend: true,
			legendText: "{indexLabel}",
			dataPoints: [
				{ y: 100, indexLabel: "Doctor" },
				{ y: 50, indexLabel: "Patient" },
				{ y: 30, indexLabel: "Xbox 360" },
				{ y: 40	, indexLabel: "Nintendo DS"}
			]
		}
		]
	});
	chart.render();
}