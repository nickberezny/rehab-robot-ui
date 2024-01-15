function homeBackFrontPressed(app)

    data = "ROBOT::HOME_FRONT";
    write(app.tcpConn,data)

end