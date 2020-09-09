using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour 
{

	public string scenename;

	public void loadscene()
	{
	

		SceneManager.LoadScene (scenename);




	}

    public void LoadMenu()
    {
        SceneManager.LoadScene("start");
    }

}
