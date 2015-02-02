using UnityEngine;
using System.Collections;

public class navigateResult : MonoBehaviour {

	public Canvas currentCanvas;
	public Canvas nextCanvas;

	public void showResults()
	{
		currentCanvas.gameObject.SetActive (false);
		nextCanvas.gameObject.SetActive (true);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
