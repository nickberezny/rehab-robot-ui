function loadSessionData(app)

    %load trajectories
    files = dir(strcat(app.SessionPath,'\Trajectories\'));
    n = length(files) - 2; 
    if(n > 0) 
        for i = 1:n
            file = files(i+2).name;
            name = split(file,'.');
            name = name(1);
            name = name{1};
            data = csvread(strcat(app.SessionPath,'\Trajectories\',files(i+2).name));
            
            app.TrajNames{i} = name;
            app.TrajData{i} = data';
            app.SelectTrajectoryDropDown.Items(i) = {name};
            app.RunTrajectoryDropdown.Items(i) = {name};
            app.DisturbanceDropDown.Items(i) = {name};
            app.TaskListBox_Traj.Items(i) = {name};
        end
    end

    %load controllers
    files = dir(strcat(app.SessionPath,'\Controllers\'));
    n = length(files) - 2; 
   
    if(n > 0) 
        for i = 1:n
            file = files(i+2).name;
            name = split(file,'.');
            name = name(1);
            name = name{1};
            
            data = readtable(strcat(app.SessionPath,'\Controllers\',files(i+2).name));
         
            app.CtlNames{i} = name;
            app.CltParamNames{i} = table2array(data(:,1));
            app.CtlParams{i} = table2array(data(:,2));
            app.ListBox.Items(i) = {name};
            app.RunControllerDropdown.Items(i) = {name};
            app.TaskListBox_Ctl.Items(i) = {name};
        end
    end

    %load process
    files = dir(strcat(app.SessionPath,'\Processes\'));
    n = length(files) - 2; 
    

    if(n > 0) 
        for i = 1:n
            file = files(i+2).name;
            name = split(file,'.');
            name = name(1);
            name = name{1};
            %data = readtable(strcat(app.SessionPath,'\Processes\',files(i+2).name));
            fid = fopen(strcat(app.SessionPath,'\Processes\',files(i+2).name))
            app.ProcessNames{i} = name;
            dataTemp = [];
        
            tline = fgetl(fid);
            while ischar(tline)
                newStr = split(tline,',');
                data1 = str2double(newStr{1});
                data2 = str2double(newStr{2});
                if(~isnan(data1))
                    dataTemp = [dataTemp;data1,data2];
                else
                    ind1 = find(strcmp([app.TaskListBox_Ctl.Items{:}],newStr{1}));
                    ind2 = find(strcmp([app.TaskListBox_Traj.Items{:}],newStr{2}));
                    dataTemp = [dataTemp;ind1,ind2]
                end
                tline = fgetl(fid);
            end

           %{
            for j = 1:height(data)
                dataRow = table2array(data(j,:))
                
            end
           %}
            
            app.ProcessData{i} = dataTemp;
            app.ProcessDropDown.Items(i) = {name};
            %app.RunProcessDropdown.Items(i) = {name};
            
        end
    end

end