using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	public ParticleSystem Explosion;
	public string HitterTag;
	public bool isHit = false;

	public delegate void TargetHitAction(Collider other);
	public event TargetHitAction OnTargetHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag(HitterTag)) {
			if(Explosion != null) {
				ParticleSystem e = (ParticleSystem) Instantiate(Explosion, transform.position, Quaternion.identity);
				e.gameObject.transform.parent = transform;
			}
			isHit = true;
			OnTargetHit(other);
		}
	}
}
