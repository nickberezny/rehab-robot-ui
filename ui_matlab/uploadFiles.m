function uploadFiles(app)
    
    app.ipaddr = app.IPAddressEditField.Value;
    app.SessionPath
    sshTransfer(strcat(app.SessionPath), strcat('Documents/ControllerSetup/'), app.ipaddr)

end