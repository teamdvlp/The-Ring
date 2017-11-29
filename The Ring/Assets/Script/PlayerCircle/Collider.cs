using System.Collections;
using UnityEngine;
public class Collider : MonoBehaviour {
	public delegate void PlayerColliderWithMapBorder (GameObject map);
	public event PlayerColliderWithMapBorder OnPlayerColliderWithMapBorder;
    public OnGameOver gameOverManager;
    public bool isHavingArmor;
    public bool collided;

	void Start () {
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 21) {
			if (OnPlayerColliderWithMapBorder != null) {
				OnPlayerColliderWithMapBorder(col.gameObject.transform.parent.gameObject);
			}
		}
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!collided)
        {
            // 22 = Impedement
            if (col.gameObject.layer == 22)
            {
                if (!isHavingArmor)
                {
                    Debug.Log("????");
                    gameOverManager.Die();
                }
                else
                {
                    isHavingArmor = false;
                    Debug.Log("FUCKKK?");
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
