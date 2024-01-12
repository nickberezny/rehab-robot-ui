function loadSession(app)

    selpath = uigetdir;
    [filepath,name,ext] = fileparts(selpath);
    app.SessionPath = selpath;
    app.SessionName = name;
    app.SessionTitlePanel.Title = name;

    %app.RunSessionDropdown.Items(1) = {name};

    %load trajectories, controllers, processes
    loadSessionData(app);
    

end