using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayGameResults : MonoBehaviour {

	public Text[] GameResultText;
	public GameObject Panel;

	// Use this for initialization
	void Start () {
		Panel.SetActive (false);
	}

	public void ShowGameResult(bool won)
	{
		Panel.SetActive (true);
		foreach (Text t in GameResultText) 
		{
			t.text = won ? "Congratulations!\nYou Won!" : "You Lost! Try Again!";
		}
	}

	public void Reset()
	{
		Panel.SetActive (false);
		foreach (Text t in GameResultText) 
		{
			t.text = "";
		}
	}
}
