using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiScores : MonoBehaviour {

	/// <summary>
	/// The number of levels.
	/// </summary>
	public int LevelNumber;


	/// <summary>
	/// The hi score text.
	/// </summary>
	public Text HiScoreText;

	// Use this for initialization
	void Start () {
		//This is to work out the number of levls without inclusing the main menu
		LevelNumber = Application.levelCount - 1;
		//TODO grid using this number
		//TODO get all the hi scores for each level
		//TODO adjust the grid to fit the difffrent sizes for when more levels are added

	}
	
	// Update is called once per frame
	void Update () {
		HiScoreText.text = "" + LevelNumber;
	}
}
