using UnityEngine;

public class Ball : MonoBehaviour
{
    //the min and max speed of ball
    public float MinimumSpeed = 25;
    public float MaximumSpeed = 30;

   
    public float MinimumVerticalMovement = 0.1F;

  
    private bool hasBeenLaunched = false;

    //Start is called one time when the scene has been loaded
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenLaunched)
        {
            //Get current speed and direction
            Vector3 direction = GetComponent<Rigidbody>().velocity;
            float speed = direction.magnitude;
            direction.Normalize();

       
            if (direction.z > -MinimumVerticalMovement && direction.z < MinimumVerticalMovement)
            {
               
                direction.z = direction.z < 0 ? -MinimumVerticalMovement : MinimumVerticalMovement;

               
                direction.x = direction.x < 0 ? -1 + MinimumVerticalMovement : 1 - MinimumVerticalMovement;
                
              
                GetComponent<Rigidbody>().velocity = direction * speed;   
            }

            if (speed < MinimumSpeed || speed > MaximumSpeed)
            {
               
                speed = Mathf.Clamp(speed, MinimumSpeed, MaximumSpeed);

              
                GetComponent<Rigidbody>().velocity = direction * speed;   
            }
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bottom")
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch()
    {
       
        Vector3 randomDirection = new Vector3(Random.Range(-0.1F, 0.1F), 0, Mathf.Abs(Random.value)+0.1f);

    
        randomDirection = randomDirection.normalized * MinimumSpeed;

     
        GetComponent<Rigidbody>().velocity = randomDirection;

        hasBeenLaunched = true;
    }



}
