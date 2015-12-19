using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public static class HUDHandler {
	static GameObject infoText;
	static Text velocityText, positionText;
	static Vector3 infoText_Position;

	public static void showInfo(string info) {
		infoText = GameObject.Find (Constants.HUD_INFO_TEXT_NAME);
		infoText_Position = Input.mousePosition;
		infoText_Position.x += 125;
		infoText.transform.position = infoText_Position;
		infoText.GetComponent<Text> ().text = info;
	}
}
