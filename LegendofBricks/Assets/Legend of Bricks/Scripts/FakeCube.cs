using UnityEngine;
using System.Collections;

public class FakeCube : MonoBehaviour {

	public GameObject breakblock;

	// Use this for initialization
	void Start () {

	}
	



	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {

			GetComponent<Collider>().enabled = false;
			Instantiate (breakblock, transform.position, Quaternion.identity);
		
			gameObject.transform.parent.gameObject.SetActive(false);
		
		}
	}
}
