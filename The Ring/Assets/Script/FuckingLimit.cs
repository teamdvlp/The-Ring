using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckingLimit : MonoBehaviour {
    public GameObject fuckingBoard;
    public GameObject replayBUtton;

    void Start()
    {
        fuckingBoard.SetActive(false);
        replayBUtton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Destroy(col.gameObject);
            End();
        }
    }

    public void End()
    {
        fuckingBoard.SetActive(true);
        replayBUtton.SetActive(true);
    }
}
