using System.Collections;
using UnityEngine;
public class Collider : MonoBehaviour {
	public delegate void PlayerColliderWithMapBorder (GameObject map);
	public event PlayerColliderWithMapBorder OnPlayerColliderWithMapBorder;
    public GameOver gameOverManager;
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
        if (col.gameObject.layer == 22)
        {
            Debug.Log("ABCS");
            gameOverManager.OverGames();
        }
    }
}
