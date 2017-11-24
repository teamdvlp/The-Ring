using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public GameObject top;

    void Start ()
    {
        EndlessBackground.previousPosition = top.transform.position;
    }

    public void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("PlayerCircle"))
        {
                EndlessBackground.CreateNextBackground();
                Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }

}
