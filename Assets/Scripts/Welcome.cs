using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Welcome : MonoBehaviour {

	public static string experimentID;

	public static string experimentName;

	public static string experimentDesc;

	public Canvas CurrentCanvas;
	
	public Canvas NextCanvas;

	public InputField name;

	public InputField desc;

	public Text expID;


	//string getURL = "http://localhost/getMaxStoredID.php";
	string getURL = "http://sonoco-server.clemson.edu/getMaxStoredID.php";

	public void Start()
	{
		StartCoroutine (GetMaxStoredID ());
	}


	public IEnumerator GetMaxStoredID()
	{
		WWW cat_get = new WWW(getURL);
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

			experimentID = (int.Parse( words[0]) + 1).ToString();

			expID.text = experimentID;
		}
	}

	public void onIDSubmit()
	{
		//InputField myField = (InputField) gameObject.GetComponentInChildren<InputField> ();
		/*
		experimentID = myField.text.text;
		Debug.Log (experimentID);
		*/

		experimentName = name.text.text;

		experimentDesc = desc.text.text;

		Debug.Log ("Name: "+ experimentName+ " Desc: "+ experimentDesc);

		CurrentCanvas.gameObject.SetActive (false);
		NextCanvas.gameObject.SetActive (true);
	}
}
