function saveJointAngles(app)

    fullpath = strcat(app.SessionPath,'\Joints\')
    file = 'Joints.txt';
    strcat(fullpath, file)
    writematrix(dataToPrint,strcat(fullpath, file));

    app.ipaddr = app.IPAddressEditField.Value;
    app.SessionPath;
    sshTransfer(fullpath, strcat('Documents/JointAngles/'), app.ipaddr);

end