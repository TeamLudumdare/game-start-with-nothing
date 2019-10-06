using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private InputField salaDoLobby;
    [SerializeField] private InputField nomeDoJogador;

    // Update is called once per frame
    public void CriarLobby () {
        SocketController.Instance.CriarLobby(nomeDoJogador.text);
    }
}
