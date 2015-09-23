using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public AudioSource BackgroundMusic;




	public float RunTime;

	// Use this for initialization
	void Start () {
		RunTime = 1;


	}

	
	// Update is called once per frame
	void Update () {
	
	}
	public void MainMenuLink (){
		Application.LoadLevel (0);
}
	public void RestartGame (){
		Application.LoadLevel (1);
	}
	public void RestartLevel2 (){
		Application.LoadLevel (2);
	}
	public void RestartLevel3 (){
		Application.LoadLevel (3);
	}
}
	