using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapTap : MonoBehaviour {
    public float rotateSpeed;
    public GameObject director;
    public GameObject players;
    Rigidbody2D playerRigid2D;
    Vector3 direction;
    public bool isTouching;
    public GameObject power;

    private void Start()
    {
        playerRigid2D = players.GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!isTouching)
        transform.Rotate(new Vector3(0,0, rotateSpeed * Time.deltaTime));    
    }

    public void AddForces (float force)
    {
        Instantiate(power, players.transform.position, Quaternion.identity);
        direction = director.transform.position - transform.position;
        playerRigid2D.AddForce(direction * force);
    }
}
