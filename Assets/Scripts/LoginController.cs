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
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions) {
                Debug.Log(perm);
            }
        } else {
            Debug.Log("User cancelled login");
        }
    }
    public void Login () {
        FB.LogInWithReadPermissions(null, AuthCallback);
    }

    public void Logout () {
        FB.LogOut();
    }
}
