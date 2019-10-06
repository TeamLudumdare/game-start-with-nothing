using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSalaEspera : MonoBehaviour
{
    [SerializeField] private Text nomeJogador;
    [SerializeField] private Text aguardando;
    [SerializeField] private Text playersOnline;
    [SerializeField] private Text idLobby;

    void Update()
    {
        nomeJogador.text = SocketController.Instance.Player.name;
        aguardando.text = SocketController.Instance.Lobby.players < 4 ? "Waiting for players to enter ..." : "Anyone can press enter to start game";
        playersOnline.text = SocketController.Instance.Lobby.players + " of 4 players entered";
        idLobby.text = "Lobby ID: " + SocketController.Instance.Lobby._id;
    }
}
