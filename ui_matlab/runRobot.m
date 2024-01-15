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

    for jj = 1:9
        
        app.PlotData{jj} = zeros(1,10000)

    end

    for(jj = 1:100000)

        data = read(app.tcpConn,app.tcpConn.NumBytesAvailable,"string");
        
        if(~isempty(data))
            dataSplit = split(data,"::");
            if(dataSplit(1)=="PLOT" && length(dataSplit)>8)
                for jjj = 1:9
                    
                    vec = app.PlotData{jjj};
                    vec = [vec(2:end),str2double(dataSplit(jjj+1))];
                    app.PlotData{jjj} = vec;

                end
                

                %app.XDataAxis = [app.XDataAxis,str2double(dataSplit(2))];
                %app.X0DataAxis = [app.X0DataAxis,str2double(dataSplit(3))];
                %app.FDataAxis = [app.FDataAxis,str2double(dataSplit(4))];
                
            end
        end
        
        i1 = app.plotIndex1;
        i2 = app.plotIndex2;

        plot(app.Axis_x,1:length(app.PlotData{i1}),app.PlotData{i1});
        plot(app.Axis_F,1:length(app.PlotData{i2}),app.PlotData{i2});
        pause(0.02)
    
    end

    %split
    %plot 

    %{
    %load visuals (unity)
    runtime = java.lang.Runtime.getRuntime();
    process = runtime.exec('Build/TestProject.exe');
    %}

end