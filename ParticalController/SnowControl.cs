using UnityEngine;
using System.Collections;

public class SnowControl : MonoBehaviour {
    public ParticleSystem SnowFlake; 
    public ParticleSystem SnowIce;
    public AudioClip acSnow;
    public AudioSource asSnow;

    void Start(){
        SnowFlake = GameObject.Find("SnowFlake").GetComponent<ParticleSystem>();
        SnowIce = GameObject.Find("SnowIce").GetComponent<ParticleSystem>();
        SnowFlake.enableEmission = false;
        SnowIce.enableEmission = false;
        asSnow.enabled = false;

    }
    void activated(int count)
    {
        SnowFlake.enableEmission = true;
        SnowIce.enableEmission = true;
        SnowFlake.emissionRate = count;
        SnowIce.emissionRate = count;
        asSnow.enabled = true;
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
    void stop()
    {
        SnowFlake.enableEmission = false;
        SnowIce.enableEmission = false;
        SnowFlake.emissionRate = 0;
        SnowIce.emissionRate = 0;
        asSnow.enabled = false;
    }


}
