function runRobot(app)

    %send session and process info 
    %{
    data = strcat('ROBOT::S_', app.RunSessionDropdown.Value)
    write(app.tcpConn,data)
    pause(2)
    data = read(app.tcpConn,app.tcpConn.NumBytesAvailable,"string")
    
    
    data = strcat('ROBOT::P_', app.RunProcessDropdown.Value)
    write(app.tcpConn,data)
    pause(0.2)
    data = read(app.tcpConn,app.tcpConn.NumBytesAvailable,"string")
    %}

    data = "ROBOT::RUN";
    write(app.tcpConn,data)
    data = read(app.tcpConn,app.tcpConn.NumBytesAvailable,"string")

    for(jj = 1:10000)

        data = read(app.tcpConn,app.tcpConn.NumBytesAvailable,"string")
        
        if(~isempty(data))
            dataSplit = split(data,"::");
            if(dataSplit(1)=="PLOT")
                app.XDataAxis = [app.XDataAxis,str2double(dataSplit(2))];
                app.X0DataAxis = [app.X0DataAxis,str2double(dataSplit(3))];
                app.FDataAxis = [app.FDataAxis,str2double(dataSplit(4))];

                plot(app.Axis_x,1:length(app.XDataAxis),app.XDataAxis);
                plot(app.Axis_F,1:length(app.FDataAxis),app.FDataAxis);
            end
        end
        
        pause(0.005)
    
    end

    %split
    %plot 

    %{
    %load visuals (unity)
    runtime = java.lang.Runtime.getRuntime();
    process = runtime.exec('Build/TestProject.exe');
    %}

end