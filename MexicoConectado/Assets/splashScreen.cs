using UnityEngine;
using System.Collections;

public class splashScreen : MonoBehaviour {

	Texture2D background, logo;
	// Use this for initialization
	void Start () {		
		background = (Texture2D)Resources.Load("background");
		logo = (Texture2D)Resources.Load("logo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

	}
}
