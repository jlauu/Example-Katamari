using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Components
	private Katamari katamari;
	private Camera playerCam;
	// Physics
	public float maxSpeed = 1.0f;
	public float baseSpeed = 0.5f;
	public float baseTurnSpeed = 1.5f;
	public float friction = 0.85f;
	private Vector3 velocity;

	// Input
	private float vert;
	private float hori;
	private float mouseX;
	private float mouseY;

	// Constraints
	public float minCamRot = 20.0f;
	public float maxCamRot = 35.0f;

	// Properties
	private float _radius;
	public float radius { get { return _radius; } }
	private bool inControl;
	private float playCamDistScale = 1.0f;

	// Use this for initialization
	void Awake () {
		initializeKatamari ();
		velocity = Vector3.zero;
		inControl = false;
	}

	void initializeKatamari () {
		// TODO: dynamic creation for player spawn
		katamari = GetComponentInChildren<Katamari> ();
		playerCam = GetComponentInChildren<Camera> ();

	}

	void Start() {
		inControl = true;
	}

	// Update is called once per frame
	void Update () {
		updateControls ();
		updatePhysics ();
		updatePosition ();
		updateCamera ();
	}

	void updateControls () {
		if (inControl) {
			vert = Input.GetAxis ("Vertical");
			hori = Input.GetAxis ("Horizontal");
		} else {
			vert = 0;
			hori = 0;
		}

		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
	}
	
	void updatePhysics () {
		// Fix input to unit vector
		Vector3 z = Mathf.Sin (Mathf.Asin (vert)) * transform.forward;
		Vector3 x = Mathf.Cos (Mathf.Acos (hori)) * transform.right;

		// Update velocity
		velocity += baseSpeed * (z + x);
		velocity = Vector3.ClampMagnitude (velocity * friction, 1);

		// TODO: Hard collisions and loss-of-control
	}

	void updatePosition() {
		// Forward spin
		transform.RotateAround (transform.position, Vector3.up, mouseX * baseTurnSpeed);

		// New Position
		transform.position = transform.position + velocity;

		// Handles rolling animation
		katamari.roll (velocity);
	}

	void updateCamera() {
		Transform pcamTrans = playerCam.transform;
		Transform kataTrans = katamari.transform;

		// Vertical tilt
		pcamTrans.RotateAround (transform.position, transform.right, mouseY * -baseTurnSpeed);

		// Fix distance
		float dist = 2 * katamari.radius * playCamDistScale;
		Vector3 dir = (pcamTrans.position - kataTrans.position).normalized;
		pcamTrans.position = kataTrans.position + dist * dir;

		// TODO: clamping vertical angle
	}
}
