using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundController : MonoBehaviour {
	public int Round;
	public GameObject[] LaserRounds;
	public float RoundWarmupTime;
	public Text display;
	public float SloMoTimeScale;

	private float _t;

	// Use this for initialization
	void Start () {
		StartCoroutine(ManageRounds());
	}
	
	// Update is called once per frame
	void Update () {
		if(_t < RoundWarmupTime) {
			display.text = Mathf.Floor(RoundWarmupTime - _t + 1f).ToString();
			_t += Time.deltaTime;
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, 1f, 0.125f);
		} else {
			display.text = "GO!!!";
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, SloMoTimeScale, 0.125f);
		}

		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	IEnumerator ManageRounds() {
		foreach(GameObject round in LaserRounds) {
			++Round;
			_t = 0f;
			round.SetActive(true);
			yield return new WaitForSeconds(RoundWarmupTime);
			float longestWaitTime = 0f;
			foreach(Transform child in round.transform) {
				var c = child.gameObject.GetComponent<MoveOnAxis>();
				c.enabled = true;
				longestWaitTime = Mathf.Max (longestWaitTime, c.Duration);
			}
			yield return new WaitForSeconds(longestWaitTime);
		}
	}
}
