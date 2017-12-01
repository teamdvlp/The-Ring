using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour {

    Transform monsterTransform;
    public float moveSpeed;
    float speed;

	void Start () {
        monsterTransform = gameObject.transform;
        speed = moveSpeed;    
    }
	
	void Update () {
        Move();
    }

    void Move ()
    {
        monsterTransform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Preventer"))
        {
            Debug.Log("ENTER");
            speed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Preventer"))
        {
            Debug.Log("EXIT");
            speed = moveSpeed;
        }
    }
}
