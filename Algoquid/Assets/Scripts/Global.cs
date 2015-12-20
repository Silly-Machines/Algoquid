using UnityEngine;
using System.Collections.Generic;

public class Global : MonoBehaviour {
	//
	// Levels
	//
	public static List<Level> LEVELS;
	public static string[] LEVELS_SLUGS;
	public static string[] LEVELS_PATHS;

	//
	// Elements
	//
	public static Dictionary<string, dynamic> LEVEL_ELEMENTS;

	//
	// Game
	//
	public static string LEVEL_JSON;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
