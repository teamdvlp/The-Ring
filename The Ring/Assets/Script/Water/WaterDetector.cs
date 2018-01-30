using UnityEngine;
using System.Collections;

public class WaterDetector : MonoBehaviour {
    private float WaterDensity;
    private float decreaseMass;
    void Start()
    {
        decreaseMass = GetComponentInParent<Water>().decreaseMass;
        WaterDensity = GetComponentInParent<Water>().WaterDensity;        
    }

    void OnTriggerEnter2D(Collider2D Hit)
    {
        // nếu mess nhỏ hơn 6 thì sẽ không còn chính xác, không còn đẹp được nữa
        if (Hit.GetComponent<Rigidbody2D>().mass >= 6) {
          GetComponentInParent<Water>().Splash(transform.position.x, 
          ((Hit.GetComponent<Rigidbody2D>().velocity.y*Hit.GetComponent<Rigidbody2D>().mass)
          /WaterDensity)/decreaseMass);
        }
    }
}
