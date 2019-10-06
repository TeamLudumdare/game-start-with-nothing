using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private InputField salaDoLobby;
    [SerializeField] private InputField nomeDoJogador;

    private void Update () {
        salaDoLobby.text = salaDoLobby.text.ToUpper();
    }

    public void CriarLobby () {
        SocketController.Instance.CriarLobby(nomeDoJogador.text);
    }

    public void ConectarLobby () {
        SocketController.Instance.FazerLogin(salaDoLobby.text, nomeDoJogador.text);
    }
}
