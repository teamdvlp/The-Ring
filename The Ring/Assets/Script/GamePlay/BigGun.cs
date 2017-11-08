using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGun : MonoBehaviour {
    public float force;
    public GameObject rope;
    public float shootTime;
    private static bool isSetPosition;
    public Swipe swipe;
    public GameObject shootEffectPosition;
    public GameObject shootEffect;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("PlayerCircle"))
        {
            if (!isSetPosition)
            {
                swipe.enabled = false;
                col.gameObject.transform.position = transform.position;
                OnPreparingShoot();
                StartCoroutine(Shoot(col.gameObject));
                isSetPosition = true;
            }
        }
    }

    void OnPreparingShoot ()
    {
        Animator rope_animator = rope.GetComponent<Animator>();
        rope_animator.Play("Burn");
    }

    IEnumerator Shoot (GameObject gameObjects)
    {
        yield return new WaitForSeconds(shootTime);
        Instantiate(shootEffect, shootEffectPosition.transform.position, shootEffectPosition.transform.rotation);
        this.gameObject.GetComponent<Animator>().Play("BigGunShoot");
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        gameObjects.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);
        swipe.enabled = true;
        Debug.Log("Shoot");
    }

   
}
