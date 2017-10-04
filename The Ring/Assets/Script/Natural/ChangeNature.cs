using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNature : MonoBehaviour {

    public GameObject fire, water, grass, ground, metal;
    public GameObject playerCurrentNature, SmokeTransformFire,SmokeTransformGrass, SmokeTransformWater, SmokeTransformGround, SmokeTransformMetal;
    public Sprite firePlayer, waterPlayer, grassLayer, groundLayer, metalPlayer;
    public float size;
    public GameObject transformLight;
    Animator animTransformLight;
    SpriteRenderer playerRenderer;

	// Use this for initialization
	void Start () {
        playerRenderer = gameObject.GetComponent<SpriteRenderer>();
        animTransformLight = transformLight.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Core")
        {
            if (gameObject.GetComponent<Nature>().nature != col.gameObject.GetComponent<Nature>().nature)
            {
                gameObject.GetComponent<Nature>().nature = col.gameObject.GetComponent<Nature>().nature;
                
                SetNature(col.gameObject.GetComponent<Nature>().nature);
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
        playerCurrentNature = Instantiate(nature, gameObject.transform.position, gameObject.transform.rotation,gameObject.transform);
        playerCurrentNature.transform.localScale = new Vector3(size,size,size);
        animTransformLight.Play("LightUp");
    }
}
