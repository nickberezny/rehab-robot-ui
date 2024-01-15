function changePlot2(app)
    
    i = app.Plot1DropDown.ValueIndex;
    plot(app.Axis_F,1:length(app.PlotData{i}),app.PlotData{i});

end