function  changeTrajectoryType(app, value)
    
     TrajParamButtonList = [app.B1Spinner,app.B2Spinner,app.B3Spinner,app.B4Spinner,...
         app.B5Spinner,app.B6Spinner,app.B7Spinner,app.B8Spinner];

    ParamButtonsLabel = [app.B1SpinnerLabel, app.B2SpinnerLabel, app.B3SpinnerLabel, ...
        app.B4SpinnerLabel, app.B5SpinnerLabel,app.B6SpinnerLabel,app.B7SpinnerLabel,app.B8SpinnerLabel];

    
    switch value
        case "Step"
            params = app.StepParams;
        case "Sine"
            params = app.SineParams;
        case "Ramp"
            params = app.RampParams;
    end

    for i = 1:length(params)    
        but = TrajParamButtonList(i);
        but.Visible = 1;
        temp = app.TrajectoryParams(params(i));
        temp = temp{1};
        but.Tag = temp;
        ParamButtonsLabel(i).Visible = 1;
        ParamButtonsLabel(i).Text = temp; 
    end
            
    for i = length(params)+1:length(TrajParamButtonList)
        
        TrajParamButtonList(i).Visible = 0;
        ParamButtonsLabel(i).Visible = 0;
    end

end

