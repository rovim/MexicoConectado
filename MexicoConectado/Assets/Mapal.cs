﻿using UnityEngine;
using System.Collections;

public class Mapal : MonoBehaviour {
	public void show()
	{
		GUI.Label(onScreen(.1f, .02f, 1f, 1f), "MAap L");
	}
	
	Rect onScreen(float x, float y, float w, float h) {return new Rect(Screen.width*x, Screen.height*y, Screen.width*w, Screen.height*h);}

}
