function setButton(app)

    data = strcat("GAME::",app.GameEditField.Value);
    write(app.tcpConn,data)
    pause(0.5);

    data = "ROBOT::SET";
    write(app.tcpConn,data)
    pause(0.5);

    data = strcat("ROBOT::T_",app.SessionName, "/Trajectories/", app.RunTrajectoryDropdown.Value, ".txt");
    write(app.tcpConn,data)
    pause(0.5);

    data = strcat("ROBOT::D_",app.SessionName, "/Trajectories/", app.DisturbanceDropDown.Value, ".txt");
    write(app.tcpConn,data)
    pause(0.5);

    data = strcat("ROBOT::C_",app.SessionName, "/Controllers/", app.RunControllerDropdown.Value, ".txt");
    write(app.tcpConn,data)

    

end