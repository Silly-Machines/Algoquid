﻿public class Constants {

	//
	// Game
	//
	public const string GAME_NAME = "Algoquid";

	//
	// Game scene
	//
	public const string SCENE_GAME_NAME = "Game";
	public const string CAMERA_OBJ_NAME = "Main Camera";
	public const string GRID_OBJ_NAME = "Grid";
	public const int GRID_SIZE_X = 100;
	public const int GRID_SIZE_Z = 100;

	//
	// HUD
	//
	public const string HUD_INFO_TEXT_NAME = "Information";
	public const string HUD_LEVEL_INFO_TEXT_NAME = "LevelInfo";

	//
	// Files
	//
	public const string DO_NOT_INITIALIZE_FILE_NAME = "doNotInitialize";
	public const string DEFAULT_RESOURCES_PATH = "DefaultResources";

	//
	// Elements
	//
	public static readonly string[,] LEVEL_ELEMENTS = new string[,] {
		{ "Rock", "Model: Rock" }
	};
	public const string PLACED_ELEMENTS_OBJ_NAME = "Placed";

	//
	// Levels
	//
	public const int LEVEL_GAME = 1;
	public const int LEVEL_START_MENU = 0;
	public const int LEVEL_CHOOSE_LEVEL = 2;
}
