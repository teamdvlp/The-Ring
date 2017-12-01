using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAt : MonoBehaviour {

    public GameObject pos;
    public Renderer sprite;

    private void Start()
    {
        Debug.Log(sprite.bounds.size.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION NHE");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER NHE");
    }

}
