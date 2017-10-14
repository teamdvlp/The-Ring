using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

	public Vector3 startPoint, endPoint, direction;
	public GameObject player;
	public GameObject point1, point2, point3, point4, point5;
	Rigidbody2D rigidBody;
	public float force;
	public bool canSwipe;

	public void OnPointerDown(PointerEventData eventData)
	{
		startPoint = eventData.position;
	}

	public void OnDrag (PointerEventData evenData) 
	{//
		endPoint = evenData.position;
		direction = (endPoint - startPoint) / 100f;
		direction = direction.magnitude > 4 ? direction.normalized * 4 : direction;
		point1.transform.position = player.transform.position + direction *  0.2f;
		point2.transform.position = player.transform.position + direction * 0.4f;
		point3.transform.position = player.transform.position + direction * 0.6f;
		point4.transform.position = player.transform.position + direction * 0.8f;
		point5.transform.position = player.transform.position + direction * 1f;
		setActivePoint (true);
	}

	public void OnPointerUp (PointerEventData eventData) 
	{
			setActivePoint (false);
			direction = (Vector3) eventData.position - startPoint;
			direction /= 3f;
			rigidBody.AddForce (-direction * force);
	}

	void setActivePoint(bool isActive) {
		point1.SetActive(isActive);
		point2.SetActive(isActive) ;
		point3.SetActive(isActive);
		point4.SetActive(isActive);
		point5.SetActive(isActive);
	}


	void Start () {
		rigidBody = player.GetComponent<Rigidbody2D> ();
	}


	
	void Update () {
		
	}
}
