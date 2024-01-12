function addCtlTask(app)

    n = length(app.ProcessList.Items) + 1;
    
    app.ProcessList.Items(n) = {strcat(app.TaskListBox_Ctl.Value, '+', app.TaskListBox_Traj.Value)};
    app.CurrentProcessData = [app.CurrentProcessData; app.TaskListBox_Ctl.ValueIndex + length(app.SetupTaskList.Items),app.TaskListBox_Traj.ValueIndex]
    
end