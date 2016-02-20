using UnityEngine;
using System.Collections;

public class StartMenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartButton () {
		Application.LoadLevel (Constants.LEVEL_CHOOSE_LEVEL);
	}

	public void SettingsButton () {

	}

	public void HelpButton () {
		
	}

	public void ExitButton () {
		Application.Quit ();
	}
}
