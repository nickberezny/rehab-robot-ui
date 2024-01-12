function  resetTrajectory(app)

    app.CurrentTrajData = [[0:0.001:1];zeros(1,1001)];
    plot(app.UIAxes,app.CurrentTrajData(1,:),app.CurrentTrajData(2,:));
    plot(app.UIAxes2,app.CurrentTrajData(1,:),[0,diff(app.CurrentTrajData(2,:))]/0.001);

end