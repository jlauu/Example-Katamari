using UnityEngine;
using System.Collections;

public class Katamari : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 parent = transform.parent.position;
		//transform.position = new Vector3 (parent.x, transform.position.y, parent.z);
	}
	
	public void roll (Vector3 vect) {
		Vector3 axisOfRotation = Vector3.Cross (Vector3.up, vect);
		transform.RotateAround (transform.position, axisOfRotation, 2.0f);
	}
}
