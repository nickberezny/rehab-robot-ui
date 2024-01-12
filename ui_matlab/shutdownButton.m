function shutdownButton(app)

    data = "ROBOT::SHUTDOWN";
    write(app.tcpConn,data)

end