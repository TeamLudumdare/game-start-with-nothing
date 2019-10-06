using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> listItemsBar = new List<GameObject>();//lista de posições dos itens na life bar
    [SerializeField]
    private GameObject myPrefab;
    private int numOfItems = 0;
    private void OnMouseDown()
    {
        if (gameObject.tag == "Chest") {
            BuyItem();
        }
        
    }
    private void BuyItem()
    {
        numOfItems = GameObject.FindGameObjectsWithTag("Item").Length;
        Debug.Log(numOfItems);
        Instantiate(myPrefab, new Vector3(listItemsBar[numOfItems].transform.position.x, listItemsBar[numOfItems].transform.position.y,
                                          listItemsBar[numOfItems].transform.position.z -0.5f),Quaternion.identity);
        //TODO: ENVIAR PARA O SERVIDOR QUE FOI ADIONADO UM ITEM A SUA LISTA, PARA ELE ATUALIZAR PARA TODOS OS JOGADORES
        
    }
}
