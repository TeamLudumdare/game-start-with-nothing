using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    private LobbyData lobby;

    void Awake () {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
    }

    void Update () {
        if (Input.GetButtonUp("Submit") && Equals(SceneManager.GetActiveScene().name, "SalaDeEspera")) {
            SocketController.Instance.StartGame();
        }
    }

    public void SetLobby (LobbyData lobby) {
        this.lobby = lobby;
        SceneManager.LoadScene("SalaDeEspera");
    }
}
