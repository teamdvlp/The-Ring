using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour {
    Collider playerCollider;
    public SpriteRenderer armorSprite;


    void Start ()
    {
        playerCollider = GetComponent<Collider>();
        if (playerCollider == null)
        {
            Debug.Log("FUCK");
        }
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        // 23 = Armor
        if (col.gameObject.layer == 23)
        {
            playerCollider.isHavingArmor = true;
            armorSprite.sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
            armorSprite.enabled = true;
            Destroy(col.gameObject);
        }
    }
	
}
