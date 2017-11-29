using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
    public GameObject collideEffect;
    public SpriteRenderer armorSprite;
    Collider collider;
    


    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        // 22 = Impedement;
        if (col.gameObject.layer == 22)
        {
            if (collider.isHavingArmor)
            {
                Debug.Log("HM ?");
                ContactPoint2D[] point = col.contacts;
                if (collideEffect != null)
                {
                    Instantiate(collideEffect,point[0].point,transform.rotation);
                } else
                {

                }
                armorSprite.sprite = null;
            }
        }
        
    }
	
}
