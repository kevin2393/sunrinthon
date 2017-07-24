using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void gotogame()
    {
        SceneManager.LoadScene("Game");
    }

    public void gameset()
    {
        Application.Quit();
    }

    public void main()
    {
        SceneManager.LoadScene("main");
    }
}
