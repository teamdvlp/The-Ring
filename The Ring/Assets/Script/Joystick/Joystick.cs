using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	public Image imgBg;
	public Text txtPointPos;
	public Text txtJoystickPos;
	public Image imgJoystick;
	public Vector3 InputDirection {get;set;}
	private RuntimePlatform platform;
	private PointerEventData eventPointer;

 void Start () {
platform = Application.platform;
}

	public virtual void OnDrag (PointerEventData ped) {
		Vector2 pos = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle
		(imgBg.rectTransform,ped.position,ped.pressEventCamera,out pos)) {
			 pos.x = (pos.x / imgBg.rectTransform.sizeDelta.x);
		     pos.y = (pos.y / imgBg.rectTransform.sizeDelta.y);

			 InputDirection = new Vector3(pos.x,0,pos.y);
			 InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
			 imgJoystick.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (imgBg.rectTransform.sizeDelta.x/2.5f),
			InputDirection.z * (imgBg.rectTransform.sizeDelta.y/2.5f));
				}
	}

	public virtual void OnPointerDown (PointerEventData ped) {
		OnDrag(ped);
	}

	public virtual void OnPointerUp (PointerEventData ped) {
		InputDirection = Vector3.zero;
		imgJoystick.rectTransform.anchoredPosition = InputDirection;
	}

	 void Update () {
	}

}
