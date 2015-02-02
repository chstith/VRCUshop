using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionController : MonoBehaviour {

	GameObject myObject;
	Canvas myCanvas;
	
	public Text mytext;
	bool shown = false;

	// Use this for initialization
	void Start () {
		mytext.text = "Press 1 & 2 to connect WiiMote.";
		myObject = GameObject.Find ("CanvasInstructions");
		myCanvas = myObject.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((UniWiiCheck.WiimoteConnected == true) && (shown == false)) {
			mytext.text = "Use Directional pad to move where you are looking.\nUse trigger to toggle shopping list.\nPress trigger now to begin the experiment.";
			shown = true;
		}
		//if (UniWiiCheck.InstructionsShown == true) {
			// Hide HUD for Instructions once used.
		//	myCanvas.enabled = false;	
		//}

	}
}
