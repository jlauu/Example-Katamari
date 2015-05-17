using UnityEngine;
using System.Collections;

public class TestKatamari : MonoBehaviour {
	private Vector3 velocity;
	private float radius;
	private float circum;
	private float sqr360 = 360 * 360;

	// helper calculate circumference

	private void updateCircum () {
		circum = 2 * Mathf.PI * radius;
	}

	// Use this for initialization
	void Start () {
		velocity = new Vector3 (1, 0, 1);
		radius = 3.0f;
		updateCircum ();
	}

	// Update is called once per frame
	void Update () {
		roll (velocity);
	}
		
	void roll (Vector3 vect) {
		Vector3 axisOfRotation = Vector3.Cross (Vector3.up, vect);
		float angleOfRotation = sqr360 * circum / vect.sqrMagnitude;
		angleOfRotation = Mathf.Sqrt (angleOfRotation);
		transform.RotateAround (transform.position, axisOfRotation, 1);
	}
}
