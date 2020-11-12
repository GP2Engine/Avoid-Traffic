using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Settings : MonoBehaviour {

	public static bool enginesound = true;
	public static bool skidsound = true;
	public static bool scoresound = true;
	public static bool crashingsound = true;
	public static float volumelvl = 1f;   // default max volume
	public static float UIvolumelvl = 1f;
	public static int difdropvar = 1; // default medium difficulty
	public static float carsensitiv = 10f;  // default 10 to car sensitivity
	
	public Toggle engineS;
	public Toggle skidS;
	public Toggle scoreS;
	public Toggle crashS;
	public Slider volumS;
	public Slider UIvolumS;
	public Slider carsenS;
	public Dropdown difdrop;

	public AudioManager aman;


	// Use this for initialization
	void Start () {
		
		if (enginesound==true)
		{
			engineS.isOn = true;
		}
		else
		{
			engineS.isOn = false;
		}
		
		if (skidsound==true)
		{
			skidS.isOn = true;
		}
		else
		{
			skidS.isOn = false;
		}
		
		if (scoresound==true)
		{
			scoreS.isOn = true;
		}
		else
		{
			scoreS.isOn = false;
		}
		
		if (crashingsound==true)
		{
			crashS.isOn = true;
		}
		else
		{
			crashS.isOn = false;
		}
		
		volumS.value = volumelvl;
		
		UIvolumS.value = UIvolumelvl;
		
		difdrop.value = difdropvar;
		
		carsenS.value = carsensitiv;
	}
	
	// Update is called once per frame
	void Update () {
		aman.UIbgmusic.volume = UIvolumS.value; // for live updating of settings background music (since it will be on)
	}
	
	public void Back()
	{
		
		if (engineS.isOn)
		{
			enginesound=true;
		}
		else
		{
			enginesound=false;
		}
		
		if (skidS.isOn)
		{
			skidsound=true;
		}
		else
		{
			skidsound=false;
		}
		
		if (scoreS.isOn)
		{
			scoresound=true;
		}
		else
		{
			scoresound=false;
		}
		
		if (crashS.isOn)
		{
			crashingsound=true;
		}
		else
		{
			crashingsound=false;
		}
		
		volumelvl = volumS.value;
		
		UIvolumelvl = UIvolumS.value;
		
		difdropvar = difdrop.value;
		
		carsensitiv = carsenS.value;
		
	
		SceneManager.LoadScene ("menuScene");
	}
	
	public void ResetBut()  // sensitivity slider reset
	{
		carsenS.value = 10f;
	}
	
}
