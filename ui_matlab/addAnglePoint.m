function addAnglePoint(app, index)

    %get point
    %add point to plot
    %add point to vector
    
    newX = app.P1EditField.Value;
    newY = app.P2EditField.Value;

    if(index == 1)
        app.JointF1 = [app.JointF1;[newX,newY]];
        plot(app.UIAxes3,app.JointF1(:,1),app.JointF1(:,2),'*');
    elseif (index == 2)
        app.JointF2 = [app.JointF2;[newX,newY]];
        plot(app.UIAxes3_2,app.JointF2(:,1),app.JointF2(:,2),'*');
    end
    

end