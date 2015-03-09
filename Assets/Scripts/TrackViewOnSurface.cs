using UnityEngine;
using System.Collections;

public class TrackViewOnSurface : MonoBehaviour {
	public Collider Constraints;
	public Transform Target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		this.transform.position = Constraints.ClosestPointOnBounds(Player.position);
		this.transform.position = Target.forward * 10.2f + Constraints.transform.position;
		this.transform.LookAt(Target.position);
	}
}
