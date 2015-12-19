using UnityEngine;
using System;
using System.Collections;
using Newtonsoft.Json;

public class Game : MonoBehaviour {
	public GameObject grid;
	public Camera sceneCamera;
	public GridOverlay gridOverlay;

	void Start () {
		// Apply grid size
		applyGridSize (Constants.GRID_SIZE_X, Constants.GRID_SIZE_Z, grid, gridOverlay, sceneCamera);

		// Show persistent data path
		var format = "Launched {0}.\n" + 
			"Persistent data path: {1}";
		var formattedText = String.Format (format, Constants.GAME_NAME, Application.persistentDataPath);
		print (formattedText);
	}

	void OnLevelWasLoaded () {
		// Deserialize JSON
		var json = Global.LEVEL_JSON;
		var level_meta = JsonConvert.DeserializeObject<Level> (json);
		
		// Apply level meta
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

		// Apply camera parameters
		//camera.orthographicSize = newPos_x;
	}
}
