function changePlot1(app)
    
    i = app.Plot1DropDown.ValueIndex;
    plot(app.Axis_x,1:length(app.PlotData{i}),app.PlotData{i});

end