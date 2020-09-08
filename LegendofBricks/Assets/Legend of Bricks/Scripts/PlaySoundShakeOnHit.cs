using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlaySoundShakeOnHit : MonoBehaviour
{
   
    public AudioClip Sound;

	private bool ishit=false;


	//Start is called one time when the scene has been loaded
	void Start()
	{
		

	}

    //OnCollisionEnter will only be called when one of the colliders has a rigidbody
    void OnCollisionEnter(Collision c)
    {
		if (!ishit&&c.gameObject.tag=="Player") {
			//Play it once for this collision hit
			ishit=true;
			GetComponent<AudioSource>().PlayOneShot (Sound);
		
			Invoke("resetflag",0.4f);
		}
    }

	private void resetflag()
	{
		ishit = false;

	}
}