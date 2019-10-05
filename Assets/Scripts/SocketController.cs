using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SocketController : MonoBehaviour
{
    
    private SocketIOComponent socket;

    void Start()
    {
        socket = this.GetComponent<SocketIOComponent>();

        socket.On("HelloWorld", HelloWorld);

        socket.Emit("Entrei");
    }

    private void HelloWorld(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
}
