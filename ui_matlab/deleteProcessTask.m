function deleteProcessTask(app)
    
    index = app.ProcessList.ValueIndex;
    app.ProcessList.Items(index) = [];

    app.CurrentProcessData = [app.CurrentProcessData(1:index-1,:);app.CurrentProcessData(index+1:end,:)];

end