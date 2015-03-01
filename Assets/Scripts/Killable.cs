using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {
	public bool Alive = true;
	public ParticleSystem Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Laser")) {
			Debug.Log ("You are dead!");
			Alive = false;
			Instantiate(Explosion, transform.position, transform.rotation);
			this.GetComponent<AircraftControl>().enabled = false;
		}
	}
}
