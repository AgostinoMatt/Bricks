using UnityEngine;
using System.Collections;



public class LevelObject : MonoBehaviour
{
   
	public float speed;


	// Use this for initialization
	void Start () {
		Destroy (gameObject, 15);
	}


    void Update()
    {
		transform.Translate(Vector3.back*Time.deltaTime*speed);
    }

 
}