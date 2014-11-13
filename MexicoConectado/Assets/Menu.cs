using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public void show() 
	{
		GUI.Label(onScreen(.0f, .00f, 1f, 1f), "Soy el menu.");
	}

	Rect onScreen(float x, float y, float w, float h) {return new Rect(Screen.width*x, Screen.height*y, Screen.width*w, Screen.height*h);}
}
