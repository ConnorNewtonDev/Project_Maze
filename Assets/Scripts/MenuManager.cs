using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
    }

    public void Replay()
    {
        GameObject Temp = FindObjectOfType<GameManager>().gameObject;
        Destroy(Temp);
		SceneManager.LoadScene (1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
