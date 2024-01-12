function  saveController(app)
    
    CtlParamButtonList = [app.Spinner,app.Spinner2,app.Spinner3,app.Spinner4,app.Spinner5,app.Spinner6,app.Spinner7,app.Spinner8];
    
    %name and save trajectory
    prompt = "Controller name: ";
    name = inputdlg(prompt);

    name = name{1};
    app.CtlNames
    temp = ~cellfun('isempty',strfind(app.CtlNames,name));

    if(max(temp))
         index = find(temp);
    else
         index = length(app.CtlNames) + 1;
         app.TaskListBox_Ctl.Items(length(app.TaskListBox_Ctl.Items)+1) = {name};
    end 

    app.RunControllerDropdown.Items(index) = {name};
   
    app.CtlNames{index} = name;
    app.ListBox.Items(index) = {name};
    
    app.ListBox.ValueIndex = index;
    
    app.CtlParams{index} = [app.ControlTypeDropDown.ValueIndex];
    app.CltParamNames{index} = ['Type'];

    file = strcat(name,'.txt');
    fullpath = strcat(app.SessionPath,'\Controllers\',file)
                
    fid = fopen(fullpath,'w')   
    fprintf(fid,"Type, %d\n",app.ControlTypeDropDown.ValueIndex);

    for(i = 1:length(app.CurrentCtlParams))

        app.CtlParams{index} = [app.CtlParams{index},CtlParamButtonList(i).Value];
        temp = app.ControlParams(app.CurrentCtlParams(i));
        app.CltParamNames{index} = [app.CltParamNames{index},temp{1}];

        fprintf(fid,"%s, %f\n",temp{1},CtlParamButtonList(i).Value);

    end

    fclose(fid);

end