using UnityEngine;
using System.Collections;



public class Block : MonoBehaviour
{
  


	public GameObject breakblock;
	public AudioClip Sound;
	private GameManager gamemanagerscript;


	//Start is called one time when the scene has been loaded
	void Start()
	{
	
		gamemanagerscript = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}


    
    private void OnCollisionExit(Collision c)
    {
		if (c.gameObject.tag == "Player") {
			GetComponent<Collider>().enabled = false;
			AudioSource.PlayClipAtPoint(Sound, gameObject.transform.position);
			Instantiate (breakblock, transform.position, Quaternion.identity);
			gamemanagerscript.addScore();
			Destroy (gameObject);
		}
       
    }
}