using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Client : Singleton<Client>
{
	private int port = 5000;
	private string addr = "127.0.0.1";//"192.168.0.93"; //ip of host computer

	private TcpClient socketConnection;
	private Thread clientReceiveThread;

	void Start()
	{
		ConnectToTcpServer();
		//if GetLocalIPv4()

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
		bool connected = false;
		while (!connected)
		{
			try
			{
				socketConnection = new TcpClient(addr, port);
				Byte[] bytes = new Byte[1024];

				SendTCPMessage("Game"); //notify server that this conn is UI 
				//Manager.Instance.state = Manager.states.WaitForConn;
				WaitForTCPMessage();
				connected = true;
			}
			catch (SocketException socketException)
			{
				Debug.Log("Socket exception: " + socketException);
			}
		}


	}

	private void WaitForTCPMessage()
	{
		Byte[] bytes = new Byte[1024];

		while (true)
		{
			if (!socketConnection.Connected)
			{
				Debug.Log("Connection closed");
				break;
			}
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

					Debug.Log("server message received as: " + serverMessage);

					UnityMainThreadDispatcher.Instance().Enqueue(Manager.Instance.RecieveMessage(serverMessage));

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

	private string GetLocalIPv4()
	{
		var host = Dns.GetHostEntry(Dns.GetHostName());
		foreach (var ip in host.AddressList)
		{
			if (ip.AddressFamily == AddressFamily.InterNetwork)
			{
				return ip.ToString();
			}

		}

		return "";
	}
}
