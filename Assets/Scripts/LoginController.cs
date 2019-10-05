using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class LoginController : MonoBehaviour
{

    private static LoginController instance;

    public static LoginController Instance {
        get {
            return instance;
        }
    }

    private string userID;

    public string UserID {
        get {
            return userID;
        }
    }

    void Awake () {
        if (!FB.IsInitialized) {
            FB.Init(InitCallback, OnHideUnity);
        }
    }

    void Start () {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
    }

    private void InitCallback ()
    {
        if (FB.IsInitialized) {
            // Ativa a análise do aplicativo na parte do SDK, validando a retenção dos usuários e etc.
            FB.ActivateApp();
        } else {
            Debug.Log("Não foi possível conectar no Facebook SDK");
        }
    }

    private void OnHideUnity (bool isGameShown)
    {
        if (!isGameShown) {
            // TODO: Mostre pro jogador que o jogo dele não está mais pausado
        } else {
            // TODO: Mostre pro jogador que o jogo dele está pausado
        }
    }

    private void AuthCallback (ILoginResult result) {
        if (FB.IsLoggedIn) {
            // Salva o userID do jogador
            userID = Facebook.Unity.AccessToken.CurrentAccessToken.UserId;
        } else {
            Debug.Log("O usuário cancelou o login");
        }
    }
    
    public void Login () {
        FB.LogInWithReadPermissions(null, AuthCallback);
    }

    public void Logout () {
        FB.LogOut();
    }
}
