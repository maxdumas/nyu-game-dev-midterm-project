using UnityEngine;
using System.Collections;

public class MoveOnAxis : MonoBehaviour {
	public float Speed;
	public float Duration;

	private float _t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_t < Duration) {
			transform.position += Time.deltaTime * Speed * transform.forward;
			_t += Time.deltaTime;
		} else {
			this.enabled = false;
		}
	}
}
