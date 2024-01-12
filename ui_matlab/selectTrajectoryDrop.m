function selectTrajectoryDrop(app)

    valueIndex = app.SelectTrajectoryDropDown.ValueIndex;
    app.CurrentTrajData = app.TrajData{valueIndex};
    plot(app.UIAxes,app.CurrentTrajData(1,:),app.CurrentTrajData(2,:));
    plot(app.UIAxes2,app.CurrentTrajData(1,:),[0,diff(app.CurrentTrajData(2,:))]/0.001);
    
end