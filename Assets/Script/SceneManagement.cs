using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    // Use this for initialization
    public void TryAgain()
    {
        SceneManager.LoadScene("City of war lvl 1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("City of War lvl 2");
    }
}
