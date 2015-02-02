using UnityEngine;
using System.Collections;
 
using UnityEngine.UI;

public class HSController : MonoBehaviour
{
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
	public string addSelectionURL = "sonoco-server.clemson.edu/addselection.php?"; //be sure to add a ? to your url


	public Toggle toggle1;
	public Toggle toggle2;
	public Toggle toggle3;

    void Start()
    {

		toggle1 = HUD.Toggle11;
		toggle2 = HUD.Toggle22;
		toggle3 = HUD.Toggle33;


		addSelectionURL = "sonoco-server.clemson.edu/addselection.php?"; //be sure to add a ? to your url
		Debug.Log ("addSelectionURL: " + addSelectionURL + ". user_id: " + Initializer.user_id);
    }
 
	void OnCollisionEnter(Collision theCollision) {
		string obj_name = theCollision.gameObject.name;
		if (obj_name != "OVRPlayerController" && 
						obj_name != "OVRPlayerController_Wii" && 
						obj_name != "Adjustable-Shelf_Solid" && 
						obj_name != "bone1") {
			Debug.Log("Hit: " + obj_name);
			StartCoroutine (PostScores (Initializer.user_id, theCollision.gameObject.name));
		}
	}

    IEnumerator PostScores(string user, string model)
    {
		Debug.Log ("in PostScores");
        //This connects to a server side php script that will add the selection (user/exp/model) to a MySQL DB.
        //string hash = MD5Test.Md5Sum(user + model + secretKey);
        string hash = secretKey;
        //string post_url = addSelectionURL + "user=" + WWW.EscapeURL(user) + "&exp=" + exp + "&model=" + model + "&hash=" + hash;
		string post_url = addSelectionURL + "user=" + user + "&model=" + WWW.EscapeURL(model) + "&hash=" + hash;

		Debug.Log ("post_url: " + post_url);
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
 
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
		else
		{
			string s = hs_post.text;

			//find this category in the datastructure

			//for(int i=0;i<Initializer.shoppinglistcategories.Count ; i++)
			for(int i=0;i<3 ; i++) // harcoded for now
			{
				if(string.Compare(s,Initializer.shoppinglistcategories[i]) == 0)
				{

					switch(i)
					{
						case 0: toggle1.isOn = true;
								break;

						case 1: toggle2.isOn = true;
								break;

						case 2: toggle3.isOn = true;
								break;

					}

				}
			}
		}

    }
 
}