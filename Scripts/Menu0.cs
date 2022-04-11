using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu0 : MonoBehaviour
{
    public void Game (int sceneID)
	{
		SceneManager.LoadScene(sceneID);
        
        }
		public void QuitGame ()
	{
		Debug.Log ("QuitGame!");
		Application.Quit();
           }
}
