function stopButton(app)

    data = "ROBOT::STOP";
    write(app.tcpConn,data)

end