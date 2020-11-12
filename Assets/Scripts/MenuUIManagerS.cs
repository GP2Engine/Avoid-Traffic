using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManagerS : MonoBehaviour {

    public AudioManager aman;

	// Use this for initialization
	void Start () {
		aman.UIbgmusic.volume = Settings.UIvolumelvl;
		Time.timeScale=1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void BackBut()
	{
		SceneManager.LoadScene ("menuScene");
	}
}
