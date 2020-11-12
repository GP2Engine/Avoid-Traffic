using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LiveManager : MonoBehaviour {

    public static int lives;
	public Text livetext;

	// Use this for initialization
	void Start () {
			livetext.text= "Lives: " + lives;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void liveKiller()
	{
		if (lives>0)
		{
			lives -= 1;
			livetext.text= "Lives: " + lives;	
		}	
	}
	
	public void liveDecider(string str)
	{
		if (lives>0)
		{
			uiManager.NextScene = str;
			SceneManager.LoadScene("levelLoader");
		}
		else
		{
			if (str=="level2")
			{
				uiManager.NextScene = "level1";
				scoreTriggerer.prevscore = 0; // not required
				SceneManager.LoadScene("levelLoader");
			}
			else if (str=="level3")
			{
				uiManager.NextScene = "level2";
				scoreTriggerer.prevscore = 15;  
				lives = 2;   // lives initialization otan peftoume level
				SceneManager.LoadScene("levelLoader");
			}
			else if (str=="level4")
			{
				uiManager.NextScene = "level3";
				scoreTriggerer.prevscore = 40; 
				lives = 4;   // lives initialization otan peftoume level
				SceneManager.LoadScene("levelLoader");
			}
		}
	}
	
	
	
}
