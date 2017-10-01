using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    public GameObject collideEffect;
    PassThroughEffect passThroughEffect;
    ParticleSystem circleParticle;

    Nature playerNature;

    void Start () {
        passThroughEffect = GetComponent<PassThroughEffect>();
        playerNature = gameObject.GetComponent<Nature>();
    }
	
	void Update () {
    
    }

    void CollideEffect (Collision2D col)
    {
        ContactPoint2D point = col.contacts[0];
        Vector2 position = point.point;
        Instantiate(collideEffect,position,gameObject.transform.rotation);
    }

    void OnCollisionStay2D (Collision2D col)
    {
        CollideEffect(col);
    }

    void OnCollisionEnter2D (Collision2D col) {

        if (col.gameObject.layer == 9)
        {
            CollideEffect(col);

            if (col.gameObject.GetComponent<Nature>() == null)
            {
                return;
            }
            int natureIndex1 = playerNature.nature;
            int natureIndex2 = col.gameObject.GetComponent<Nature>().nature;
            CompareNature compareNat = new CompareNature(natureIndex1, natureIndex2);
            int compareResult = compareNat.compareNature();
            switch (compareResult)
            {
                case 0:
                    {
                        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                        circleParticle = col.gameObject.GetComponentInChildren<ParticleSystem>();
                        passThroughEffect.EnableTrigger(circleParticle);
                        Debug.Log("Enter ! Enabled");
                        return;
                    }
                case 1:
                    {
                        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                        return;
                    }
                case 2:
                    {
                        Destroy(gameObject.GetComponent<ChangeNature>().playerCurrentNature);
                        playerNature.nature = 0;
                        return;
                    }
                case 3:
                    {
                        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                        return;
                    }
                default:
                    return;
            }
        }

	}

    void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.layer == 9)
        {
            circleParticle = col.gameObject.GetComponentInChildren<ParticleSystem>();
            passThroughEffect.DisableTrigger(circleParticle);
            Debug.Log("Exit : Disable");
        }
    }

	void OnTriggerExit2D (Collider2D col) {
		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
	}
}
