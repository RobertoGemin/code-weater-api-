using UnityEngine;
using System.Collections;

public class CloudControl : MonoBehaviour {
    public ParticleSystem Cloud;

    void Start () {
        Cloud = GameObject.Find("Cloud").GetComponent<ParticleSystem>();
        Cloud.enableEmission = false;
    }
    void activated(int count)
    {
        Cloud.enableEmission = true;
        Cloud.emissionRate = count;
    }
    void stop()
    {
        Cloud.enableEmission = false;
        Cloud.emissionRate = 0;
    }

}
