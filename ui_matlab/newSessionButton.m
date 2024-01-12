function newSessionButton(app,event)
    
    %setup new directory

    selpath = uigetdir;
    prompt = "Session name: ";
    title = inputdlg(prompt)
    app.SessionTitlePanel.Title = title;

    fullpath = strcat(selpath, '\', title)
    fullpath = fullpath{1};

    mkdir(fullpath);
    mkdir(strcat(fullpath, '\Trajectories'));
    mkdir(strcat(fullpath, '\Controllers'));
    mkdir(strcat(fullpath, '\Processes'));

    app.SessionPath = fullpath;
    app.SessionName = title;

    %app.RunSessionDropdown.Items(1) = title;

    %wipe old data

    app.CtlNames = {};
    app.CltParamNames = {};
    app.CtlParams = {};
    app.TrajNames = {};
    app.TrajData = {};
    app.ProcessNames = {};
    app.ProcessData = {};
    app.CurrentCtlParams = [];
    app.CurrentTrajData = [[0:0.001:1];zeros(1,1001)];
    app.CurrentProcessData = [];


end

