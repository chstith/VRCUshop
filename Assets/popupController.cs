using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class popupController : MonoBehaviour {

	public Text labelText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onOk()
	{

		transform.gameObject.SetActive(false);
	}
}
