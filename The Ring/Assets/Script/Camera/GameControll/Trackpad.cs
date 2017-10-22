using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Trackpad : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	public Vector2 positionOffset;
 	void Start () {
	}

	public virtual void OnDrag (PointerEventData ped) {
        positionOffset = ped.delta;
	}

	public virtual void OnPointerDown (PointerEventData ped) {
		positionOffset = Vector2.zero;	
	}

	public virtual void OnPointerUp (PointerEventData ped) {
	positionOffset = Vector2.zero;
	}
	
	 void Update () {
	}

}
