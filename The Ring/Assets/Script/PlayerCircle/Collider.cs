using System.Collections;
using UnityEngine;
public class Collider : MonoBehaviour {
	public delegate void PlayerColliderWithMapBorder (GameObject map);
	public delegate void PlayerColliderWithBackground (GameObject map);
	
	public event PlayerColliderWithMapBorder OnPlayerColliderWithMapBorder;
	public event PlayerColliderWithBackground OnPlayerColliderWithBackground;
	void Start () {
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
        if (col.gameObject.layer == 22)
        {
            // gameOverManager.Die();
        }
    }
}
