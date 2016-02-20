using UnityEngine;
using System.Collections.Generic;

public class Global : MonoBehaviour {
	//
	// Levels
	//
	public static List<Level> LEVELS;
	public static string[] LEVELS_SLUGS;
	public static string[] LEVELS_PATHS;
	public static List<Pack> PACKS = new List<Pack>();

	//
	// Elements
	//
	public static Dictionary<string, GameObject> LEVEL_ELEMENTS;

	//
	// Game
	//
	public static Level LOADED_LEVEL;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
