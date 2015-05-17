using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Components
	private CharacterController cc;
	private Katamari katamari;
	private Camera playerCam;

	// Physics
	public float baseSpeed = 0.5f;
	public float baseTurnSpeed = 1.5f;
	private Vector3 velocity;
	private Vector3 gravity;

	// Input
	private float vert;
	private float hori;
	private float mouseX;
	private float mouseY;

	// Constraints
	public float minCamRot = 20.0f;
	public float maxCamRot = 35.0f;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		katamari = GetComponentInChildren<Katamari> ();
		playerCam = GetComponentInChildren<Camera> ();
		velocity = Vector3.zero;
		gravity = Vector3.down * 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = velocity * 0.9f;
		updateControls ();
		updatePhysics ();
		updatePosition ();
		updateCamera ();
	}

	void updateControls () {
		vert = Input.GetAxis ("Vertical");
		hori = Input.GetAxis ("Horizontal");

		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
	}
	
	void updatePhysics () {
		Vector3 z = Mathf.Sin (Mathf.Asin (vert)) * transform.forward;
		Vector3 x = Mathf.Cos (Mathf.Acos (hori)) * transform.right;
		velocity = z + x;
		velocity *= baseSpeed;
	}

	void updatePosition() {
		transform.RotateAround (transform.position, Vector3.up, mouseX * baseTurnSpeed);
		transform.position = transform.position + velocity;
		katamari.roll (velocity);
	}

	void updateCamera() {
		playerCam.transform.RotateAround (transform.position, transform.right, mouseY);
		float angle = playerCam.transform.localEulerAngles.x;
		print (angle);
	}
}
