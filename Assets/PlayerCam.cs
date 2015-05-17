using UnityEngine;
using System.Collections;

public class PlayerCam : MonoBehaviour {
	// Components
	public Transform target;

	// Input
	private float mouseX;
	private float mouseY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
	
	}

	void updateControls () {
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
		print (mouseX + ", " + mouseY);

	}
}