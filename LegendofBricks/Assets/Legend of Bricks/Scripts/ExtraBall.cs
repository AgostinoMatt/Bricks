using UnityEngine;


public class ExtraBall : MonoBehaviour
{
	public float DropSpeed = 5;
   
    public GameObject BallPrefab;
	private bool pickuped=false;

	//Start is called one time when the scene has been loaded
	void Start()
	{
	
		transform.GetComponent<Rigidbody>().AddForce (-1 * Vector3.back * 8, ForceMode.Impulse);
	}

	private void OnTriggerEnter(Collider other)
	{
		//Only interact with the paddle
		if (other.name == "Paddle")
		{

			OnPickup();

		
			GetComponent<Collider>().enabled= false;

			Destroy(this.gameObject);

		}
	}

   
     void OnPickup()
    {
		if (!pickuped) {

			pickuped=true;
		

			//Create a new ball and launch it
			GameObject ball = Instantiate (BallPrefab, transform.position, Quaternion.identity) as GameObject;
			ball.GetComponent<Ball> ().Launch ();
		}
    }
}