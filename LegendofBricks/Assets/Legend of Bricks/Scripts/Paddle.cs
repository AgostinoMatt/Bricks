using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

	private  float freedom = 9.8F;

    void Update()
    {
        //Check if left mousebutton is down or a finger is touching the screen
        if (Input.GetMouseButton(0))
        {
            //Create a ray from camera to playfield
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane p = new Plane(Vector3.up, transform.position);

            //Shoot the ray to know where the click/tap found place in 3D
            float distance;
            if (p.Raycast(mouseRay, out distance))
            {
               
                Vector3 position = transform.position;
               
                position.x = mouseRay.GetPoint(distance).x; 
               
                transform.position = position;
            }
          
        }

     
       
        Vector3 limitedPosition = transform.position;
        if (Mathf.Abs(limitedPosition.x) > freedom)
        {
            //Paddle is outside the level so move it back in
            limitedPosition.x = Mathf.Clamp(transform.position.x, -freedom, freedom);
            transform.position = limitedPosition;
        }




    }






}