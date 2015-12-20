using UnityEngine;
using System.Collections;

public class Quid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		var info = "----- [Quid] -----\n" +
			"description ici";
		HUDHandler.showInfo (info);
	}
	
	void OnMouseExit () {
		HUDHandler.showInfo (null);
	}
}
