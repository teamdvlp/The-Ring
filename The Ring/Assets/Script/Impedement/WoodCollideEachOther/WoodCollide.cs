using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollide : MonoBehaviour {

	public float speed;
	public float timeToCollide;
	public float timeToGoBack;
	public GameObject wood1;
	public GameObject wood2;
	public NotiWhenWoodCollide notiWhenWoodCollide;
	void Start () {
		notiWhenWoodCollide.OnWoodCollide += OnWoodCollide;
		StartCoroutine(CollideWood());
	}
	void Update () {
		
	}

	private IEnumerator CollideWood () {
		yield return new WaitForSeconds(timeToCollide);
			wood1.GetComponent<Rigidbody2D>().velocity = (new Vector2(speed, 0));
			wood2.GetComponent<Rigidbody2D>().velocity = (new Vector2(speed * -1, 0));
	}

	void OnWoodCollide(GameObject col)
	{
		if (col.gameObject.tag.Equals("ImpeWood")) {
			StartCoroutine(GoBack());
		}
		else if (col.tag.Equals("wall")) {
			StartCoroutine(CollideWood());
		}
	}

	private IEnumerator GoBack () {
		yield return new WaitForSeconds(timeToGoBack);
		wood1.GetComponent<Rigidbody2D>().velocity = (new Vector2(speed * -1, 0));
		wood2.GetComponent<Rigidbody2D>().velocity = (new Vector2(speed, 0));
	}
}
