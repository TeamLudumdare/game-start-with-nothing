using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SocketController : MonoBehaviour
{
    
    private PlayerData player = null;

    private LobbyData lobby = null;

    private MatchData match = null;

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

        socket.On("MatchInfo", SetInfoMatch);

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
        player = JsonUtility.FromJson<PlayerData>(e.data.ToString());
    }

    private void SetInfoLobby (SocketIOEvent e)
    {
        lobby = JsonUtility.FromJson<LobbyData>(e.data.ToString());
    }

    private void SetInfoMatch (SocketIOEvent e)
    {
        match = JsonUtility.FromJson<MatchData>(e.data.ToString());
        foreach (PlayerData p in match.players)
        {
            Debug.Log(p._id + " with cards: " + p.items.Length);
        }
    }

    public void FazerLogin (string room, string nomePlayer) {

        Dictionary<string, string> data = new Dictionary<string, string>();

        data["nome"] = nomePlayer;

        data["room"] = room;

        socket.Emit("JoinRoom", new JSONObject(data));
    }

    public void StartGame () {
        
        Dictionary<string, string> data = new Dictionary<string, string>();
        
        data["_id"] = lobby._id;

        socket.Emit("StartGame", new JSONObject(data));

    }

    public void AdicionarItem (string sprite, int itemId) {
        
        Dictionary<string, JSONObject> data = new Dictionary<string, JSONObject>();

        data["item"] = new JSONObject("{ \"sprite\": \"" + sprite + "\", \"itemId\": " + itemId + " }");
        data["player"] = new JSONObject("{ \"_id\": \"" + player._id + "\" }");
        data["match"] = new JSONObject("{ \"_id\": \"" + match._id + "\" }");

        socket.Emit("AdicionarItem", new JSONObject(data));
    }

    public PlayerData Player {
        get {
            return player;
        }
    }

    public LobbyData Lobby {
        get {
            return lobby;
        }
    }

    public MatchData Match {
        get {
            return match;
        }
    }

}
