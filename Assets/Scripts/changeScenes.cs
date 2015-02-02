using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeScenes : MonoBehaviour {

	//int option;

	public Canvas current;
	public Canvas next;

	public InputField myinp;

	public static string ExperimentID;

	bool leftControl;

	public void onIDSubmit()
	{
		ExperimentID = myinp.text.text;
		Application.LoadLevel("Main");
	}

	void Awake()
	{
		//option = 0;
		DontDestroyOnLoad(transform.gameObject);
	}

	public void configure()
	{
		//option = 1;

		//current.gameObject.SetActive (false);
		//next.gameObject.SetActive (true);

		Application.LoadLevel("1");
	}

	public void run()
	{
		//option = 2;

		current.gameObject.SetActive (false);
		next.gameObject.SetActive (true);

		//Application.LoadLevel("Main");
	}

	public void results()
	{
		//option = 3;

		//current.gameObject.SetActive (false);
		//next.gameObject.SetActive (true);

		Application.LoadLevel("test");
	}
	/*
	public void startExperiment()
	{

		switch (option) 
		{
			//case 1: Application.LoadLevel("1");
			//		break;

			case 2: Application.LoadLevel("Main");
					break;

			case 3: Application.LoadLevel("test");
					break;
		}
	}
	*/

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftControl))
			leftControl = true;
		if(Input.GetKeyUp(KeyCode.LeftControl))
			leftControl = false;
			
		if (leftControl && Input.GetKeyDown (KeyCode.M)) 
		{
			Application.LoadLevel("Menu");
		}
	}
}
