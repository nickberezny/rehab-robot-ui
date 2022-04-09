﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Client2 : MonoBehaviour
{
	[SerializeField] private Manager manager;

	private TcpClient socketConnection;
	private Thread clientReceiveThread;

	private bool initMode = true;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		ConnectToTcpServer();
	}
	private void ConnectToTcpServer()
	{
		try
		{
			clientReceiveThread = new Thread(new ThreadStart(ListenForData));
			clientReceiveThread.IsBackground = true;
			clientReceiveThread.Start();
		}
		catch (Exception e)
		{
			Debug.Log("On client connect exception " + e);
		}
	}

	private void ListenForData()
	{
		try
		{
			socketConnection = new TcpClient("localhost", 5000);
			Byte[] bytes = new Byte[1024];

			SendTCPMessage("UI"); //notify server that this conn is UI 
			manager.state = Manager.states.WaitForConn;
			WaitForTCPMessage();
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}

	}

	private void WaitForTCPMessage()
    {
		Byte[] bytes = new Byte[1024];

		while (initMode)
		{
			// Get a stream object for reading 				
			using (NetworkStream stream = socketConnection.GetStream())
			{
				int length;
				// Read incomming stream into byte arrary. 					
				while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
				{
					var incommingData = new byte[length];
					Array.Copy(bytes, 0, incommingData, 0, length);
					// Convert byte array to string message. 						
					string serverMessage = Encoding.ASCII.GetString(incommingData);
					//manager.RecieveMessage(serverMessage);
					
					Debug.Log("server message received as: " + serverMessage);
                    string[] data = serverMessage.Split(new string[] { "::" }, StringSplitOptions.None);
					if(data[0] == "conn" && data[1] == "ROBOT")
                    {
						SendTCPMessage("select::ROBOT");
						UnityMainThreadDispatcher.Instance().Enqueue(manager.RecieveMessage(data[1]));
					}
					else if(data[0] == "hi from robot")
                    {
						SendTCPMessage("ROBOT::hi from ui");
						initMode = false;
					}
				}
			}
		}
	}


	public void SendTCPMessage(string msg)
	{
		if (socketConnection == null)
		{
			return;
		}
		try
		{
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream();
			if (stream.CanWrite)
			{

				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(msg);
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
				Debug.Log("Client sent " + msg);
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}

}
