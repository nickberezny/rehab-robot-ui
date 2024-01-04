import socket
import os
import select
from _thread import *
from time import sleep
import matplotlib
import matplotlib.pyplot as plt
import matplotlib.colors as mcolors

host = "0.0.0.0"
port = 5000
state = 1;

ServerSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    ServerSocket.bind((host, port))
except socket.error as e:
    print(str(e))

ServerSocket.listen()
connection, address = ServerSocket.accept()

while(state == 1):
	msg = connection.recv(2048).decode('ascii')
	print(msg)
	if(msg == "Game"):
		state = 2
		connection.sendall(str.encode("RobotGuide"))

sleep(2)

connection.sendall(str.encode("run"))

sleep(1)
j = 0;


for i in range(1,10000):
	connection.sendall(str.encode("x,"+str(j)))
	if(i%10 == 0):
		connection.sendall(str.encode("x0,0.25"))
	j = j + 1.0/10000.0
	sleep(0.1)


