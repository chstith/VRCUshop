using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopulateModels : MonoBehaviour {

	//public List<Toggle> myTogglesList = new List<Toggle> ();
	public List<GameObject> myPrefabList = new List<GameObject> ();

	public static List<string> myModelsList = new List<string> ();

	//string modelURL = "http://localhost/retrieveModel.php?";
	string modelURL = "http://sonoco-server.clemson.edu/retrieveModel.php?";

	//public Toggle radioButton;
	public GameObject myPrefab;

	public Canvas PreviousCanvas;
	
	public Canvas CurrentCanvas;
	
	public Canvas NextCanvas;
	
	public static string stringToBePassed;
	
	public static string stringQueriedonThisPage;


	void OnEnable()
	{
		//Debug.Log("OnEnable in populatemoidels called");
		//Start ();
		stringQueriedonThisPage = PopulateProducts.stringToBePassed;
		Debug.Log ("queried on models:"+stringQueriedonThisPage);
		StartCoroutine(PostProduct());
	}
	/*
	void Start()
	{
		//Debug.Log("Start in populatemoidels called");

		stringQueriedonThisPage = PopulateProducts.stringToBePassed;
		
		StartCoroutine(PostProduct());
	}*/
	
	IEnumerator PostProduct()
	{
		Debug.Log ("Post product called");

		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		
		string post_url = modelURL + "product=" + stringQueriedonThisPage; //WWW.EscapeURL(PopulateCategory.stringToBePassed);
		
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
			string prefURL;

			for(int i=0; i<words.Length-1; i++)
			{
				/*
				Toggle mytoggle = (Toggle) Instantiate(radioButton, new Vector3(0,0,0),Quaternion.identity) ;
				mytoggle.transform.SetParent(transform);
				
				//mytoggle.group = (ToggleGroup)GetComponent<ToggleGroup>();
				
				Text mytext = (Text) mytoggle.GetComponentInChildren<Text>() ;
				
				mytext.text = words[i];
				
				mytoggle.transform.localPosition = new Vector3(-100,150-50*(i),0) ;
				
				myTogglesList.Add(mytoggle);
				*/

				//GameObject prefabInstance = (GameObject) Instantiate(myPrefab, new Vector3(0,0,0),Quaternion.identity) ;
				GameObject prefabInstance = (GameObject) Instantiate(myPrefab, transform.position ,Quaternion.identity) ;

				prefabInstance.transform.SetParent(transform,false);

				prefabInstance.transform.localPosition = new Vector3(0,150-150*(i),0) ;

				Text mytext = (Text) prefabInstance.GetComponentInChildren<Text>() ;

				mytext.text = words[i];

				//Debug.Log ("Art/Models/Cereal/Wheaties/"+mytext.text);

				if(i==0)
				{
					prefURL = "Art/Models/Cereal/Wheaties/wheaties";
				}
				else
				{
					prefURL = "Art/Models/Cereal/Wheaties Ali/wheaties_ali";
				}

				GameObject modelPrefabInstance = (GameObject) Instantiate(Resources.Load(prefURL), transform.position ,Quaternion.identity) ;

				modelPrefabInstance.transform.SetParent(prefabInstance.transform,false);

				modelPrefabInstance.transform.localPosition = new Vector3(160,-2,-30);

				modelPrefabInstance.transform.localScale = new Vector3(0.27f,0.27f,0.27f);

				//modelPrefabInstance.transform.localPosition = new Vector3(475,-17,-76);

				modelPrefabInstance.transform.Rotate(0,30,0,Space.Self);

				myPrefabList.Add(prefabInstance);

				Debug.Log(myPrefabList.Count);
			}
			
		}
	}

	public void onModelNext()
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
		}
		*/


		Toggle mytoggle;
		Text mytext;

		myModelsList.Clear ();

		foreach (GameObject g in myPrefabList) 
		{
			mytoggle = (Toggle) g.GetComponentInChildren<Toggle>();

			if(mytoggle.isOn == true)
			{
				mytext = (Text) g.GetComponentInChildren<Text>();
				myModelsList.Add(mytext.text);
			}
		}

		foreach (string s in myModelsList) 
		{
			Debug.Log("selected models: " +s);
		}

		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		myPrefabList.Clear ();


		CurrentCanvas.gameObject.SetActive (false);
		NextCanvas.gameObject.SetActive (true);
	} 

	public void onModelPrev()
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
		}
		*/

		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		CurrentCanvas.gameObject.SetActive (false);
		PreviousCanvas.gameObject.SetActive (true);
	} 

}
