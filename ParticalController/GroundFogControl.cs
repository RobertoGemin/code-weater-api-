using UnityEngine;
using System.Collections;

public class GroundFogControl : MonoBehaviour {


    public ParticleSystem groundFog;
    // Use this for initialization
    void Start () {
        groundFog = GameObject.Find("GroundFog").GetComponent<ParticleSystem>();
        groundFog.enableEmission = false;
    }
    void activated(){
        groundFog.enableEmission = true;
    }
    void stop()
    {
        groundFog.enableEmission = false;
    }

}
