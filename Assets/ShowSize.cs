using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShowSize : MonoBehaviour {
	//var this.gameObject obj;


	// Use this for initialization
	void Start () {
		float x = this.gameObject.GetComponent<Renderer>().bounds.size.x;
		float y = this.gameObject.GetComponent<Renderer>().bounds.size.y;
		float z = this.gameObject.GetComponent<Renderer>().bounds.size.z;
		Debug.Log (x, gameObject);
		Debug.Log (y, gameObject);
		Debug.Log (z, gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
