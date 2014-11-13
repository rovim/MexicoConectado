using UnityEngine;
using System.Collections;
 
public enum views {NOGPS, MAPAO, MAPAL, BRUJULA};

public class Gps : MonoBehaviour 
{	
	public Texture2D tex;
	public float lon, lat, zoom = 13;	
	public views v;
	public bool primer = true;
	WWW www;
	bool ocupado;
	int maxWait;

  	IEnumerator Start ()
	{
	    if (!Input.location.isEnabledByUser) v = views.NOGPS;
	 	Input.location.Start(5f, 5f); //con el stat activas el sensor. los parametros son para la presición, mientras menor sean los número, más preciso y más energía gastas. Se peude dejar en blanco y quedan 10 y 10.
		for(maxWait = 20; Input.location.status == LocationServiceStatus.Initializing && maxWait > 0; maxWait--) 
	      yield return new WaitForSeconds(1);
	    if (maxWait < 1) v = views.NOGPS;
		if (Input.location.status == LocationServiceStatus.Failed)	v = views.NOGPS;
		else
		{
			v = views.MAPAL;
			InvokeRepeating("updateGPS", 0, 1); // InvokeRpeating manda a llamar una función en determinado tiempo y cada determinado tiempo
		}
  	}

	void OnGUI ()
	{
		if(v == views.NOGPS)
			GetComponent<Nogps>().show();
		if(v == views.MAPAL)
			GetComponent<Mapal>().show();
		if(v == views.MAPAO)
			GetComponent<Mapao>().show();
		if(v == views.BRUJULA)
			GetComponent<Brujula>().show();

		GetComponent<Menu>().show();
	}

	void updateGPS() { lat = Input.location.lastData.latitude; lon = Input.location.lastData.longitude;}
	
	public IEnumerator GetData(float dzoom) // recibe un float lamado dzoom, que es el 1, -1 y 0 que se han usado arriba
	{
		Debug.Log("getData");
		if(!ocupado) //es como un semáforo, sin esto, cuando pides dos imágenes muy rápido truena
		{
			ocupado = true;
			www = new WWW("http://maps.googleapis.com/maps/api/staticmap?center="+ lat + "," + lon + "&zoom="+ (zoom += dzoom) +"&size=512x512&markers=color:red%7C"+ lat + "," + lon + "&sensor=true");
			// "zoom += dzoom" le suma dzoom a zoom y te deja con el valor ya sumado. 
			yield return www; // yield espera a que termine todo lo de arriba y con return a puedes seguir.
			tex = www.texture; // la textura que pedimos(el mapa) se guarda en nuestra variable tex.
			ocupado = false;
		}
	}
	Rect onScreen(float x, float y, float w, float h) {return new Rect(Screen.width*x, Screen.height*y, Screen.width*w, Screen.height*h);}
}