using UnityEngine;
using System.Collections;

public class ToggleActive : MonoBehaviour {
	GameObject obj1;
	GameObject obj2;

	GameObject[] objset1;
	GameObject[] objset2;

	bool show1;
	bool show2;

	public string categoryURL = "http://sonoco-server.clemson.edu/get_exp.php?exp_id=2";

	// Use this for initialization
	void Start () {
		StartCoroutine(GetData());
		show1 = true;
		show2 = !show1;
		objset1 = GameObject.FindGameObjectsWithTag("wheaties");
		objset2 = GameObject.FindGameObjectsWithTag("wheaties_ali");
		//obj1 = GameObject.Find ("wheaties");
		//obj2 = GameObject.Find ("wheaties_ali");
		foreach (GameObject obj in objset1) { 
			obj.SetActive (show1);
		}
		foreach (GameObject obj in objset2) { 
			obj.SetActive (show2);
		}
	}
	
	IEnumerator GetData()
	{
		
		WWW cat_get = new WWW(categoryURL);
		yield return cat_get;
		
		if (cat_get.error != null)
		{
			print("There was an error getting the data: " + cat_get.error);
		}
		else
		{
			string s = cat_get.text;
			
			int index = s.IndexOf("$%^");
			
			//GetComponent<Text> ().text = s.Substring(index+3);//, s.Length);
			
			s = s.Substring(index+3);
			Debug.Log(s);
			//GetComponent<Text> ().text = s;
			
			
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown("2"))
		{
			Debug.Log("Toggle Visibility of Test Objects");
			show1 = !show1;
			show2 = !show2;
			foreach (GameObject obj in objset1) { 
				obj.SetActive (show1);
			}
			foreach (GameObject obj in objset2) { 
				obj.SetActive (show2);
			};
		}
	}
}
