using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CarController : MonoBehaviour {

    public static float carSpeed;
	public float maxPos = 2.1f;
	public GameObject coll;
	public uiManager ui;
	public AudioManager am;
	public LiveManager lm2;
	
	Vector3 position;
	
	// Use this for initialization
	void Start () {
		if (Settings.enginesound==true)
		{
			am.carSound.Play();
		}
		
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
		
		position.x = Mathf.Clamp (position.x,-2.1f,2.1f);
		
		transform.position = position;
		
	
	}
	
	
	public bool PosCheck()   // gia skid hxo
	{
		if ((transform.position.x==-2.1f)&&(Input.GetKeyDown(KeyCode.LeftArrow)))
		{
			return false;
		}
		else if ((transform.position.x==2.1f)&&(Input.GetKeyDown(KeyCode.RightArrow)))
		{
			return false;
		}
		else
		{
			return true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy Car") {
			Destroy(coll);
			Destroy (gameObject);
			
			Scene scene = SceneManager.GetActiveScene();
			if (scene.name=="level2"||scene.name=="level3"||scene.name=="level4")
			{
				lm2.liveKiller();
			}
			
			ui.gameOverActivated();
			if (Settings.enginesound==true)
			{
				am.carSound.Stop();
			}
			
			if (Settings.crashingsound==true)
			{
				am.crashSound.Play();
			}
				
			
		}
	}
	
}
