using UnityEngine;
using System.Collections;
using System;
using System.IO;

namespace StreamReadWrite
{
	public class UserPathLog : MonoBehaviour {
		
		static private bool is_uploaded;
		static public string logfilename; // initialized in Initializer.cs
		static private bool exp_done;
		
		// Use this for initialization
		void Start () {
			logfilename = "notset";
			
			//TextWriter tw = new StreamWriter("MyFileBLAH.txt", true);\
			is_uploaded = false;
			exp_done=false;
			
			File.AppendAllText (logfilename, "Start");
		}
		
		// Update is called once per frame
		void Update () {
			if (exp_done == false && logfilename != "notset" ) 
			{
				Vector3 pos = this.transform.position;
				//Debug.Log("Player Position: " + pos, gameObject);
				Quaternion rot = this.transform.rotation;
				//Debug.Log("Player Rotation: " + rot, gameObject);
				File.AppendAllText (logfilename, DateTime.Now.ToString () + " Pos:" + pos + " Rot:" + rot + Environment.NewLine);
				//sr.Close();
			}
		}
		
		/*
		void OnTriggerEnter(Collider myTrigger) {
			string obj_name = myTrigger.gameObject.name;
			if (obj_name == "EndPoint") {
				Debug.Log ("hit EndPoint");
				exp_done=true;
				StartCoroutine (UploadLog(Initializer.user_id));
			}
		}
*/
		
		public static IEnumerator UploadLog(string user)
		{
			if(is_uploaded==false) 
			{
				byte[] bytes = File.ReadAllBytes(logfilename);
				
				// Create a Web Form
				var form = new WWWForm();
				form.AddField("action", "user");
				form.AddField("file","file");
				form.AddBinaryData("file", bytes, logfilename, "text/txt");
				
				// Upload to a php script
				WWW w = new WWW("sonoco-server.clemson.edu/addlog.php", form);
				yield return w;
				if (!String.IsNullOrEmpty(w.error))
					Debug.Log("Error uploading: "+w.error);
				else
					Debug.Log("Finished Uploading Log");
				is_uploaded = true;
				
				
				
				
				//This connects to a server side php script that will add the selection (user/exp/model) to a MySQL DB.
				//string hash = MD5Test.Md5Sum(user + model + secretKey);
				//string post_url = addSelectionURL + "user=" + WWW.EscapeURL(user) + "&exp=" + exp + "&model=" + model + "&hash=" + hash;
				string post_url = "sonoco-server.clemson.edu/log.php?" + "user=" + WWW.EscapeURL(user) + "&filename=" + WWW.EscapeURL(logfilename);
				
				Debug.Log ("post_url: " + post_url);
				// Post the URL to the site and create a download object to get the result.
				WWW hs_post = new WWW(post_url);
				yield return hs_post; // Wait until the download is done
				
				if (hs_post.error != null)
				{
					Debug.Log("There was an error posting the high score: " + hs_post.error);
				}
				
			}
			
			
		}
		
	}
}