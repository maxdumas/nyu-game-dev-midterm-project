using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {
	public int Targets;
	public int TargetsHit;

	public delegate void AllTargetsHitAction();
	public event AllTargetsHitAction OnAllTargetsHit;

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
			if(!child.gameObject.activeSelf) continue; // Skip disabled targets

			++Targets;
			var target = child.gameObject.GetComponent<Target>();
			if(target != null) {
				target.OnTargetHit += TargetHit;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void TargetHit(Collider other) {
		++TargetsHit;
		Debug.Log ("Child target hit");
		if(TargetsHit >= Targets) {
			OnAllTargetsHit();
			Debug.Log ("All targets hit");
		}
	}
}
