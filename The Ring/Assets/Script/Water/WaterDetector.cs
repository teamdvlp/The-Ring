using UnityEngine;
using System.Collections;

public class WaterDetector : MonoBehaviour {
    private float WaterDensity;

    void Start()
    {
        WaterDensity = transform.parent.GetComponent<Water>().WaterDensity;        
    }

    void OnTriggerEnter2D(Collider2D Hit)
    {
        if (Hit.GetComponent<Rigidbody2D>() != null)
        {
        // nếu mess nhỏ hơn 6 thì sẽ không còn chính xác, không còn đẹp được nữa
        if (Hit.GetComponent<Rigidbody2D>().mass >= 6) {
          transform.parent.GetComponent<Water>().Splash(transform.position.x, 
          ((Hit.GetComponent<Rigidbody2D>().velocity.y*Hit.GetComponent<Rigidbody2D>().mass)
          /WaterDensity)/220);
        } else {
          Debug.LogError("mass must greater than or equal 6");
        }
        }
    }
}
