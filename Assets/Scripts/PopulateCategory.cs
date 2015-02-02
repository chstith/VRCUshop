using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class PopulateCategory : MonoBehaviour {
	
	//public List<GameObject> myToggleGameObjects = new List<GameObject> ();

	public List<Toggle> myTogglesList = new List<Toggle> ();

	//string categoryURL = "http://localhost/retrieveCategory.php";
	string categoryURL = "http://sonoco-server.clemson.edu/retrieveCategory.php";

	public Toggle radioButton;


	public Canvas PreviousCanvas;

	public Canvas CurrentCanvas;

	public Canvas NextCanvas;

	public static string stringToBePassed;

	//public static string stringQueriedonThisPage;

	/*
	void onEnable()
	{
		Debug.Log("onenabled called");
		StartCoroutine(GetCategoryData());
	}*/


	/*
	public void Start()
	{
		StartCoroutine(GetCategoryData());
	}
	*/

	void OnEnable()
	{
		StartCoroutine(GetCategoryData());
	}
	
	public IEnumerator GetCategoryData()
	{
		WWW cat_get = new WWW(categoryURL);
		yield return cat_get;

		if (cat_get.error != null)
		{
			print("There was an error getting the high score: " + cat_get.error);
		}
		else
		{
			string s = cat_get.text;

			int index = s.IndexOf("$%^");

			s = s.Substring(index+3);

			string[] words = s.Split(':');

			for(int i=0; i<words.Length-1; i++)
			{
				Toggle mytoggle = (Toggle) Instantiate(radioButton, new Vector3(0,0,0),Quaternion.identity) ;
				mytoggle.transform.SetParent(transform);

				mytoggle.group = (ToggleGroup)GetComponent<ToggleGroup>();

				Text mytext = (Text) mytoggle.GetComponentInChildren<Text>() ;
				//Text mytext = (Text) mytoggle.GetComponent<Text>() ;

				mytext.text = words[i];

				mytoggle.transform.localPosition = new Vector3(-100,150-50*(i),0) ;

				myTogglesList.Add(mytoggle);
			}
		}
	}

	public void onCategoryNext()
	{

		foreach( Toggle currtgl in myTogglesList)
		{
				
			if(currtgl.isOn == true )
			{
				//Debug.Log(currtgl.GetComponentInChildren<Text>().text );
				stringToBePassed = currtgl.GetComponentInChildren<Text>().text ;
				break;
			}
		}

		Debug.Log (stringToBePassed);

		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		CurrentCanvas.gameObject.SetActive (false);
		NextCanvas.gameObject.SetActive (true);

		//CurrentCanvas.enabled = false;
		//NextCanvas.enabled = true;
	}

	public void onCategoryPrev()
	{	
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		CurrentCanvas.gameObject.SetActive (false);
		PreviousCanvas.gameObject.SetActive (true);
	}

}
