using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

public static class Loaders {

	/// <summary>
	/// Loads the level.
	/// </summary>
	/// <param name="json">Level JSON.</param>
	public static void LoadLevel(Level level) {
		// Load game scene
		Application.LoadLevel (Constants.SCENE_GAME_NAME);
		
		Global.LOADED_LEVEL = level;
		// This method continues at Game.OnLevelWasLoaded()
	}

	/// <summary>
	/// Gets the levels.
	/// </summary>
	/// <returns>The levels.</returns>
	public static List<Level> GetLevels(string path) {
		var levels = new List<Level> ();

		var levels_paths = Directory.GetFiles (path, "*.json", SearchOption.AllDirectories);
		foreach (var level_path in levels_paths) {
			var level_meta_content = File.ReadAllText (level_path);
			levels.Add(JsonConvert.DeserializeObject<Level>(level_meta_content));
		}

		return levels;
	}

	/// <summary>
	/// Returns GameObject corresponding to element.
	/// </summary>
	/// <returns>The to game object.</returns>
	/// <param name="element">Element.</param>
	public static GameObject ElementToGameObject(Level.Element element) {
		var elementName = element.name;
		var elementModel = Global.LEVEL_ELEMENTS [elementName];
		var go = UnityEngine.Object.Instantiate (elementModel);
		var position = new Vector3(element.position.x, Constants.GRID_SIZE_X, element.position.z);
		var parentTransform = GameObject.Find(Constants.PLACED_ELEMENTS_OBJ_NAME).transform;
		go.name = element.name + " - " + new RandomStringGenerator ().GetRandomString (10);
		go.transform.position = position;
		go.transform.SetParent (parentTransform);
		return go;
	}
}
