function sshTransfer(targetFolder, destinationFolder, ipaddr)
    
    %command = ['pscp -pw abl123 ' filename ' nick@' ipaddr ':TestFile.txt']
    command = ['pscp -pw abl123 -r ' targetFolder ' nick@' ipaddr ':' destinationFolder]
    [status, cmdout] = system(command);

end