using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PackageArray : MonoBehaviour {
	public int i = 2;
	public int j = 3;
	public GameObject obj;

	// Use this for initialization

	void Start () {

		for (i = 0; i < 10; i++) {
			for (j = 0; j < 10; j++) {
				Debug.Log(i, obj); //Instantiate(obj, Vector3(i, 0, j), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
