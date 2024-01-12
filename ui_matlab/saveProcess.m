function saveProcess(app)
    
    prompt = "Process name: ";
    name = inputdlg(prompt);
    name = name{1};

    temp = ~cellfun('isempty',strfind(app.ProcessNames,name));

    if(max(temp))
         index = find(temp);
    else
         index = length(app.ProcessNames) + 1;
    end 

    app.ProcessNames{index} = name;

    fullpath = strcat(app.SessionPath,'\Processes\')
    file = strcat(name,'.txt')
    fullpath = strcat(fullpath, file)

    fid = fopen(fullpath,'w') 
    processData = app.CurrentProcessData;
    n = length(app.SetupTaskList.Items);

    for i = 1:length(app.CurrentProcessData)
        taskNum = processData(i,1);
        if(taskNum>n)
            %is ctl task
            ctlName = app.TaskListBox_Ctl.Items(taskNum-n);
            trajName = (app.TaskListBox_Traj.Items(processData(i,2)));
            fprintf(fid,"%s, %s\n",ctlName{1},trajName{1});
        else
            
            fprintf(fid,"%f, %f\n",processData(i,1),processData(i,2));

        end
    
    end
    
    fclose(fid);
    
    %writematrix(app.CurrentProcessData,strcat(fullpath, file));

    app.ProcessDropDown.Items(index) = {name};
    %app.RunProcessDropdown.Items(index) = {name};
    app.ProcessDropDown.ValueIndex = index;
    app.ProcessData{index} = app.CurrentProcessData;

end