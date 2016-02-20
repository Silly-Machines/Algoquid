using UnityEngine;
using System.IO;

public class LoadLevelButton : MonoBehaviour {
	public Level level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick() {
		Loaders.LoadLevel (level);
	}
}
