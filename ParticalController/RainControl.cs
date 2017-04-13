using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RainControl : MonoBehaviour {
    public ParticleSystem rain;
    public AudioClip acRain;
    public AudioSource asRain;
    void Start () {
        rain = GameObject.Find("Rain").GetComponent<ParticleSystem>();
        rain.enableEmission = false;
        asRain.enabled = false;
    }

    void activated(int count){
        rain.enableEmission = true;
        rain.emissionRate = count;
        asRain.enabled = true;
        if (count < 50)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().volume = 0.25f;
  
        }
        else if (count < 100)
        {

            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().volume = 0.50f;
        }
        else
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().volume = 0.75f;
        }

            
    }
    void stop(){
        rain.enableEmission = false;
        asRain.enabled = false;

    }

}
