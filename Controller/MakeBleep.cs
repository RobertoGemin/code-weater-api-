using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class MakeBleep : MonoBehaviour {
    public AudioClip acBleeb;
    public AudioSource asBleeb;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void makeSound() {
        GetComponent<AudioSource>().PlayOneShot(asBleeb.clip, 0.25f);
    }
}
