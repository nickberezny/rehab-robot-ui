function changeController(app, value)

    %change dropdown 
    

    CtlParamButtonList = [app.Spinner,app.Spinner2,app.Spinner3,app.Spinner4,app.Spinner5,app.Spinner6,app.Spinner7,app.Spinner8];
    params = app.CtlParams{value};
    
    app.ControlTypeDropDown.ValueIndex = params(1);

    for(i = 1:length(app.CtlParams{value})-1)
        
        CtlParamButtonList(i).Value = params(i+1);

    end

end