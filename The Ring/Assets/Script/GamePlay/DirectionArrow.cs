using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour {
    public float rotateSpeed;
    public GameObject director;
    public GameObject players;
    Rigidbody2D playerRigid2D;
    Vector3 direction;
    public bool isTouching { get; set; }
    public GameObject power, ultraPower;

    private void Start()
    {
        playerRigid2D = players.GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!isTouching)
        transform.Rotate(new Vector3(0,0, rotateSpeed * Time.deltaTime));    
    }

    public void AddForces (float force, bool isUltraPower)
    {
        if (rotateSpeed == 0)
        {
            rotateSpeed = 500;
        }

        if (isUltraPower)
        {
            Instantiate(ultraPower, players.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(power, players.transform.position, Quaternion.identity);
        }
        direction = director.transform.position - transform.position;
        playerRigid2D.velocity = (direction * force);
    }
}
