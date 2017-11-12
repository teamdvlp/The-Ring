using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotate: MonoBehaviour {
    public float changeRotateTime;
    Rigidbody2D rigid;
    public float upRotateSpeed,downRotateSpeed, delayTimeWhenEndUpRotate, delayTimeWhenEndDownRotate;
    public float topAngle, botAngle;
    private bool isMovingUp = true, isMovingDown = false;
    private bool isTouching = true;


	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.angularVelocity = upRotateSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log(transform.rotation.eulerAngles.z);
        if (isTouching)
        {
            if (isMovingUp)
            {
                if (transform.rotation.eulerAngles.z >= topAngle)
                {
                    rigid.angularVelocity = 0;
                    StartCoroutine(MoveDown());
                }
            }
            else if (isMovingDown)
            {
                if (transform.rotation.eulerAngles.z <= botAngle)
                {
                    rigid.angularVelocity = 0;
                    StartCoroutine(MoveUp());
                }
            }
        } else
        {
            if (transform.rotation.eulerAngles.z <= botAngle)
            {
                rigid.angularVelocity = downRotateSpeed;
            } else
            {
                rigid.angularVelocity = 0;
            }
        }
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        rigid.angularVelocity = upRotateSpeed;
        isTouching = true;
        Debug.Log("ABC");
    }


    IEnumerator MoveDown ()
    {
        yield return new WaitForSeconds(delayTimeWhenEndUpRotate);
        rigid.angularVelocity = downRotateSpeed;
        isMovingDown = true;
        isMovingUp = false;
    }


    IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(delayTimeWhenEndDownRotate);
        rigid.angularVelocity = upRotateSpeed;
        isMovingDown = false;
        isMovingUp = true;
    }
}
