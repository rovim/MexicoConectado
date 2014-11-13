using UnityEngine;
using System.Collections;

public class Mapao : MonoBehaviour {
	string str = "Buscando satélites";

	public void show()
	{
		Gps main = GetComponent<Gps>();
		GUI.Label(onScreen(.1f, .02f, 1f, 1f), str + "ORTHO zoom: " + main.zoom);
		
		if(main.tex!=null) GUI.DrawTexture(onScreen(.1f, .1f, .8f, (9f/16f)*.8f), main.tex); //dibuja el mapa, tex guarda el mapa
		
		if(main.primer && main.lat != 0.0f){ StartCoroutine(main.GetData(0)); main.primer = false;}
		
		if(GUI.Button(onScreen(.1f, .6f, .3f, .1f), "+")) StartCoroutine(main.GetData(1));
		if(GUI.Button(onScreen(.6f, .6f, .3f, .1f), "-")) StartCoroutine(main.GetData(-1));
	}
	
	Rect onScreen(float x, float y, float w, float h) {return new Rect(Screen.width*x, Screen.height*y, Screen.width*w, Screen.height*h);}

}
