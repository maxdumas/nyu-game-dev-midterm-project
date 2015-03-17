using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {
	public bool Alive = true;
	public GameObject Explosion;
	public float Jank;

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
			StartCoroutine(GlitchOut());
			StartCoroutine(LoadLevel());
		}
	}
	
	IEnumerator GlitchOut() {
		yield return new WaitForSeconds(0.2f);
		var objects = GameObject.FindObjectsOfType<Transform>();
		while(true) {
			int i = Random.Range(0, objects.Length);
			objects[i].position += Random.onUnitSphere * Jank;
			yield return new WaitForEndOfFrame();
		}
	}
	
	IEnumerator LoadLevel() {
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Lose");
	}
}
