function saveTrajectoryButton(app)

    %name and save trajectory
    prompt = "Trajectory name: ";
    name = inputdlg(prompt);

    app.TrajNames
    name = name{1};
    temp = ~cellfun('isempty',strfind(app.TrajNames,name));

    if(max(temp))
         index = find(temp);
    else
         index = length(app.TrajNames) + 1;
         n = length(app.TaskListBox_Traj.Items)+1;
         app.TaskListBox_Traj.Items(n) = {name}; 
    end 
   
    app.TrajNames{index} = name;
    app.TrajData{index} = app.CurrentTrajData;
    app.SelectTrajectoryDropDown.Items(index) = {name};
    %app.TrajectoryDropDown.Items(index) = {name};
    app.SelectTrajectoryDropDown.Value = app.SelectTrajectoryDropDown.Items(index);
    app.RunTrajectoryDropdown.Items(index) = {name};
    app.DisturbanceDropDown.Items(index) = {name};

    x_current = app.CurrentTrajData(2,length(app.CurrentTrajData));
    t_current = app.CurrentTrajData(1,length(app.CurrentTrajData));
    duration = zeros(1,length(app.CurrentTrajData));
    index_current = length(app.CurrentTrajData);

    for(i = linspace(length(app.CurrentTrajData)-1,1,length(app.CurrentTrajData)-1))
        
        if(app.CurrentTrajData(2,i)~=x_current)
            for j = i+1:index_current
                duration(j) = t_current - app.CurrentTrajData(1,i);
            end
            x_current = app.CurrentTrajData(2,i);
            t_current = app.CurrentTrajData(1,i);

            index_current = i;
        end
        if(i == 1)
            for j = 1:index_current
                duration(j) = t_current - app.CurrentTrajData(1,i);
            end
        end

    end

    dataToPrint = [app.CurrentTrajData',duration'];

    fullpath = strcat(app.SessionPath,'\Trajectories\')
    file = strcat(name,'.txt')
    strcat(fullpath, file)
    writematrix(dataToPrint,strcat(fullpath, file));
    
end