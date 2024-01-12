function addTrajectoriesPoints(app)
    
     TrajParamButtonList = [app.B1Spinner,app.B2Spinner,app.B3Spinner,app.B4Spinner,...
         app.B5Spinner,app.B6Spinner,app.B7Spinner,app.B8Spinner];

    ParamButtonsLabel = [app.B1SpinnerLabel, app.B2SpinnerLabel, app.B3SpinnerLabel, ...
        app.B4SpinnerLabel, app.B5SpinnerLabel,app.B6SpinnerLabel,app.B7SpinnerLabel,app.B8SpinnerLabel];

    t0 = TrajParamButtonList(1).Value;
    tf = TrajParamButtonList(2).Value;
    data = app.CurrentTrajData;
    tf_curr =  max(data(1,:));
    ts = [t0:0.001:tf];
    toAdd = [];
    
    if(tf-tf_curr>0)
        new_t = [tf_curr+0.001:0.001:tf];
        data = [data,[new_t;zeros(1,length(new_t))]];
    end
    
    switch(app.TypeDropDown.Value)
        case "Step"
            x = TrajParamButtonList(3).Value;
            toAdd = x*ones(1,length(ts));
        case "Sine"
            A = TrajParamButtonList(3).Value;
            A0 = TrajParamButtonList(4).Value;
            w = TrajParamButtonList(5).Value;
            toAdd = A*sin(w*ts)+A0;
    end
    
    for i = 1:length(data)
        if(data(1,i)>=t0 && data(1,i)<=tf) 
            data(2,i) = data(2,i) + toAdd(find(round(ts,3)==round(data(1,i),3))); 
        end
    end
    
    app.CurrentTrajData = data;    
    plot(app.UIAxes,app.CurrentTrajData(1,:),app.CurrentTrajData(2,:));
    
    plot(app.UIAxes2,app.CurrentTrajData(1,:),[0,diff(app.CurrentTrajData(2,:))]/0.001);

end