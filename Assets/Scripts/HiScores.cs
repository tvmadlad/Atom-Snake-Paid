using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiScores : MonoBehaviour {

	/// <summary>
	/// The level number.
	/// </summary>
	public int LevelNumber;

	/// <summary>
	/// The aera of the container
	/// </summary>
	public RectTransform Cont;

	// Use this for initialization
	void Start () {
		//This is to work out the number of levls without inclusing the main menu
		LevelNumber = Application.levelCount - 1;
		//TODO grid using this number
		//TODO get all the hi scores for each level
		//TODO adjust the grid to fit the difffrent sizes for when more levels are added

		GameObject template = Resources.Load ("HiScore") as GameObject;

		int rows = 2;
		int cols = 2;

		float width = Cont.rect.width / (float)cols;
		float hight = Cont.rect.height / (float)rows;


		for (int i = 0; i < LevelNumber; i++) {
			GameObject g = Instantiate (template);
			g.transform.SetParent (Cont.transform);
			HiScorePannel hs = g.GetComponent <HiScorePannel>();
			hs.LevelNumber = i + 1;
			hs.Init();

			RectTransform trans = g.GetComponent <RectTransform>();
			trans.localScale = new Vector3 (1, 1, 1);

			int col = i % cols;
			int row = i / rows;

			trans.anchoredPosition = new Vector2 (col * width, -row * hight);


		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
