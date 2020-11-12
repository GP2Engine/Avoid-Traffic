using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class uiManager : MonoBehaviour {


	public Button[] buttons;
	public Button pausebutton;
	public Text gmtext;
	public Text scoretext;
	public Text scoreEnd;
	public bool gameOver;
	public bool ispaused;
	public AudioManager am2;
	public static string NextScene = "";
	public LiveManager lm1;
	public Text replay;


	// Use this for initialization
	void Start () {
		Screen.SetResolution(480, 800, true);
		Time.timeScale=1;
		gameOver = false;
		ispaused = false;
		Scene curscene = SceneManager.GetActiveScene();
		if (curscene.name=="level1"||curscene.name=="level2"||curscene.name=="level3"||curscene.name=="level4")
		{
			am2.bgmusic.volume = Settings.volumelvl;
			
			CarController.carSpeed = Settings.carsensitiv;

			
			if (Settings.difdropvar==0)  // easy difficulty
			{
				if (curscene.name=="level1"){CarSpawner.delayTimer=1.2f;}
				if (curscene.name=="level2"){CarSpawner.delayTimer=1.0f;}
				if (curscene.name=="level3"){CarSpawner.delayTimer=0.8f;}
				if (curscene.name=="level4"){CarSpawner.delayTimer=0.7f;}
			}
			else if(Settings.difdropvar==1) // medium difficulty
			{
				if (curscene.name=="level1"){CarSpawner.delayTimer=0.9f;}
				if (curscene.name=="level2"){CarSpawner.delayTimer=0.76f;}
				if (curscene.name=="level3"){CarSpawner.delayTimer=0.65f;}
				if (curscene.name=="level4"){CarSpawner.delayTimer=0.56f;}
			}
			else if(Settings.difdropvar==2) // hard difficulty
			{
				if (curscene.name=="level1"){CarSpawner.delayTimer=0.7f;}
				if (curscene.name=="level2"){CarSpawner.delayTimer=0.58f;}
				if (curscene.name=="level3"){CarSpawner.delayTimer=0.49f;}
				if (curscene.name=="level4"){CarSpawner.delayTimer=0.42f;}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		Scene curscene = SceneManager.GetActiveScene();
		if ((Input.GetKeyDown(KeyCode.Escape))&&(curscene.name=="level1"||curscene.name=="level2"||curscene.name=="level3"||curscene.name=="level4"))
		{
			Pause();
		}
		
		if ((Input.GetKeyDown(KeyCode.Space))&&(curscene.name=="level1"||curscene.name=="level2"||curscene.name=="level3"||curscene.name=="level4")&&(gameOver==true||ispaused==true))
		{
			Replay();
		}
	}
	
	
	public void gameOverActivated(){
		gameOver = true;
		pausebutton.gameObject.SetActive(false);
		foreach (Button button in buttons){
			button.gameObject.SetActive(true);
		}

		gmtext.gameObject.SetActive(true);
		
		Scene curscene = SceneManager.GetActiveScene();
		if (curscene.name=="level1")
		{
			replay.text = "Replay Level 1";
			scoreEnd.text = "Total Score: " + scoreTriggerer.score;
		}
		else if (curscene.name=="level2")
		{
			if (LiveManager.lives>0)
			{
				replay.text = "Replay Level 2";
			}
			else
			{
				replay.text = "Replay Level 1";
			}
			
			scoreEnd.text = "Total Score: " + (scoreTriggerer.score+scoreTriggerer.prevscore);
		}
		else if (curscene.name=="level3")
		{
			if (LiveManager.lives>0)
			{
				replay.text = "Replay Level 3";
			}
			else
			{
				replay.text = "Replay Level 2";
			}
			
			scoreEnd.text = "Total Score: " + (scoreTriggerer.score+scoreTriggerer.prevscore);
		}
		else if (curscene.name=="level4")
		{
			if (LiveManager.lives>0)
			{
				replay.text = "Replay Level 4";
			}
			else
			{
				replay.text = "Replay Level 3";
			}
			
			scoreEnd.text = "Total Score: " + (scoreTriggerer.score+scoreTriggerer.prevscore);
		}
		scoreEnd.gameObject.SetActive(true);

	}
	
	
	public void Play(){
		NextScene = "level1";
		SceneManager.LoadScene ("levelLoader");
	}

    public void SettingsLoad(){
        SceneManager.LoadScene("settings");
    }
	
	public void InfoLoad()
	{
		SceneManager.LoadScene("info");
	}
	
	public void Pause(){
	 if (gameOver==false)
	 {
		if (Time.timeScale==1){
			Time.timeScale=0;
			if (Settings.enginesound==true)
			{
				am2.carSound.Stop();
			}
			foreach (Button button in buttons){
				button.gameObject.SetActive(true);
			}
			
			Scene curscene = SceneManager.GetActiveScene();
			if (curscene.name=="level1"){replay.text = "Replay Level 1";}
			if (curscene.name=="level2"){replay.text = "Replay Level 2";}
			if (curscene.name=="level3"){replay.text = "Replay Level 3";}
			if (curscene.name=="level4"){replay.text = "Replay Level 4";}
			
			ispaused = true;
		}
		else if(Time.timeScale==0){
			Time.timeScale=1;
			if (Settings.enginesound==true)
			{
				am2.carSound.Play();
			}
			foreach (Button button in buttons){
				button.gameObject.SetActive(false);
			}
			ispaused = false;
		}
	 }
	}
	
	public void Replay(){
		Scene scene = SceneManager.GetActiveScene(); 
        if (scene.name=="level1")
		{
			NextScene = scene.name;
			SceneManager.LoadScene("levelLoader");
		}
		else if (scene.name=="level2"||scene.name=="level3"||scene.name=="level4")
		{
			lm1.liveDecider(scene.name);
		}
		
	}
	
	public void MainMenu(){
		SceneManager.LoadScene ("menuScene");	
	}
	
	public void ExitGame(){
		Application.Quit();
	}
	

}
