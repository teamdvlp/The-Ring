using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    public GameObject collideEffect;
<<<<<<< HEAD
    PassThroughEffect passThroughEffect;
    ParticleSystem circleParticle;

    Nature playerNature;

    void Start () {
        passThroughEffect = GetComponent<PassThroughEffect>();
        playerNature = gameObject.GetComponent<Nature>();
=======
    private bool pornNature;
	void Start () {
        pornNature = false;
>>>>>>> 9e90ed04ef101891215ed3e0c378417ee4734445
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

<<<<<<< HEAD
            if (col.gameObject.GetComponent<Nature>() == null)
=======
        if (col.gameObject.GetComponent<Nature> () == null) {
			return;
		}
		int natureIndex1 = this.gameObject.GetComponent<Nature> ().nature;
		int natureIndex2 = col.gameObject.GetComponent<Nature> ().nature;
		CompareNature compareNat = new CompareNature (natureIndex1,natureIndex2);
		int compareResult = compareNat.compareNature ();
		switch (compareResult) {
		case 0:
			{
				this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = true;
                    this.pornNature = true;
				return;
			}
            case 1:
            	{
            		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
            		return;
            	}
        case 2:
>>>>>>> 9e90ed04ef101891215ed3e0c378417ee4734445
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
<<<<<<< HEAD
        if (col.gameObject.layer == 9)
        {
            circleParticle = col.gameObject.GetComponentInChildren<ParticleSystem>();
            passThroughEffect.DisableTrigger(circleParticle);
            Debug.Log("Exit : Disable");
        }
=======
>>>>>>> 9e90ed04ef101891215ed3e0c378417ee4734445
    }

	void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.layer == 9)
        {
            Debug.Log("Exit");
            int currentNature = col.gameObject.GetComponent<Nature>().nature;
            if (pornNature)
            {
                if (currentNature >= 5)
                    currentNature = 0;
            }
            else
            {
                ++currentNature;
            }
			GetComponent<ChangeNature>().SetNature(currentNature);
		}
		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;

	}
}
