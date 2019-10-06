using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour
{
    private int lifePoints;
    [SerializeField]
    private string _id;//id referente ao seu indice no servidor
    private int moves;//numero de movimentos que o jogador pode realizar em sua jogada
    // Start is called before the first frame update
    public void SetId(string _id)
    {
        this._id = _id;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TOCOU NO PLAYER >>>> "+_id);
    }
}
