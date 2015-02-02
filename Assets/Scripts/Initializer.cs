using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Initializer : MonoBehaviour {
	public static int exp_id = int.Parse(changeScenes.ExperimentID);
	public static string user_id;
	public string createUserURL = "sonoco-server.clemson.edu/createuser.php?"; //be sure to add a ? to your url


	public string getShoppinListCategoriesURL = "sonoco-server.clemson.edu/getShoppingListCategories.php?";

	public static List<string> shoppinglistcategories = new List<string> ();

	// Use this for initialization
	void Start () {
		Debug.Log ("starting initializer");
		StartCoroutine(createUserId());

		StartCoroutine (getshopinglistcategories());
	}

	IEnumerator getshopinglistcategories() 
	{
		Debug.Log ("Began!!!!!!");

		getShoppinListCategoriesURL = "sonoco-server.clemson.edu/getShoppingListCategories.php?" +  "experimentID=" + changeScenes.ExperimentID;
		
		Debug.Log ("here: " + getShoppinListCategoriesURL);
		
		WWW hs_post = new WWW(getShoppinListCategoriesURL);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null) 
		{
			print ("There was an error posting the high score: " + hs_post.error);
		} 
		else
		{
			Debug.Log("Got here!!!!!!!!!!!!!!!!!!!!!");

			string s = hs_post.text;
			
			int index = s.IndexOf("$%^");
			
			s = s.Substring(index+3);
			
			string[] words = s.Split(':');

			for(int i=0; i<words.Length-1; i++)
			{
				shoppinglistcategories.Add(words[i]);
			}

			Debug.Log("Category count is: " + shoppinglistcategories.Count);
		}
	}

	IEnumerator createUserId() {
		string user_url = createUserURL + "exp=" + exp_id;
		Debug.Log (user_url);
		WWW user_get = new WWW(user_url);
		yield return user_get;
		
		if (user_get.error != null){
			print("There was an error getting the user_id: " + user_get.error);
		}
		else {
			user_id = user_get.text; // this is a GUIText that will display the scores in game.
			Debug.Log ("user id: "+user_id);
			StreamReadWrite.UserPathLog.logfilename = "CameraLog"+Initializer.user_id+".txt";
		}
	}
	
	// Update is called once per frame
	//void Update () {
	
	//}
}
