using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Snake : MonoBehaviour {

	public GameObject RedTailPrefab;
	public GameObject BlueTailPrefab;
	public GameObject PurpleTailPrefab;
	public GameObject GoldTailPrefab;
	public GameObject EndGsme;
	public GameObject AtomCoin;
	public GameObject CurrentTailPrefab;
	public GameObject LoadingScreen;
	public GameObject SplitControlsGameObject;
	public GameObject RightControlsGameObject;
	public GameObject AlternatingControlsGameObject;


	public GameObject HeadColourBlue;
	public GameObject HeadColourRed;
	public GameObject HeadColourGold;
	public GameObject HeadColourPurple;
	public GameObject HeadColourRainbow;

	public AudioSource GameMusic;
	public AudioSource EffectVolume;
	public AudioSource AtomCoinPickup;


	public Text Score;
	public Text HiScoreText;
	public Text YouWinLoose;
	public Text YourScore;
	public Text DiffrenceHiScore;
	public Text CountDown;


	public float ScoreCount;
	public float LevelNumber;
	public float CountDownTime;
	public int LastTail;

	public string LevelHighScore;

	public Global Global;

	public AudioSource EatSound;
	public AudioSource YouWin;
	public AudioSource YouLoose;
	public AudioSource BackgroundMusic;

	public Transform BorderTop;
	public Transform BorderBottom;
	public Transform BorderLeft;
	public Transform BorderRight;

	public bool Loading;

	// Did the snake eat something?
	bool ate = false;
	


	// Current Movement Direction
	// (by default it moves to the right)
	Vector2 dir = Vector2.right;
	
	// Keep Track of Tail
	List<Transform> tail = new List<Transform>();
	
	// Use this for initialization
	void Start () {
		BackgroundMusic.volume = 0;
		LoadingScreen.SetActive (false);
		EndGsme.SetActive (false);

		if (PlayerPrefs.GetInt ("ControlSetup") == 0) {
			RightControlsGameObject.SetActive (false);
			SplitControlsGameObject.SetActive (true);
			AlternatingControlsGameObject.SetActive (false);
		}
		else if(PlayerPrefs.GetInt ("ControlSetup") == 1){
			RightControlsGameObject.SetActive (true);
			SplitControlsGameObject.SetActive (false);
			AlternatingControlsGameObject.SetActive (false);
		}
		else if(PlayerPrefs.GetInt ("ControlSetup") == 2){
			RightControlsGameObject.SetActive (false);
			SplitControlsGameObject.SetActive (false);
			AlternatingControlsGameObject.SetActive (true);
		}


		GameMusic.volume = PlayerPrefs.GetFloat ("MusicVolume");
		EffectVolume.volume = PlayerPrefs.GetFloat ("EffectVolume");
		AtomCoinPickup.volume = PlayerPrefs.GetFloat("EffectVolume");



		HeadColourBlue.SetActive (false);
		HeadColourRed.SetActive (false);
		HeadColourPurple.SetActive (false);
		HeadColourGold.SetActive (false);
		HeadColourRainbow.SetActive (false);


			
		InvokeRepeating("Move", 4.1f, 0.2f); 
		InvokeRepeating ("AtomCoinSpawn", 8f, 5f);

		ScoreCount = 0;

		LevelHighScore = "HiScore" + LevelNumber;

		HiScoreText.text = "Hi-Score: " + PlayerPrefs.GetInt (LevelHighScore);

		//Blue Snake
		if (PlayerPrefs.GetString ("Theme") == "Blue") {
			CurrentTailPrefab = BlueTailPrefab;
			HeadColourBlue.SetActive (true);
		}
		//Red Snake
		else if (PlayerPrefs.GetString ("Theme") == "Red"){
			HeadColourRed.SetActive (true);
			CurrentTailPrefab = RedTailPrefab;
		}
		//Gold Snake
		else if (PlayerPrefs.GetString ("Theme") == "Gold"){
			HeadColourGold.SetActive (true);
			CurrentTailPrefab = GoldTailPrefab;
		}
		//Purple Snake
		else if (PlayerPrefs.GetString ("Theme") == "Purple"){
			HeadColourPurple.SetActive (true);
			CurrentTailPrefab = PurpleTailPrefab;
		}
		else if (PlayerPrefs.GetString ("Theme") == "Rainbow"){
			HeadColourRainbow.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Loading)
			LoadingScreen.SetActive (true);


		CountDownTime += Time.deltaTime;

		if (CountDownTime >= 1f) {
			CountDown.text = "3";
			if (CountDownTime >= 2f)
				CountDown.text = "2";
			if (CountDownTime >= 3f)
				CountDown.text = "1";
			if (CountDownTime >= 4f) 
				CountDown.text = "";
		}
		
		// Move the Snake every 300ms
		 

		Score.text = "score: " + ScoreCount;


			// Move in a new Direction?
			if (Input.GetKey (KeyCode.RightArrow) && !(dir == -Vector2.right))
				dir = Vector2.right;
			else if (Input.GetKey (KeyCode.DownArrow) && !(dir == Vector2.up))
				dir = -Vector2.up;    // '-up' means 'down'
		else if (Input.GetKey (KeyCode.LeftArrow) && !(dir == Vector2.right))
				dir = -Vector2.right; // '-right' means 'left'
		else if (Input.GetKey (KeyCode.UpArrow) && !(dir == -Vector2.up))
				dir = Vector2.up; 
		
	}
	public void DownButtom (){
		if (Global.RunTime > 0) {
			if (!(dir == Vector2.up)) {
				dir = -Vector2.up;

			}
		}
	}
	public void UpButtom (){
		if (Global.RunTime > 0) {
			if (!(dir == -Vector2.up)) {
				dir = Vector2.up;

			}
		}
	}
	public void LeftButtom (){
		if (Global.RunTime > 0) {
			if (!(dir == Vector2.right)) {
				dir = -Vector2.right;

			}
			}

	}
	public void RightButtom (){
		if (Global.RunTime > 0) {
			if (!(dir == -Vector2.right)) {
				dir = Vector2.right;

			}
		}
	}

	void Move(){
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Move head into new direction
		if (Global.RunTime > 0){
			transform.Translate (dir);

		// Ate something? Then insert new Element into gap
		if (ate) {
			// Load tail
			GameObject g = (GameObject)Instantiate (CurrentTailPrefab, v, Quaternion.identity);
				
			// Keep track of it in our tail list
			tail.Insert (0, g.transform);
				
			// Reset the bool
			ate = false;
		}

		// Do we have a Tail?
		if (tail.Count > 0) {
			// Move last Tail Element to where the Head was
			tail.Last ().position = v;
				
			// Add to front of list, remove from the back
			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count - 1);
		}
	}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		// Food?
		if (coll.name.StartsWith ("FoodPrefab")) {
			// Get longer in next Move call
			ate = true;
			EatSound.Play ();
			// Remove the Food
			Destroy (coll.gameObject);

			if (PlayerPrefs.GetString ("Theme") == "Rainbow"){
				
				
				
				int rand = Random.Range (0, 4);
				do {
					rand = Random.Range (0, 3);
					
					if ( rand == 0)
						CurrentTailPrefab = PurpleTailPrefab;
					else if (rand == 1)
						CurrentTailPrefab = GoldTailPrefab;
					else if (rand == 2)
						CurrentTailPrefab = RedTailPrefab;
					else if (rand == 3)
						CurrentTailPrefab = BlueTailPrefab;

				} while (LastTail == rand);

				LastTail = rand;
			}

			ScoreCount ++;
		} else if (coll.name.StartsWith ("AtomCoin")) {
			Destroy (coll.gameObject);
			AtomCoinPickup.Play ();
			int AC = PlayerPrefs.GetInt ("AtomCoin");
			AC ++;
			PlayerPrefs.SetInt ("AtomCoin", AC);
		}
		// Collided with Tail or Border
		else {
			// TODO new hjigh score screen
			Global.RunTime = 0;
			EndGsme.SetActive (true);
			YourScore.text = "Score: " + ScoreCount;

			int hs = PlayerPrefs.GetInt (LevelHighScore);

			if (ScoreCount >= hs){
				PlayerPrefs.SetInt (LevelHighScore,(int) ScoreCount);
				YouWin.Play ();
				BackgroundMusic.Pause ();
				YouWinLoose.text = "well done, new Hi-Score";
				DiffrenceHiScore.text = "";
			}
			else{
				YouLoose.Play ();
				BackgroundMusic.Pause ();
				YouWinLoose.text = "Better luck next time";
				DiffrenceHiScore.text = "So close, only " + (hs - ScoreCount) + " off the high score";
			}

		}
	}
	void AtomCoinSpawn (){
		if (Global.RunTime > 0) {
			int x = (int)Random.Range (BorderLeft.position.x, BorderRight.position.x);
			
			// y position between top & bottom border
			int y = (int)Random.Range (BorderBottom.position.y, BorderTop.position.y);
			
			if ((Random.Range (0, 100)) >= 50){
				Instantiate (AtomCoin, new Vector2 (x, y), Quaternion.identity);

			}
			//TODO add timer 

		}
	}

}
