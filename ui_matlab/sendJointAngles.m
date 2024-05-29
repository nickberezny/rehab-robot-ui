function sendJointAngles(app)

    app.ipaddr = app.IPAddressEditField.Value;
    app.SessionPath;
    sshTransfer(strcat(app.SessionPath), strcat('Documents/JointAngles/'), app.ipaddr);

end