using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

public class Game : MonoBehaviour {
	public GameObject grid;
	public Camera sceneCamera;
	public GridOverlay gridOverlay;

	void Start () {
		// Apply grid size
		applyGridSize (Constants.GRID_SIZE_X, Constants.GRID_SIZE_Z, grid, gridOverlay, sceneCamera);
	}

	void OnLevelWasLoaded () {
		var level_meta = Global.LOADED_LEVEL;

		//
		// Apply level meta
		//

		// Load level elements
		Global.LEVEL_ELEMENTS = new Dictionary<string, GameObject> ();
		for(var i = 0; i < Constants.LEVEL_ELEMENTS.Length / 2; i++)
			Global.LEVEL_ELEMENTS.Add (
				Constants.LEVEL_ELEMENTS [i, 0],
				GameObject.Find (Constants.LEVEL_ELEMENTS [i, 1])
				);

		// Show level text
		var format = "{0}\n" +
			"par {1}\n" +
			"Difficulté : {2}";
		var formattedText = String.Format (format, level_meta.name, level_meta.author, level_meta.difficulty);
		var levelInfoText = GameObject.Find (Constants.HUD_LEVEL_INFO_TEXT_NAME);
		levelInfoText.GetComponent<Text> ().text = formattedText;

		// Add level elements
		foreach (var element in level_meta.elements)
			Loaders.ElementToGameObject (element);
	}

	void Update () {

	}

	/// <summary>
	/// Applies a size to a grid.
	/// </summary
	/// <param name="x">X size.</param>
	/// <param name="z">Z size.</param>
	/// <param name="grid">Grid.</param>
	/// <param name="gridOverlay">Grid overlay.</param>
	public void applyGridSize(float x, float z, GameObject grid, GridOverlay gridOverlay, Camera camera) {
		// Apply plane size and position
		var newScale = new Vector3 (x, 1.0f, z);
		var newPos_x = x * 5.0f;
		var newPos_z = z * 5.0f;
		var newPos = new Vector3 (newPos_x, 0f, newPos_z);
		grid.transform.localScale = newScale;
		grid.transform.position = newPos;

		// Apply grid parameters
		gridOverlay.gridSizeX = x * 10f;
		gridOverlay.gridSizeY = 0f;
		gridOverlay.gridSizeZ = z * 10f;
		gridOverlay.smallStep = 0;
		gridOverlay.largeStep = x;

		// TODO: Apply camera parameters
		// camera.orthographicSize = newPos_x;
	}


}
