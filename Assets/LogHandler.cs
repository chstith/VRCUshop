using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogHandler : MonoBehaviour {

	public Canvas InstructionCanvas;

	public Text theText;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider myTrigger) {
		string obj_name = myTrigger.gameObject.name;
		Debug.Log ("player hit "+myTrigger.gameObject.name);
		if (obj_name == "EndPoint") {
			Debug.Log ("hit EndPoint");


			//InstructionCanvas.enabled = true;

			InstructionCanvas.gameObject.SetActive(true);

			theText.text = "The experiment has ended!";

			//Text mytext = (Text) InstructionCanvas.GetComponent<Text>();

			//mytext.text = "The experiment has ended!";

			//exp_done=true;
			StartCoroutine (StreamReadWrite.UserPathLog.UploadLog(Initializer.user_id));
		}
	}
}
