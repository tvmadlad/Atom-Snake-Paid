using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public AudioSource BackgroundMusic;

	public GameObject LoadingScreen;

	public float RunTime;

	// Use this for initialization
	void Start () {
		RunTime = 1;


	}

	
	// Update is called once per frame
	void Update () {
	
	}
	public void MainMenuLink (){
		LoadingScreen.SetActive (true);
		Application.LoadLevel (0);
}
	public void RestartGame (){
		LoadingScreen.SetActive (true);
		Application.LoadLevel (1);
	}
	public void RestartLevel2 (){
		LoadingScreen.SetActive (true);
		Application.LoadLevel (2);
	}
	public void RestartLevel3 (){
		LoadingScreen.SetActive (true);
		Application.LoadLevel (3);
	}
}
	