using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour
{
    private PlayerData dados;
    private int moves;//numero de movimentos que o jogador pode realizar em sua jogada

    private void Start()
    {
        this.dados = new PlayerData();
    }

    public PlayerData Dados
    {
        get
        {
            return dados;
        }
        set
        {
            dados = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TOCOU NO PLAYER >>>> "+dados._id);
    }
}
