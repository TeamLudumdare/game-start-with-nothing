using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private LobbyData lobby;
    private PlayerData player;

    //players
    [SerializeField]
    private List<Player> players = new List<Player>();
    //lista de id, deve receber os id do servidor, porem o primeiro id deve sempre ser o do jogador
    [SerializeField]
    private List<string> listOfIdsServe = new List<string>();
    private List<string> listOfIdsServeSorted = new List<string>();
    //TODO: CAMPO DE TESTE ID PLAYER
    [SerializeField]
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

        
        //fazendo testes de id, preechendo com ids genericos
        int playerIdIndexInList = -1;
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                playerIdIndexInList = listOfIdsServe.BinarySearch(myid);
                listOfIdsServeSorted.Add(listOfIdsServe[playerIdIndexInList]);
            }
            if (i != playerIdIndexInList)
            {
                listOfIdsServeSorted.Add(listOfIdsServe[i]);
            }
        }
        foreach (string id in listOfIdsServeSorted)
        {
            Debug.Log(id);
        }
        SetIds();
    }

    public void UserLogged() {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ConectarNaSala"));
    }
    //Fazendo gameobjects dos players, recebrem seus ids do servido
    private void SetIds()
    {
        for (int i=0;i<4;i++)
        {
            players[i].SetId(listOfIdsServeSorted[i]);
        }
    }
    //events system

    public LobbyData Lobby {
        get {
            return lobby;
        }
        set {
            lobby = value;
        }
    }

    public PlayerData Player {
        get {
            return player;
        }
        set {
            player = value;
        }
    }

}
