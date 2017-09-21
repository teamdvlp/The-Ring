using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonsterFollow : MonoBehaviour {
    public Image monsterPosition, playerPosition, wholeStreet;
    public float streetLenght;
    float destination;
    float startingPoint;
    public GameObject player;
    public GameObject monster;
    Transform monsterTransform, playerTransform;
    public float monsterSpeed;

	// Use this for initialization
	void Start () {
        monsterTransform = monster.transform;
        playerTransform = player.transform;
        startingPoint = monsterTransform.position.x;
        destination = startingPoint + streetLenght;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        UpdateMonsterPosition();
	}

    void UpdateMonsterPosition ()
    {
        float position = (monsterTransform.position.x - startingPoint) / streetLenght;
        monsterPosition.transform.localScale = new Vector3(position, monsterPosition.transform.localScale.y, monsterPosition.transform.localScale.z);
        if (monsterTransform.position.x >= destination)
        {
            Destroy(gameObject);
        }
    }

    void Move ()
    {
        monsterTransform.position = new Vector3(monsterTransform.position.x + monsterSpeed * Time.deltaTime, monsterTransform.position.y, monsterTransform.position.z);
    }
}
