using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public static class Loaders {

	/// <summary>
	/// Loads the level.
	/// </summary>
	/// <param name="json">Level JSON.</param>
	public static void LoadLevel(string json) {
		// Load game scene
		Application.LoadLevel (Constants.SCENE_GAME_NAME);

		Global.LEVEL_JSON = json;
		// This method continues at Game.OnLevelWasLoaded()
	}

	/// <summary>
	/// Gets the levels.
	/// </summary>
	/// <returns>The levels.</returns>
	public static void GetLevels(out List<Level> levels, out string[] slugs, out string[] paths) {
		var _levels = new List<Level> ();
		var _slugs = new List<string> ();
		var _paths = new List<string> ();
		var packs_dir = Application.persistentDataPath + "//levels";

		var levels_paths = Directory.GetFiles (packs_dir, "*.json", SearchOption.AllDirectories);

		foreach (var level_path in levels_paths) {
			var level_meta_content = File.ReadAllText (level_path);
			var level_meta = JsonConvert.DeserializeObject<Level>(level_meta_content);
			var slug = level_path.Replace (packs_dir + "\\", "").Replace ("\\", "/").Replace (".json", "");

			_slugs.Add(slug);
			_levels.Add (level_meta);
			_paths.Add(level_path);
		}

		levels = _levels;
		slugs = _slugs.ToArray ();
		paths = _paths.ToArray ();
	}

}
