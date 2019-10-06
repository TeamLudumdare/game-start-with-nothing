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
        
    }

    private bool EnterLobby() {
        var lobby = GameManager.Instance.Lobby;
        return lobby != null && !Equals(SceneManager.GetActiveScene().name, "SalaDeEspera");
    }

    public static SceneController Instance {
        get {
            return instance;
        }
    }
}
