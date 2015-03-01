using UnityEngine;
using System.Collections;

public class CaptorController : MonoBehaviour {
	public Collider Constraints;
	public Transform Player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		this.transform.position = Constraints.ClosestPointOnBounds(Player.position);
		this.transform.position = (Player.position - Vector3.up * 5f).normalized * 10.2f;
	}
}
