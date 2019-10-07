using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private PlayerData player;
    private MatchData match;

    //players
    [SerializeField]
    private Player[] players;
    //lista de id, deve receber os id do servidor, porem o primeiro id deve sempre ser o do jogador
    private List<PlayerData> listOfIdsServeSorted = new List<PlayerData>();
    //TODO: CAMPO DE TESTE ID PLAYER
    private string myid;

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);    
    }

    private void Start()
    {
        player = SocketController.Instance.Player;
        match = SocketController.Instance.Match;

        //definindo id
        myid = player._id;

        //fazendo testes de id, preechendo com ids genericos
        int playerIdIndexInList = -1;
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < match.players.Length; j ++)
                {
                    if (match.players[j]._id == myid)
                    {
                        playerIdIndexInList = j;
                        break;
                    }
                }
                listOfIdsServeSorted.Add(match.players[playerIdIndexInList]);
            }
            if (i != playerIdIndexInList)
            {
                listOfIdsServeSorted.Add(match.players[i]);
            }
        }

        foreach (PlayerData player in listOfIdsServeSorted)
        {
            Debug.Log(player._id);
        }
        SetIds();
    }

    private void Update()
    {
        match = SocketController.Instance.Match;
        foreach (PlayerData p in match.players)
        {
            if (p._id == player._id)
            {
                player = p;
                break;
            }
        }
        
    }

    //Fazendo gameobjects dos players, recebrem seus ids do servido
    private void SetIds()
    {
        for (int i=0;i<4;i++)
        {
            players[i].Dados = listOfIdsServeSorted[i];
        }
    }
    //events system

    public PlayerData Player {
        get {
            return player;
        }
        set {
            player = value;
        }
    }

    //chupa pica
    public MatchData Match {
        get {
            return match;
        }
        set {
            match = value;
        }
    }


}
