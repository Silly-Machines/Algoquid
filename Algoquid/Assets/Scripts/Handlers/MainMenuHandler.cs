using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class MainMenuHandler : MonoBehaviour {
	public Text levelList;

	// Use this for initialization
	void Start () {
		
		// Show persistent data path
		var format = "Launched {0}.\n" +
			"Persistent data path: {1}";
		var formattedText = String.Format (format, Constants.GAME_NAME, Application.persistentDataPath);
		Debug.Log (formattedText);
		
		firstLaunchActions ();
		populatePacksList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// First launch actions.
	/// </summary>
	public void firstLaunchActions() {
		var doNotInitializeFile = Application.persistentDataPath + "//" + Constants.DO_NOT_INITIALIZE_FILE_NAME;
		
		if(!File.Exists (doNotInitializeFile)) {
			// Copy zip in temp path
			var zipPath = Application.streamingAssetsPath + "//DefaultResources.zip";

			// Unzip default resources
			CompressionTools.unzip (zipPath, Application.persistentDataPath);

			print ("Unzipped default resources.");
		}
	}

	/// <summary>
	/// Populates the packs list.
	/// </summary>
	public void populatePacksList() {
		Global.PACKS.Clear ();
		var packs_dir = Application.persistentDataPath + "//levels";
		var packs_paths = Directory.GetFiles (packs_dir, "pack.info", SearchOption.AllDirectories);
		
		foreach (var path in packs_paths) {
			var pack = JsonConvert.DeserializeObject<Pack>(File.ReadAllText (path));
			pack.path = path.Replace ("pack.info", "");
			Global.PACKS.Add (pack);
		}
		
		var packsNumberText = GameObject.Find ("PacksNumber").GetComponent<Text> ();
		packsNumberText.text = "1/" + Global.PACKS.Count;
		loadPackInfo (Global.PACKS [0]);
		
		var scrollbar = GameObject.Find ("Scrollbar").GetComponent<Scrollbar> ();
		scrollbar.value = 0f;
		scrollbar.size = 1f / Global.PACKS.Count;
		scrollbar.numberOfSteps = Global.PACKS.Count;
	}

	public void populateLevelsList(Pack pack) {
		var model = GameObject.Find ("LevelButton");
		var scrollRect = GameObject.Find ("LevelButtons");
		scrollRect.GetComponent<RectTransform> ().sizeDelta = new Vector2 (204f, 0f);
		var levels = Loaders.GetLevels (pack.path);
		var lastPosY = 110.25f;
		var i = 0;

		foreach (var obj in scrollRect.GetComponentsInChildren<LoadLevelButton>()) {
			Destroy (obj.gameObject);
		}

		foreach(var level in levels) {
			i++;

			var button = Instantiate (model);
			button.transform.SetParent (scrollRect.transform);
			button.GetComponentsInChildren<Text>()[0].text = string.Format ("{0}. {1}", i, level.name);
			button.GetComponent<LoadLevelButton>().level = level;
			button.name = "LoadLevel:" + level.name;

			if(i % 2 == 0) {
				var color = new Color(0.89F, 0.89F, 0.89F, 1);
				button.GetComponent<Image>().color = color;
			}
			var newPos = new Vector3(-5.0f, lastPosY, 0.0f);
			button.transform.localPosition = newPos;
			scrollRect.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, scrollRect.GetComponent<RectTransform>().sizeDelta.y + Convert.ToInt32(lastPosY));
			lastPosY -= 30f;
		}
	}

	void loadPackInfo(Pack pack) {
		var nameText = GameObject.Find ("PackInfo_Name_Value").GetComponent<Text> ();
		var authorText = GameObject.Find ("PackInfo_Author_Value").GetComponent<Text> ();
		var difficultyText = GameObject.Find ("PackInfo_Difficulty_Value").GetComponent<Text> ();
		var descriptionText = GameObject.Find ("PackInfo_Description_Value").GetComponent<Text> ();

		nameText.text = pack.name;
		authorText.text = pack.author;
		difficultyText.text = pack.difficulty;
		descriptionText.text = pack.description;

		populateLevelsList (pack);
	}

	public void updatePackInfo() {
		// TODO: ugly code
		var scrollbar = GameObject.Find ("Scrollbar").GetComponent<Scrollbar> ();
		int value = Convert.ToInt32 (Math.Round (scrollbar.value * Global.PACKS.Count));

		var packsNumberText = GameObject.Find ("PacksNumber").GetComponent<Text> ();

		if (value == 0) {
			packsNumberText.text = "1/" + Global.PACKS.Count;
		} else {
			packsNumberText.text = value + "/" + Global.PACKS.Count;
		}

		if (value > 0) {
			value -= 1;
		}
		loadPackInfo (Global.PACKS [value]);
	}

	public void returnToMainMenu() {
		Application.LoadLevel (Constants.LEVEL_START_MENU);
	}
}
