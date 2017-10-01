using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughEffect : MonoBehaviour {
    ParticleSystem.TriggerModule trigger;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableTrigger(ParticleSystem particle)
    {
        trigger = particle.trigger;
        trigger.enabled = true;
    }

    public void DisableTrigger(ParticleSystem particle)
    {
        trigger = particle.trigger;
        trigger.enabled = false;
    }
}
