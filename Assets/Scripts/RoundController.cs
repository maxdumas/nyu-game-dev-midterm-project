using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundController : MonoBehaviour {
	public int ActiveLasers;
	public GameObject Lasers;
	public float RoundWarmupTime;
	public Text display;
	public float SloMoTimeScale;
	public Killable Player;

	private float _t;
	private bool _roundsComplete;

	// Use this for initialization
	void Start () {
		foreach(Transform child in Lasers.transform) {
			child.gameObject.SetActive(false);
		}
		StartCoroutine(ManageRounds());
	}
	
	// Update is called once per frame
	void Update () {
		if(!Player.Alive) {
			display.text = "YOU ARE DEAD.\n[SPACE] TO RESTART.";
			StopCoroutine("ManageRounds");
			if(Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel(0);
			}
		} else if(_roundsComplete) {
			display.text = "YOU HAVE DEFEATED THE CAPTOR.\n[SPACE] TO RESTART.";
			if(Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel(0);
			}
		} else if(_t < RoundWarmupTime) {
			display.text = string.Format("{0:F2}", RoundWarmupTime - _t + 1f).ToString();
			_t += Time.deltaTime;
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, 1f, 0.125f);
		} else {
			display.text = "GO!!!";
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, SloMoTimeScale, 0.125f);
		}

		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	IEnumerator ManageRounds() {
		foreach(Transform child in Lasers.transform) {
			var laser = child.gameObject;
			++ActiveLasers;
			_t = 0f;
			laser.SetActive(true);
			yield return new WaitForSeconds(RoundWarmupTime);
			var c = child.gameObject.GetComponent<MoveOnAxis>();
			c.enabled = true;
			yield return new WaitForSeconds(c.Duration);
		}
		_roundsComplete = true;
	}
}
