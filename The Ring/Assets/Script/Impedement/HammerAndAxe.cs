using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAndAxe : MonoBehaviour {

    private Rigidbody2D rigid;
    public float TimeToReverse;
    private bool isReversing;
    private bool isStop;
    public float speed;
    private float speedCache;
    public float accelabration;
    public bool  isTop;
    private void Start()
    {
        isTop = true;
        speedCache = speed;
        isStop = false;
        isReversing = false;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        if (!isStop) {
            if (isTop) {
                speed = speed + speedCache*accelabration*Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isStop) {
            this.transform.Rotate(0,0,speed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)   
    {
        if (col.gameObject.name.Equals("PlayerCircle"))
        {
            rigid.constraints = RigidbodyConstraints2D.None;
            Destroy(GetComponent<HammerAndAxe>());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Ring
        if (other.gameObject.layer == 9) {
            speed = speed/Mathf.Abs(speed) * speedCache;
            isStop = true;
            isTop = !isTop;
           if (!isReversing) {
               isReversing = true;
               StartCoroutine(reverseAfterSec());
           } 
        }
    }

    private IEnumerator reverseAfterSec () {
        yield return new WaitForSeconds(TimeToReverse);
            speed = -1*speed;
            isStop = false;
            isReversing = false;

    }

}
