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
        socket = gameObject.GetComponent<SocketIOComponent>();

        socket.On("ErrorLobby", ErrorLobby);

        socket.On("InfoUser", SetInfoUser);

        socket.On("InfoLobby", SetInfoLobby);

    }

    public void CriarLobby (string nomePlayer) {
        
        Dictionary<string, string> data = new Dictionary<string, string>();

        data["nome"] = nomePlayer;

        socket.Emit("CreateRoom", new JSONObject(data));
    }

    public void ErrorLobby (SocketIOEvent e) {
        // TODO: Fazer emissão do objeto error pro gamemanager
        ErrorData error = JsonUtility.FromJson<ErrorData>(e.data.ToString());
    }

    private void SetInfoUser (SocketIOEvent e)
    {
        Debug.Log(e.data.ToString());
        player = JsonUtility.FromJson<PlayerData>(e.data.ToString());
    }

    private void SetInfoLobby (SocketIOEvent e)
    {
        Debug.Log(e.data.ToString());
        lobby = JsonUtility.FromJson<LobbyData>(e.data.ToString());
    }

    public void FazerLogin () {
        socket.Emit("Login");
    }
}
