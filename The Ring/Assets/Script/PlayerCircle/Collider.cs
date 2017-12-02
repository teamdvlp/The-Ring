using System.Collections;
using UnityEngine;
public class Collider : MonoBehaviour {
	public delegate void PlayerColliderWithMapBorder (GameObject map);
	public delegate void PlayerColliderWithBackground (GameObject map);
	
	public event PlayerColliderWithMapBorder OnPlayerColliderWithMapBorder;
	public event PlayerColliderWithBackground OnPlayerColliderWithBackground;
    public OnGameOver gameOverManager;
    public bool isHavingArmor;
    public bool collided;

	void Start () {
    }

	void OnTriggerEnter2D(Collider2D col)
	{
				Debug.Log("Mapborder" + col.gameObject.layer);
		
		if (col.gameObject.layer == 21) {
			if (OnPlayerColliderWithMapBorder != null) {
				OnPlayerColliderWithMapBorder(col.gameObject.transform.parent.gameObject);
			}
		}
		else if (col.gameObject.layer == 19) {
			if (OnPlayerColliderWithBackground != null) {
				OnPlayerColliderWithBackground(col.gameObject);
			}
		}
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!collided)
        {
            // gameOverManager.Die();
            // 22 = Impedement
            if (col.gameObject.layer == 22)
            {
                if (!isHavingArmor)
                {
                    // gameOverManager.Die();
                }
                else
                {
                    isHavingArmor = false;
                }

            }
            collided = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }
}
