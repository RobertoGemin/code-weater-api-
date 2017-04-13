using UnityEngine;
using System.Collections;

public class LightningControl : MonoBehaviour {

    public ParticleSystem Lightning1;
    public ParticleSystem Lightning2;
    public ParticleSystem Lightning3;
    public AudioSource lightning;

    void Start () {
        Lightning1 = GameObject.Find("Lightning1").GetComponent<ParticleSystem>();
        Lightning2 = GameObject.Find("Lightning2").GetComponent<ParticleSystem>();
        Lightning3 = GameObject.Find("Lightning3").GetComponent<ParticleSystem>();
        Lightning1.enableEmission = false;
        Lightning2.enableEmission = false;
        Lightning3.enableEmission = false;
        GetComponent<AudioSource>().enabled = false;

    }
    void activated()
    {
        Lightning1.enableEmission = true;
        Lightning2.enableEmission = true;
        Lightning3.enableEmission = true;
        lightning.enabled = true;
        GetComponent<AudioSource>().Play();
    }
    void stop()
    {
        Lightning1.enableEmission = false;
        Lightning2.enableEmission = false;
        Lightning3.enableEmission = false;
        GetComponent<AudioSource>().enabled = false;
      
    }
}
