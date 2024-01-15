function homeButton(app)

    data = "ROBOT::HOME";
    write(app.tcpConn,data)

    data = strcat("ROBOT::", app.x_endmEditField.Value);
    write(app.tcpConn,data)

end