function homeBackFrontPressed(app)

    data = "ROBOT::HOME_FRONT";
    write(app.tcpConn,data)

    %read data, save as (x,q)
    %end msg == END? 

    i = 1;

    while(1) %end condition? 
        
        data = read(app.tcpConn,app.tcpConn.NumBytesAvailable,"string");
      
        if(~isempty(data))
            dataSplit = split(data,"::");
        end

        if((dataSplit(1)=="END")
            break;
        else
            app.JointX1(i) = dataSplit(1);
            app.JointQ1(i) = dataSplit(2);
            app.JointX2(i) = dataSplit(3);
            app.JointQ2(i) = dataSplit(4);
            i = i + 1;
        end
    end

end




                    