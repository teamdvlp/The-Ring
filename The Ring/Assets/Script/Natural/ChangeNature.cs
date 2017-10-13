using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNature : MonoBehaviour {

    public GameObject fire, water, grass, ground, metal;
    public GameObject playerCurrentNature, SmokeTransformFire,SmokeTransformGrass, SmokeTransformWater, SmokeTransformGround, SmokeTransformMetal;
    public Sprite firePlayer, waterPlayer, grassLayer, groundLayer, metalPlayer;
    public float size;
	Nature playerNature, coreNature;
    Animator animTransformLight;
    SpriteRenderer playerRenderer;

	// Use this for initialization
	void Start () {
        playerRenderer = GetComponent<SpriteRenderer>();
		playerNature = GetComponent<Nature> ();	
	}

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Core")
        {
			coreNature = col.GetComponent<Nature> ();
			if (playerNature.nature != coreNature.nature)
            {
				playerNature.nature = coreNature.nature;
				SetNature(coreNature.nature);
            }
            Destroy(col.gameObject);
        }
    }

    public void SetNature(int nature)
    {
        GetComponent<Nature>().nature = nature;
        switch (nature)
        {
            case 1:
                {
                    Change(metal);
                    Instantiate(SmokeTransformMetal, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f), transform.rotation);
                    playerRenderer.sprite = metalPlayer;
                        break;
                }
            case 2:
                {
                    Instantiate(SmokeTransformGrass, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f), transform.rotation);
                    Change(grass);
                    playerRenderer.sprite = grassLayer;
                    break;
                }
            case 3:
                {
                    Instantiate(SmokeTransformWater, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f), transform.rotation);
                    Change(water);
                    playerRenderer.sprite = waterPlayer;
                    break;
                }
            case 4:
                {
                    Instantiate(SmokeTransformFire, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f), transform.rotation);
                    Change(fire);
                    playerRenderer.sprite = firePlayer;
                    break;
                }
            case 5:
                {
                    Instantiate(SmokeTransformGround, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f), transform.rotation);
                    Change(ground);
                    playerRenderer.sprite = groundLayer;
                    break;
                }
        }
    }

    void Change(GameObject nature)
    {
        Destroy(playerCurrentNature);
		Debug.Log ("Core : " + coreNature.nature);
        playerCurrentNature = Instantiate(nature, gameObject.transform.position, gameObject.transform.rotation,gameObject.transform);
        playerCurrentNature.transform.localScale = new Vector3(size,size,size);
    }
}
