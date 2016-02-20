using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
	public float fadeDuration = 1.0f;
	public GameObject text;
	
	private IEnumerator Start()
	{
		while (true) {
			yield return StartCoroutine (Fade_ (0.0f, 1.0f, fadeDuration));
			yield return StartCoroutine (Fade_ (1.0f, 0.0f, fadeDuration));
		}
	}
	
	private IEnumerator Fade_ (float startLevel, float endLevel, float time)
	{
		float speed = 1f;
		
		for (float t = 0.0f; t < 1.0; t += Time.deltaTime*speed)
		{
			float a = Mathf.Lerp(startLevel, endLevel, t);
			text.GetComponent<Text>().color = new Color(text.GetComponent<Text>().color.r,
			                                            text.GetComponent<Text>().color.g,
			                                            text.GetComponent<Text>().color.b, a);
			yield return 0;
		}
	}
}