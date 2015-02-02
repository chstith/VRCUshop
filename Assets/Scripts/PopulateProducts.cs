using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopulateProducts : MonoBehaviour {

	//Debug.Log ( PopulateCategory.stringToBePassed );

	public List<Toggle> myTogglesList = new List<Toggle> ();
	
	//string productURL = "http://localhost/retrieveProduct.php?";
	string productURL = "http://sonoco-server.clemson.edu/retrieveProduct.php?";

	public Toggle radioButton;
	
	
	public Canvas PreviousCanvas;
	
	public Canvas CurrentCanvas;
	
	public Canvas NextCanvas;
	
	public static string stringToBePassed;
	
	public static string stringQueriedonThisPage;


	public void Start()
	{
		/*
		Debug.Log("Start in products called");

		stringQueriedonThisPage = PopulateCategory.stringToBePassed;

		StartCoroutine(PostCategory());
		*/
		//onEnable ();
	}

	void OnEnable()
	{
		Debug.Log("onenable in products called");
		
		stringQueriedonThisPage = PopulateCategory.stringToBePassed;
		
		StartCoroutine(PostCategory());
	}

	IEnumerator PostCategory()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		
		string post_url = productURL + "category=" + stringQueriedonThisPage;//PopulateCategory.stringToBePassed; //WWW.EscapeURL(PopulateCategory.stringToBePassed);

		Debug.Log ("URL for products: " + post_url);

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
		else
		{
			//Debug.Log (hs_post.text);

			string s = hs_post.text;

			int index = s.IndexOf("$%^");
			
			s = s.Substring(index+3);
			
			string[] words = s.Split(':');

			for(int i=0; i<words.Length-1; i++)
			{
				Toggle mytoggle = (Toggle) Instantiate(radioButton, new Vector3(0,0,0),Quaternion.identity) ;
				mytoggle.transform.SetParent(transform);
				
				mytoggle.group = (ToggleGroup)GetComponent<ToggleGroup>();
				
				Text mytext = (Text) mytoggle.GetComponentInChildren<Text>() ;

				mytext.text = words[i];
				
				mytoggle.transform.localPosition = new Vector3(-100,150-50*(i),0) ;

				myTogglesList.Add(mytoggle);
			}

		}
	}
	
	public void onProductNext()
	{
		
		foreach( Toggle currtgl in myTogglesList)
		{
			
			if(currtgl.isOn == true )
			{
				Debug.Log(currtgl.GetComponentInChildren<Text>().text );
				stringToBePassed = currtgl.GetComponentInChildren<Text>().text ;
				break;
			}
		}

		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}
		
		CurrentCanvas.gameObject.SetActive (false);
		NextCanvas.gameObject.SetActive (true);
	}

	public void onProductPrev()
	{
		/*
		foreach( Toggle currtgl in myTogglesList)
		{
			
			if(currtgl.isOn == true )
			{
				//Debug.Log(currtgl.GetComponentInChildren<Text>().text );
				stringToBePassed = currtgl.GetComponentInChildren<Text>().text ;
				break;
			}
		}*/

		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		CurrentCanvas.gameObject.SetActive (false);
		PreviousCanvas.gameObject.SetActive (true);
	}

}
