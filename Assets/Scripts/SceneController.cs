using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private static SceneController instance;

    private bool returnPressed = false;

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
            returnPressed = true;
            SocketController.Instance.StartGame();
        }
        if (StartGame ()) {
            SceneManager.LoadScene("FieldGame");
        }
    }

    private bool EnterLobby() {
        var lobby = SocketController.Instance.Lobby;
        return lobby != null && Equals(SceneManager.GetActiveScene().name, "MainMenu");
    }

    private bool StartGameButton () {
        var lobby = SocketController.Instance.Lobby;
        if (lobby != null && !returnPressed)
        {
            return Input.GetButton("Submit") && lobby.playersData.Length == 4;
        }
        return false;
    }

    private bool StartGame () {
        var match = SocketController.Instance.Match;
        return match != null && Equals(SceneManager.GetActiveScene().name, "SalaDeEspera");
    }

    public static SceneController Instance {
        get {
            return instance;
        }
    }
}
