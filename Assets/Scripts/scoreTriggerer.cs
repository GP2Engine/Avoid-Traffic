using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreTriggerer : MonoBehaviour {

    public Text scoreText; 
	public static float score; 
	public AudioManager am3;
	public static float prevscore;


	// Use this for initialization
	void Start () {
		score = -1;
	}
	
	// Update is called once per frame
	void Update () {
		Scene ascene = SceneManager.GetActiveScene();
		if (score==15 && ascene.name=="level1")
		{
			uiManager.NextScene = "level2";
			LiveManager.lives = 2; // lives initialization
			prevscore = score;
			SceneManager.LoadScene ("levelLoader");
		}
		else if (score==25 && ascene.name=="level2")
		{
			uiManager.NextScene = "level3";
			LiveManager.lives = 4; // lives initialization
			prevscore = prevscore + score;
			SceneManager.LoadScene ("levelLoader");
		}
		else if (score==35 && ascene.name=="level3")
		{
			uiManager.NextScene = "level4";
			LiveManager.lives = 6; // lives initialization
			prevscore = prevscore + score;
			SceneManager.LoadScene ("levelLoader");
		}
		else
		{
			scoreText.text = "Level Score: " + score;
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		score += 1;
		if(score>0){
			if (Settings.scoresound==true)
			{
				am3.beep.Play();
			}
		}
	}
}
