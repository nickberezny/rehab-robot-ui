function connectTCP(app)

    t = tcpclient(app.IPAddressEditField.Value,5000)
    app.tcpConn = t;
    data = "UI";
    write(t,data)
    pause(0.5)
    data = read(t,t.NumBytesAvailable,"string")
    
    
    if(strcmp(data,'conn::ROBOT'))
        app.Lamp.Enable = true;
    end
    pause(0.5)
    data = "select";
    write(t,data)
    
    
    
end