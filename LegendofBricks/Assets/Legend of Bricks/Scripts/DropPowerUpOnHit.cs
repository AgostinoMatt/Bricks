using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class DropPowerUpOnHit : MonoBehaviour
{
   
	public GameObject PowerUpPrefab;
	private bool ishit=false;
   
    void OnCollisionEnter(Collision c)
    {
		if (!ishit) {
			ishit=true;
			GameObject.Instantiate (PowerUpPrefab, this.transform.position, Quaternion.identity);
		}
    }
}