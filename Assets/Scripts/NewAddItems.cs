using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewAddItems : MonoBehaviour {

	public InputField inp1;
	public InputField inp2;
	public InputField inp3;

	public InputField inp11;
	public InputField inp22;
	public InputField inp33;

	public Canvas PreviousCanvas;
	public Canvas CurrentCanvas;

	//string finalURL = "http://localhost/final.php?";
	string finalURL = "http://sonoco-server.clemson.edu/final.php?";

	/*
	// Use this for initialization
	void Start () {
		inp1.text.text = PopulateProducts.stringToBePassed;
	}
	*/

	void OnEnable()
	{
		inp1.text.text = PopulateProducts.stringToBePassed;
		inp11.text.text = PopulateCategory.stringToBePassed;
	}

	public void onAdBack()
	{
		CurrentCanvas.gameObject.SetActive (false);
		PreviousCanvas.gameObject.SetActive (true);
	}

	public void onFinish()
	{
		Debug.Log (inp1.text.text + " " + inp2.text.text + " " + inp3.text.text);
		//Application.Quit ();

		StartCoroutine(PostCategory());
	}

	IEnumerator PostCategory()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		
		string post_url = finalURL + "experimentID=" + Welcome.experimentID + "&item1=" + inp1.text.text + "&item2=" + inp2.text.text + "&item3=" + inp3.text.text;//PopulateCategory.stringToBePassed; //WWW.EscapeURL(PopulateCategory.stringToBePassed);

		post_url = post_url + "&category1=" + inp11.text.text + "&category2=" + inp22.text.text + "&category3=" + inp33.text.text;

		post_url = post_url + "&experimentName=" + Welcome.experimentName + "&experimentDesc=" + Welcome.experimentDesc;

		string modelsliststring = "";

		for(int k=0; k<PopulateModels.myModelsList.Count; k++)
		{
			if(k != PopulateModels.myModelsList.Count-1 )
			{
				modelsliststring = modelsliststring + PopulateModels.myModelsList[k] + ",";
			}
			else
			{
				modelsliststring = modelsliststring + PopulateModels.myModelsList[k] ;
			}
		}

		post_url = post_url + "&modelslist=" + modelsliststring;

		//post_url = WWW.EscapeURL (post_url);

		post_url = post_url.Replace(' ','+');

		Debug.Log (post_url);

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
		else
		{
			Debug.Log("Worked!!!");

			Debug.Log (hs_post.text);

			Application.LoadLevel("Menu");
		/*	
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
				*/
			}
			
		}
}

