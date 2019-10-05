using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SocketController : MonoBehaviour
{
    
    private PlayerData player;

    private LobbyData lobby;

    private static SocketController instance;

    public static SocketController Instance {
        get {
            return instance;
        }
    }

    private SocketIOComponent socket;

    void Awake () {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
        socket = this.GetComponent<SocketIOComponent>();

        socket.On("ErrorLobby", ErrorLobby);

        socket.On("InfoUser", SetInfoUser);

        socket.On("InfoLobby", SetInfoUser);

    }

    public void CriarLobby (string nomePlayer) {
        socket.Emit("CreateRoom", new JSONObject("{nome: " + nomePlayer + "}"));
    }

    public void ErrorLobby (SocketIOEvent e) {
        // TODO: Fazer emissão do objeto error pro gamemanager
        ErrorData error = JsonUtility.FromJson<ErrorData>(e.data.ToString());
    }

    private void HelloWorld(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}

    private void SetInfoUser (SocketIOEvent e)
    {
        player = JsonUtility.FromJson<PlayerData>(e.data.ToString());
    }

    private void SetInfoLobby (SocketIOEvent e)
    {
        lobby = JsonUtility.FromJson<LobbyData>(e.data.ToString());
    }

    public void FazerLogin () {
        socket.Emit("Login");
    }
}
