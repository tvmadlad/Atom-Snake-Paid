using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AtomCoin : MonoBehaviour {

	public TextMesh AtomCoinCountdownText;

	private float countDownTime;

	// Use this for initialization
	void Start () {

		countDownTime = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		countDownTime += Time.deltaTime;
		
		if (countDownTime >= 1f )
			AtomCoinCountdownText.text = "3";
		if (countDownTime >= 2f )
			AtomCoinCountdownText.text = "2";
		if (countDownTime >= 3f )
			AtomCoinCountdownText.text = "1";
		if (countDownTime >= 4f) {
			AtomCoinCountdownText.text = "";
			Destroy (this.gameObject);
		}
	}
}
