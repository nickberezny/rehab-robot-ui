function changeProcess(app,index)
    
    app.CurrentProcessData = app.ProcessData{index};
    n = length(app.SetupTaskList.Items);
    data = app.ProcessData{index};
    %strcat(app.TaskListBox_Ctl.Items(1), '+', app.TaskListBox_Traj.Items(1))  
    for i = 1:length(app.CurrentProcessData)
        
        if(data(i,1) > n) 
            app.ProcessList.Items(i) = strcat(app.TaskListBox_Ctl.Items(data(i,1)-n), '+', app.TaskListBox_Traj.Items(data(i,2)));
        else
           app.ProcessList.Items(i) = app.SetupTaskList.Items(data(i,1));
        end

    end

    while(length(app.ProcessList.Items) > length(app.CurrentProcessData))

        app.ProcessList.Items(end) = [];
        length(app.ProcessList.Items)
    end

end