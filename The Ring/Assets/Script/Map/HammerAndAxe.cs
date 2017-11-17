using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAndAxe : MonoBehaviour {

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("PlayerCircle"))
        {
            rigid.constraints = RigidbodyConstraints2D.None;
            Destroy(GetComponent<HammerAndAxe>());

        }
    }

}
