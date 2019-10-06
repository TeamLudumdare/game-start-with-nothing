﻿using System.Collections;
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
        player = JsonUtility.FromJson<PlayerData>(e.data.ToString());
    }

    private void SetInfoLobby (SocketIOEvent e)
    {
        lobby = JsonUtility.FromJson<LobbyData>(e.data.ToString());
        GameManager.Instance.SetLobby(lobby);
    }

    public void FazerLogin (string _id, string nomePlayer) {

        Dictionary<string, string> data = new Dictionary<string, string>();

        data["nome"] = nomePlayer;

        data["_id"] = _id;

        socket.Emit("JoinRoom", new JSONObject(data));
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
}
