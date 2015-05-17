using UnityEngine;
using System.Collections;

public class Katamari : MonoBehaviour {
	// Components
	private Player player;
	private SphereCollider trueContact;

	// Properties
	private float rollSpeedScale;
	private float _radius;
	public float radius {get {return _radius;} }
	private float _size;
	public float size { get { return _size; } }


	void Awake () {
		player = transform.GetComponentInParent<Player> ();
		trueContact = transform.GetComponent<SphereCollider> ();
	}

	// Use this for initialization
	void Start () {
		_radius = trueContact.radius;
		rollSpeedScale = _radius * 6;
	}

	public void itemContact(Collider hit) {
		RolledItem item = hit.transform.GetComponent<RolledItem> ();
		if (item) {
			if (item.size < _radius) {
				rollupItem(item);
			}
		}
	}

	void OnTriggerEnter(Collider item) {
		itemContact(item);
	}

	void rollupItem(RolledItem item) {
		_radius = Vector3.Distance (item.transform.position, transform.position) * 0.9f;
		trueContact.radius = _radius;
		item.transform.SetParent (transform);
		item.rolled ();
	}
	
	public void roll (Vector3 vect) {
		Vector3 axisOfRotation = Vector3.Cross (Vector3.up, vect);
		float angle = vect.magnitude / rollSpeedScale * 360;
		angle = Mathf.Clamp (angle, -10, 10);
		transform.RotateAround (transform.position, axisOfRotation, angle);
	}

}
