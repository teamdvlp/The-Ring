using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningCoinAndImpediment : MonoBehaviour {
    public List<GameObject> list_Impediment;
    public List<GameObject> list_GroupCoin;


    void Start () {
        AppearCoin();
        AppearImpediment();
    }

    void AppearCoin ()
    {   
        int CoinCount = Random.Range(0, list_GroupCoin.Count);
        for (int i = 0; i < CoinCount; i++) {
        int CoinIndex = Random.Range(0, list_GroupCoin.Count);
        list_GroupCoin[CoinIndex].SetActive(true);
        }
    }


    void AppearImpediment ()
    {
        int impedimentCount = Random.Range(0, list_Impediment.Count);

        for (int i = 0; i <= impedimentCount; i++)
        {
            int impedimentIndex = Random.Range(0, list_Impediment.Count);
            list_Impediment[impedimentIndex].SetActive(true);
        }
    }
}
