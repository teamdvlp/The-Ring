using System.Collections;
using UnityEngine;
public class Collider : MonoBehaviour {
	public delegate void PlayerColliderWithMapBorder (GameObject map);
	public delegate void PlayerColliderWithBackground (GameObject map);
	
	public event PlayerColliderWithMapBorder OnPlayerColliderWithMapBorder;
	public event PlayerColliderWithBackground OnPlayerColliderWithBackground;
    GameOverManager gameOverManager;
    public bool isHavingArmor;
    public bool collided;

	void Start () {
        gameOverManager = GetComponent<GameOverManager>();
    }

	void OnTriggerEnter2D(Collider2D col)
	{
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
            // 25 = PlayerKiller ; 18 = Monster
            if (col.gameObject.layer == 25 || col.gameObject.layer == 18)
            {
                if (!isHavingArmor)
                {
                    gameOverManager.Die();
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
