using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawning : MonoBehaviour {
                            // Impediment : chướng ngại vật
    public List<GameObject> list_Impediment;
    public List<Transform> list_ImpedimentPosition;
    public List<GameObject> list_Coin;


    // Use this for initialization
    void Start () {
        AppearCoin();
        AppearImpediment();
    }

    void AppearCoin ()
    {
        int positionCoin = Random.Range(0, list_Coin.Count);
        GameObject coin = list_Coin[positionCoin];
        coin.SetActive(true);
    }


    void AppearImpediment ()
    {
        int impedimentCount = Random.Range(0, list_ImpedimentPosition.Count);

        for (int i = 0; i <= impedimentCount; i++)
        {
            int impedimentIndex = Random.Range(0, list_Impediment.Count);
            GameObject impediment = list_Impediment[impedimentIndex];

            int impedimentPosition = Random.Range(0, list_ImpedimentPosition.Count);
            Instantiate(impediment, list_ImpedimentPosition[i].position,Quaternion.identity);
        }
    }
}
