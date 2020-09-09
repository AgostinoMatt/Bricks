using System.Collections;
using UnityEngine;



//Make sure there is always an AudioSource component on the GameObject where this script is added.
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
	public GameObject gameoverPanel;
	public GameObject menuPanel;
    public GameObject slider;

   
    public AudioClip StartSound;
    public AudioClip FailedSound;

	private GameState currentState = GameState.Pending;
  
    private Ball[] allBalls;

	public Transform spawnerpoint;
	public GameObject[] levelobject;
	private float timepadding;
	public float timecount;
	private int index;

	public GameObject scoretext;
	private int score = 0;
	private int best;



    // Use this for initialization
    void Start()
    {
		Application.targetFrameRate = 60;



      
        allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];
		GetComponent<AudioSource>().PlayOneShot(StartSound);

		best = PlayerPrefs.GetInt ("Best", 0);

        //Start game
		SwitchTo(GameState.Pending);


    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
		     case GameState.Pending:
                    //Check if the tap the screen.
                    if (Input.GetMouseButtonDown(0))   
                    {
                        for (int i = 0; i < allBalls.Length; i++)
                            allBalls[i].Launch();

                        SwitchTo(GameState.Playing);
                    }
                break;
            case GameState.Playing:
                {
                   

			       timepadding=timepadding+Time.deltaTime;
			if(timepadding>=timecount)
			{
				timepadding=0;
				index=Random.Range(0,levelobject.Length);
				Instantiate(levelobject[index],spawnerpoint.position,Quaternion.identity);

			}


                  
                    if (FindObjectOfType(typeof(Ball)) == null)
					    SwitchTo(GameState.GameOver);

                   
                }
                break;
           
		     case GameState.GameOver:
         
                break;
        }
    }




   
    public void SwitchTo(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            default:
		    case GameState.Pending:
              
                break;
            case GameState.Playing:
                
             
                break;
         
		    case GameState.GameOver:
			       Gameover ();
                break;
        }
    }

    

 

	public void addScore()
	{
		score++;

		scoretext.GetComponent<TextMesh>().text=score.ToString ();
	}


	IEnumerator  PrepareAD (){
		
		

		gameoverPanel.SetActive (true);
		GetComponent<AudioSource>().PlayOneShot(FailedSound);
		yield return new WaitForSeconds(1.5f);
		
	
		//show your ad here

		yield return new WaitForSeconds(0.5f);
		menuPanel.SetActive (true);
        slider.SetActive(false);
		
	}
	
	public void  Gameover (){
		
		if (score > best) {
		
			best=score;
			PlayerPrefs.SetInt("Best",best);
		
		}


		StartCoroutine(PrepareAD());
	}


}


//List of all the posible gamestates
public enum GameState
{
	Pending,
	Playing,
	GameOver
}