using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

	public  Toggle Toggle1;
	public  Toggle Toggle2;
	public  Toggle Toggle3;


	public static Toggle Toggle11;
	public static Toggle Toggle22;
	public static Toggle Toggle33;

	string shoppingListURL = "http://sonoco-server.clemson.edu/shoppingList.php?";

	// Use this for initialization
	void Start () {
		Toggle1.isOn = false;
		Toggle2.isOn = false;
		Toggle3.isOn = false;
		StartCoroutine(GetShoppingList());


		Toggle11 = Toggle1;
		Toggle22 = Toggle2;
		Toggle33 = Toggle3;
	}

	void update()
	{

	}

	public IEnumerator GetShoppingList()
	{
		string geturl = shoppingListURL + "exp=" + Initializer.exp_id;


		WWW cat_get = new WWW(geturl);
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
			

			Text mytext1 = Toggle1.GetComponentInChildren<Text>() ;
			Text mytext2 = Toggle2.GetComponentInChildren<Text>() ;
			Text mytext3 = Toggle3.GetComponentInChildren<Text>() ;


			mytext1.text = words[0];
			mytext2.text = words[1];
			mytext3.text = words[2];
				

		}
	}
}
