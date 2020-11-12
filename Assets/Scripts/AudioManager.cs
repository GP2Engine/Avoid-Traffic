using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	
	public AudioSource carSound;
	public AudioSource skidSound;
	public AudioSource crashSound;
	public AudioSource beep;
	public AudioSource bgmusic; // for gameplay (levels)
    public AudioSource UIbgmusic; // for the UI music	
	public uiManager ui2;
	public CarController cc1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Scene curscene = SceneManager.GetActiveScene();
		if (curscene.name=="level1"||curscene.name=="level2"||curscene.name=="level3"||curscene.name=="level4")
		{
        if((Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))&&(ui2.gameOver==false)&&(ui2.ispaused==false)&&cc1.PosCheck()&&(Settings.skidsound==true))
		{
			skidSound.Play();

		}
		else if((Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow))&&(Settings.skidsound==true))
		{
			skidSound.Stop();
		}
		}
		

	}
}
