using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNature : MonoBehaviour {

    public GameObject fire, water, grass, ground, metal;
    public GameObject playerCurrentNature;
    public float size;

	// Use this for initialization
	void Start () {
         
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
                    break;
                }
            case 2:
                {
                    Change(grass);
                    break;
                }
            case 3:
                {
                    Change(water);
                    break;
                }
            case 4:
                {
                    Change(fire);
                    break;
                }
            case 5:
                {
                    Change(ground);
                    break;
                }
        }
    }

    void Change(GameObject nature)
    {
        GameObject oldEffect = GameObject.FindGameObjectWithTag("NatureEffect");
        if (oldEffect != null) {
            Destroy(oldEffect);
		}
        playerCurrentNature = Instantiate(nature, gameObject.transform.position, gameObject.transform.rotation,gameObject.transform);
        playerCurrentNature.transform.localScale = new Vector3(size,size,size);
    }
}
