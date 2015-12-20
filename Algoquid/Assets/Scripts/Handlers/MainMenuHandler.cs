using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;

public class MainMenuHandler : MonoBehaviour {
	public Text levelList;
	public Text chooseLevelBox;

	// Use this for initialization
	void Start () {
		firstLaunchActions ();
		populateLevelsList ();
		
		// Show persistent data path
		var format2 = "Launched {0}.\n" + // TODO: MEILEUR NOM
			"Persistent data path: {1}";
		var formattedText2 = String.Format (format2, Constants.GAME_NAME, Application.persistentDataPath);
		print (formattedText2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnLoadButtonClick () {
		//try {
			var level_id = int.Parse(chooseLevelBox.text) - 1;
			var level_meta_path = Global.LEVELS_PATHS[level_id];
			var level_meta_content = File.ReadAllText (level_meta_path);
			Loaders.LoadLevel (level_meta_content);
		/*}
		catch(Exception e) {
			Debug.LogError(e.Message);
		}*/
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

	public void populateLevelsList() {
		Loaders.GetLevels (out Global.LEVELS, out Global.LEVELS_SLUGS, out Global.LEVELS_PATHS);
		string levelListText = "";
		for (var i = 0; i < Global.LEVELS.Count; i++) {
			var index = i + 1;
			var slug = Global.LEVELS_SLUGS[i];
			var format = "{0} - {1}\n";
			var formattedText = string.Format (format, index, slug);
			levelListText += formattedText;
		}
		
		levelList.text = levelListText;
	}
}
