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

    public void SetLobby (LobbyData lobby) {
        this.lobby = lobby;
        SceneManager.LoadScene("SalaDeEspera");
    }
}
