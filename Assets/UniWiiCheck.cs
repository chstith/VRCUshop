using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class UniWiiCheck : MonoBehaviour {
	
	[DllImport ("UniWii")]
	private static extern void wiimote_start();
	
	[DllImport ("UniWii")]
	private static extern void wiimote_stop();
	
	[DllImport ("UniWii")]
	private static extern int wiimote_count();

	public Canvas InstructionCanvas;

	private String display;

	public static bool WiimoteConnected;
	public static bool InstructionsShown;

	void OnGUI() {
		int c = wiimote_count();
		if (c>0) {
			display = "";
			for (int i=0; i<=c-1; i++) {
				display += "Wiimote " + i + " found!\n";
				display += "Experiment ID: " + Initializer.exp_id + "\n";
				display += "User ID: " + Initializer.user_id + "\n";
				WiimoteConnected = true;
			}
		}
		else display = "Press the '1' and '2' buttons on your Wii Remote.";
		
		GUI.Label( new Rect(10,Screen.height-100, 500, 100), display);
	}
	
	void Start ()
	{
		wiimote_start();
		InstructionsShown = false;
	}
	
	void OnApplicationQuit() {
		wiimote_stop();
	}
	
}