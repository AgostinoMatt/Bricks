using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public int x_speed=0;
	public int y_speed=10;
	public int z_speed=0;


	void  Start (){
		
	}
	void  Update (){
		transform.Rotate(Time.deltaTime*x_speed, Time.deltaTime*z_speed, Time.deltaTime*y_speed);


	}
}