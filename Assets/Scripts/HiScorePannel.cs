using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiScorePannel : MonoBehaviour {

	/// <summary>
	/// The name of the level.
	/// </summary>
	public Text LevelName;

	/// <summary>
	/// The hi score number.
	/// </summary>
	public Text HiScoreNumber;

	/// <summary>
	/// The level number.
	/// </summary>
	public int LevelNumber;


	// Use this for initialization
	public void Init() {

		LevelName.text = "Level " + LevelNumber;
	
		HiScoreNumber.text = "" + PlayerPrefs.GetInt ("HiScore" + LevelNumber);
	}

}
