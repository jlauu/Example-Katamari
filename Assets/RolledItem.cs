using UnityEngine;
using System.Collections;

public class RolledItem : MonoBehaviour {
	// Components
	private Player player;
	private Katamari katamari;

	// Properties
	public float size;
	private bool isRolled;
	public delegate void ContactDelegate(Collider item);
	ContactDelegate contact;
	

	// Called after being made child of object
	public void rolled () {
		katamari = transform.GetComponentInParent<Katamari> ();
		player = katamari.transform.GetComponentInParent<Player> ();
		contact = katamari.itemContact;
		rollUpdate (player.radius);
		isRolled = true;
	}

	void Awake () {
		isRolled = false;
	}

	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter(Collider item) {
		contact (item);
	}

	public void rollUpdate(float radius) {
		if (Vector3.Distance (transform.position, katamari.transform.position) < radius) {
			// Enable contact to roll other items
			collider.isTrigger = true;
		} else {
			// Only rigid-body collision
			collider.isTrigger = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (isRolled) {
			// TODO: rolled animations
		} else {
			// TODO: unrolled behavior
		}
	}
}
