using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRingProtect : MonoBehaviour
{

    private OnTriggerd onTrig;
    public GameObject ColliderPlayer;

    void Start()
    {
        onTrig = ColliderPlayer.GetComponent<Collider>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTrig.OnTriggeredEnter(this.gameObject);
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTrig.OnTriggeredExit(this.gameObject);
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        onTrig.OnTriggeredStay(this.gameObject);        
    }

    public interface OnTriggerd {
        void OnTriggeredEnter(GameObject col);
        void OnTriggeredExit(GameObject col);
        void OnTriggeredStay(GameObject col);
    }
}
