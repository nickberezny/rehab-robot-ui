function addTask(app)
    
    n = length(app.ProcessList.Items) + 1;
    
    if(app.SetupTaskList.Value == "Goto")  
        app.ProcessList.Items(n) = {[app.SetupTaskList.Value + string(app.GotoxEditField.Value)]};
        app.CurrentProcessData = [app.CurrentProcessData;app.SetupTaskList.ValueIndex,app.GotoxEditField.Value];
    else
        app.ProcessList.Items(n) = {app.SetupTaskList.Value};
        app.CurrentProcessData = [app.CurrentProcessData;app.SetupTaskList.ValueIndex,0];
    end
  
    
    

end