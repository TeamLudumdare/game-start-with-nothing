using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private static SceneController instance;
    
    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
    }

    void Update()
    {
        if (EnterLobby ()) {
            SceneManager.LoadScene("SalaDeEspera");
        }
        if (StartGameButton()) {
            SocketController.Instance.StartGame();
        }
        if (StartGame ()) {
            SceneManager.LoadScene("FieldGame");
        }
    }

    private bool EnterLobby() {
        var lobby = SocketController.Instance.Lobby;
        return lobby != null && !Equals(SceneManager.GetActiveScene().name, "SalaDeEspera");
    }

    private bool StartGameButton () {
        var lobby = SocketController.Instance.Lobby;
        return Input.GetKeyUp(KeyCode.Return) && lobby.playersData.Count == 4;
    }

    private bool StartGame () {
        var match = SocketController.Instance.Match;
        return match != null && !Equals(SceneManager.GetActiveScene().name, "FieldGame");
    }

    public static SceneController Instance {
        get {
            return instance;
        }
    }
}
