function controlTypeDrop(app,value)
    
    CtlParamButtonList = [app.Spinner,app.Spinner2,app.Spinner3,app.Spinner4,app.Spinner5,app.Spinner6,app.Spinner7,app.Spinner8];
    
    ParamButtonsLabel = [app.SpinnerLabel,app.Spinner2Label,app.Spinner3Label,app.Spinner4Label, ...
        app.Spinner5Label,app.Spinner6Label,app.Spinner7Label,app.Spinner8Label ];
    
     switch value
        case "PD"
            params = app.PD_Params;
        case "Impedance"
            params = app.Imp_Params;
        case "Admittance"
            params = app.Adm_Params;
        case "UIAC" 
            params = app.UIAC_Params;
        case "UIC"
            params = app.UIC_Params;
         case "Adm_Dist"
             params = app.Adm_dist_Params;
         case "FORCE_NORM"
             params = app.Force_norm_Params;
     end

     app.CurrentCtlParams = params;

    for i = 1:length(params)    
        but = CtlParamButtonList(i);
        but.Visible = 1;
        temp = app.ControlParams(params(i));
        temp = temp{1};
        but.Tag = temp;
        ParamButtonsLabel(i).Visible = 1;
        ParamButtonsLabel(i).Text = temp; 
    end
        
    for i = length(params)+1:length(CtlParamButtonList)
        
        CtlParamButtonList(i).Visible = 0;
        ParamButtonsLabel(i).Visible = 0;
    end

end