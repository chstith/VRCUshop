using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
	[DllImport ("UniWii")]
	public static extern int wiimote_count();
	
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonB(int which);
	
	GameObject myObject;
	Canvas myCanvas;
	
	bool show;
	
	public int wiiCount;

	public Canvas InstructionCanvas;

	public float timeDelay = 0.333f;
	
	private float timestamp;
	
	// Use this for initialization
	void Start () {
		
		show = true;
		myObject = GameObject.Find ("CanvasHUD");
		myCanvas = myObject.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("h")) 
		{
			Debug.Log("Show shopping list.");
			
			show = !show;
			myCanvas.enabled = show;
		}
		
		if (Time.time >= timestamp && (wiimote_getButtonB (wiiCount)) ){
			Debug.Log("Show shopping list.");
			
			show = !show;
			myCanvas.enabled = show;
			timestamp = Time.time + timeDelay;
			
			UniWiiCheck.InstructionsShown = true;
			InstructionCanvas.gameObject.SetActive(false);

		}
	}
}
