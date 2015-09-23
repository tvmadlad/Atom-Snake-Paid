using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MenuGlobal : MonoBehaviour {
	public Text AtomCoinCount;
	public Text Level2Button;
	public Text RedBuyButton;
	public Text PurpleBuyButton;
	public Text RedCostTetx;
	public Text GoldBuyButton;
	public Text GoldCostText;
	public Text PurpleCostText;


	public Image BlueTick;
	public Image RedTick;
	public Image GoldTick;
	public Image PurpleTick;
	public Image RainbowTick;

	public AudioSource MusicVolume;
	public AudioSource EffectVolume;

	public Slider MusicVolumeSlider;
	public Slider EffectVolumeSlider;
	public Slider ControlSetup;

	public GameObject PlayMenu;
	public GameObject StoreMenu;
	public GameObject SettingsMenu;
	public GameObject LevelStorePage;
	public GameObject ThemeStorePage;
	public GameObject CoinStorePage;
	public GameObject LoadingScreen;

	public bool IsSettingsOpen;


	// Use this for initialization
	void Start () {
		PlayMenu.SetActive (false);
		StoreMenu.SetActive (false);
		SettingsMenu.SetActive (false);
		LevelStorePage.SetActive (true);
		ThemeStorePage.SetActive (false);
		CoinStorePage.SetActive (false);
		LoadingScreen.SetActive (false);
		BlueTick.gameObject.SetActive (false);
		RedTick.gameObject.SetActive (false);
		GoldTick.gameObject.SetActive (false);
		PurpleTick.gameObject.SetActive (false);
		RainbowTick.gameObject.SetActive (false);
		//PlayerPrefs.SetInt ("AtomCoin", 0);
		//PlayerPrefs.SetInt ("firstLaunch", 0);

		bool firstLaunch = (PlayerPrefs.GetInt ("firstLaunch") == 0);
		if (firstLaunch) {
			PlayerPrefs.SetInt ("firstLaunch", 1);
			PlayerPrefs.SetString ("Theme", "Blue");
			PlayerPrefs.SetInt ("AtomCoin", 100);
			PlayerPrefs.SetInt("Red", 0);
			PlayerPrefs.SetInt("Gold", 0);
			PlayerPrefs.SetInt("Purple", 0);
			PlayerPrefs.SetString("level2", "");
			PlayerPrefs.SetString ("level2", "");

		}



	}

	// Update is called once per frame
	void Update () {
			if (Application.isLoadingLevel) 
			LoadingScreen.SetActive (true);

		


		int AC = PlayerPrefs.GetInt ("AtomCoin");
		AtomCoinCount.text = "Atom Coins: " + AC;


		EffectVolume.volume = EffectVolumeSlider.value;

		if (IsSettingsOpen)
			MusicVolume.volume = MusicVolumeSlider.value;
		else
			MusicVolume.volume = PlayerPrefs.GetFloat ("MusicVolume");


		if (PlayerPrefs.GetString ("level2") == "true")
			Level2Button.text = "play";
		else
			Level2Button.text = "shop";

		if (StoreMenu.activeSelf) {
			BlueTick.gameObject.SetActive (false);
			RedTick.gameObject.SetActive (false);
			GoldTick.gameObject.SetActive (false);
			PurpleTick.gameObject.SetActive (false);
			RainbowTick.gameObject.SetActive (false);
			
			if (PlayerPrefs.GetString ("Theme") == "Rainbow")
				RainbowTick.gameObject.SetActive (true);
			if (PlayerPrefs.GetString ("Theme") == "Blue")
				BlueTick.gameObject.SetActive (true);
			if (PlayerPrefs.GetString ("Theme") == "Red")
				RedTick.gameObject.SetActive (true);
			if (PlayerPrefs.GetString ("Theme") == "Gold")
				GoldTick.gameObject.SetActive (true);
			if (PlayerPrefs.GetString ("Theme") == "Purple")
				PurpleTick.gameObject.SetActive (true);
		}
	}
	public void UnselectAllTicks (){
		return;
		BlueTick.gameObject.SetActive (false);
		RedTick.gameObject.SetActive (false);
		GoldTick.gameObject.SetActive (false);
		PurpleTick.gameObject.SetActive (false);
		RainbowTick.gameObject.SetActive (false);
			
	}



	public void BuyLevel2 (){

	if (PlayerPrefs.GetInt ("AtomCoin") >= 5) {
			if (PlayerPrefs.GetString ("level2") != "true"){
				PlayerPrefs.SetString ("level2", "true");
				int AC = PlayerPrefs.GetInt ("AtomCoin");
				PlayerPrefs.SetInt ("AtomCoin", (AC - 5));
		
			}}
	}
	public void BuyLevel3 (){
		if (PlayerPrefs.GetString ("level3") != "true"){
			if (PlayerPrefs.GetInt ("AtomCoin") >= 30) {
				
				PlayerPrefs.SetString ("level3", "true");
				int AC = PlayerPrefs.GetInt ("AtomCoin");
				PlayerPrefs.SetInt ("AtomCoin", (AC - 30));
		}
	}
	}




	public void OpenSettings (){
		SettingsMenu.SetActive (true);
		IsSettingsOpen = true;

		EffectVolumeSlider.value = PlayerPrefs.GetFloat ("EffectVolume");
		MusicVolumeSlider.value = PlayerPrefs.GetFloat ("MusicVolume");

		ControlSetup.value = PlayerPrefs.GetInt ("ControlSetup");
	}

	public void AcceptSettings (){
		SettingsMenu.SetActive (false);

		PlayerPrefs.SetFloat ("EffectVolume", EffectVolumeSlider.value);
		PlayerPrefs.SetFloat ("MusicVolume", MusicVolumeSlider.value);

		PlayerPrefs.SetInt ("ControlSetup", (int) ControlSetup.value);
	}
	public void StoreMenuOpen (){
		StoreMenu.SetActive (true);


		if (PlayerPrefs.GetInt ("Red") == 0) {
			RedBuyButton.text = "Buy";
			RedCostTetx.text = "5 Atom Coins";
		} else {
			RedBuyButton.text = "Set";
			RedCostTetx.text = "Already purchased";
		}
		
		if (PlayerPrefs.GetInt ("Gold") == 0) {
			GoldBuyButton.text = "Buy";
			GoldCostText.text = "50 Atom Coins";
		} else {
			GoldBuyButton.text = "Set";
			GoldCostText.text ="Already purchased";
		}
		if (PlayerPrefs.GetInt ("Purple") == 0) {
			PurpleBuyButton.text = "Buy";
			PurpleCostText.text = "25 Atom Coins";
		} else {
			PurpleBuyButton.text = "Set";
			PurpleCostText.text ="Already purchased";
		}
	}
	public void CloseStoreMenu (){
		StoreMenu.SetActive (false);
		IsSettingsOpen = false;
	}

	public void LoadBassicLevel(){

		Application.LoadLevel (1);
	}
	public void LoadSecondLevel (){
		if (PlayerPrefs.GetString ("level2") == "true")
			Application.LoadLevel (2);
		else{ 
			PlayMenu.SetActive (false);
			StoreMenu.SetActive (true);
		}
	}
	public void LoadThirdLevel (){
		if (PlayerPrefs.GetString ("level3") == "true")
			Application.LoadLevel (3);
		else{ 
			PlayMenu.SetActive (false);
			StoreMenu.SetActive (true);
		}
	}
	public void Website (){

		Application.OpenURL ("http://www.atomapps.co.uk/");
	}
	public void Settings(){

	
	}
	public void Exit (){

		Application.Quit ();
	}
	public void HideAllStorePages () {
		LevelStorePage.SetActive (false);
		ThemeStorePage.SetActive (false);
		CoinStorePage.SetActive (false);
	}
	public void OpenLevelStorePage () {
		LevelStorePage.SetActive (true);
	}
	public void OpenThemeStorePage () {
		ThemeStorePage.SetActive (true);
	}
	public void BuyRedTheme () {
		if (PlayerPrefs.GetInt ("Red") == 0) {
			if (PlayerPrefs.GetInt ("AtomCoin") >= 5) {
				RedBuyButton.text = "Set";
				int AC = PlayerPrefs.GetInt ("AtomCoin");
				PlayerPrefs.SetInt ("AtomCoin", (AC - 5));
				PlayerPrefs.SetInt ("Red", 1);
			}
		} else {
			PlayerPrefs.SetString ("Theme","Red");
		}
	}
	public void BuyGoldTheme () {
		if (PlayerPrefs.GetInt ("Gold") == 0) {
			if (PlayerPrefs.GetInt ("AtomCoin") >= 25) {
				GoldBuyButton.text = "Set";
				int AC = PlayerPrefs.GetInt ("AtomCoin");
				PlayerPrefs.SetInt ("AtomCoin", (AC - 25));
				PlayerPrefs.SetInt ("Gold", 1);			}
		} else {
			PlayerPrefs.SetString ("Theme", "Gold");
		}
	}
	public void ThemeBlue () {
		PlayerPrefs.SetString ("Theme","Blue");
	}
	public void ThemeRainbow () {
		PlayerPrefs.SetString ("Theme","Rainbow");
	}
	public void BuyPurpleTheme () {
		if (PlayerPrefs.GetInt ("Purple") == 0) {
			if (PlayerPrefs.GetInt ("AtomCoin") >= 15) {
				PurpleBuyButton.text = "Set";
				int AC = PlayerPrefs.GetInt ("AtomCoin");
				PlayerPrefs.SetInt ("AtomCoin", (AC - 15));
				PlayerPrefs.SetInt ("Purple", 1);			}
		} else {
			PlayerPrefs.SetString ("Theme", "Purple");
		}

	}
}
