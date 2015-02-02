using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PieChartMeshController : MonoBehaviour
{
    PieChartMesh mPieChart;
    float[] mData;

	string resultURL = "http://sonoco-server.clemson.edu/result.php?";

	string experimentModelURL = "http://sonoco-server.clemson.edu/getExperimentModels.php?";

	List<string> myModelsList = new List<string> ();

	public InputField IDPassed;

    void Start()
    {
		print (IDPassed.text.text);

		StartCoroutine(getExpModels());


		float[] mData = new float[3];

		mPieChart = gameObject.AddComponent<PieChartMesh>() as PieChartMesh;
        if (mPieChart != null)
        {
            mPieChart.Init(mData, 100, 0, 100, null);
            //mData = GenerateRandomValues(4);


			mData[0] = 0.4f;
			mData[1] = 0.2f;
			mData[2] = 0.4f;

			//StartCoroutine(PostResults());


            mPieChart.Draw(mData);
        }
    }

	IEnumerator getExpModels()
	{
		experimentModelURL = experimentModelURL + "experimentID=" + IDPassed.text.text;

		WWW hs_post = new WWW(experimentModelURL);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null) 
		{
			print ("There was an error posting the high score: " + hs_post.error);
		} 
		else
		{

		}

	}

	/*
	IEnumerator PostResults()
	{
		WWW hs_post = new WWW(resultURL);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
		else
		{
			string s = cat_get.text;
			
			int index = s.IndexOf("$%^");
			
			s = s.Substring(index+3);
			
			string[] words = s.Split(':');
			
			for(int i=0; i<words.Length-1; i++)
			{
				if(words[i]=="wheaties")
				{
					model1count 
				}
			}

		}
		
	}
	}
	*/

	/*
    void Update()
    {	
        if (Input.GetKeyDown("a"))
        {
            mData = GenerateRandomValues(4);
            mPieChart.Draw(mData);
        }
    }
	*/
	/*
    float[] GenerateRandomValues(int length)
    {
        float[] targets = new float[length];

        for (int i = 0; i < length; i++)
        {
            targets[i] = Random.Range(0f, 100f);
        }
        return targets;
    }
	 */
}
