using UnityEngine;
using System.Collections;

public class BestObject : MonoBehaviour {

	public GameObject scoretext;
	private int best;
	// Use this for initialization
	void Start () {
		best = PlayerPrefs.GetInt ("Best", 0);
		scoretext.GetComponent<TextMesh>().text="Best:"+best.ToString ();
	}
	

}
