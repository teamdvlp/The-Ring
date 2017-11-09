using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler {

	public Vector3 startPoint, endPoint, direction;
	public GameObject player;
	public GameObject point1, point2, point3, point4, point5;
	public GameObject moveEffect;
	Rigidbody2D rigidBody;
	public float force;
	private bool isDragging;



    public void OnPointerDown(PointerEventData eventData)
	{
		startPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        point1.transform.position = new Vector3(startPoint.x,startPoint.y, -10);
        Debug.Log(eventData.position);
        Debug.Log(startPoint);
    }



    public void OnDrag (PointerEventData eventData) 
	{
        Vector3 vec = Camera.main.ScreenToWorldPoint(eventData.position);
        point2.transform.position = new Vector3(vec.x, vec.y, -10);
        isDragging = true;
		endPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        direction = (endPoint - startPoint);
		direction = direction.magnitude > 3? direction.normalized * 3f: direction;
		moveEffect.transform.LookAt (point5.transform);
		setActivePoint (true);
	}



    public void OnEndDrag(PointerEventData eventData) {
		isDragging = false;
	}
    


	public void OnPointerUp (PointerEventData eventData) 
	{
			setActivePoint (false);
			direction = (Vector3) endPoint - startPoint;
			direction /= 3f;
			rigidBody.velocity = (-direction) * force;
	}



	void setActivePoint(bool isActive) {
        point1.SetActive(isActive);
        point2.SetActive(isActive);
        point3.SetActive(isActive);
        point4.SetActive(isActive);
        point5.SetActive(isActive);
    }

    public void SetPointPosition()
    {
        point1.transform.position = player.transform.position + direction * 0.2f;
        point2.transform.position = player.transform.position + direction * 0.4f;
        point3.transform.position = player.transform.position + direction * 0.6f;
        point4.transform.position = player.transform.position + direction * 0.8f;
        point5.transform.position = player.transform.position + direction * 1f;
    }

    void Start () {
		rigidBody = player.GetComponent<Rigidbody2D> ();
	}


	
	void Update () {
		if (isDragging) {
			SetPointPosition ();
		}
	}
}
