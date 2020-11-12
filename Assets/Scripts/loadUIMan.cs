using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadUIMan : MonoBehaviour {

	public Text levelShow;
	public Text highscore;
	public Text curscore;
	
	// Use this for initialization
	void Start () {
		if (uiManager.NextScene=="level1")
		{
			levelShow.text="Level 1";
			curscore.text="Current Total Score: 0";  
		}
		else if(uiManager.NextScene=="level2")
		{
			levelShow.text="Level 2";
			curscore.text="Current Total Score: 15"; 
		}
		else if(uiManager.NextScene=="level3")
		{
			levelShow.text="Level 3";
			curscore.text="Current Total Score: 40";
		}
		else if(uiManager.NextScene=="level4")
		{
			levelShow.text="Level 4";
			highscore.gameObject.SetActive(true);
			curscore.text="Current Total Score: 75";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			LoadLevel();
		}
		
	}
	
    public void LoadLevel(){
		SceneManager.LoadScene (uiManager.NextScene);	
	}	

}
