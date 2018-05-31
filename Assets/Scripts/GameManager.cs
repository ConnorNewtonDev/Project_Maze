using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze maze;
    private static GameManager instance;
    public GameObject playePrefab;
    private GameObject p;
    public int mazeCompleted = 0;
    public Scene scene;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        p = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        Time.timeScale = 1;
        //Add Maze
        maze = Instantiate(mazePrefab);
        maze.name = "Maze";
        maze.Generate(10 + mazeCompleted, 10 + mazeCompleted);

        //Add Player
        if(p == null)
        {
            p = Instantiate(playePrefab, new Vector3(maze.Cells[0, 0].posX, 0.5f, maze.Cells[0, 0].posZ), Quaternion.identity, null) as GameObject;
            p.transform.LookAt(maze.path[1].transform);
            p.transform.Rotate(-25.565f, 0, 0);
            p.name = "Player";

            Instantiate(maze.goal, maze.Cells[maze.sizeX - 1, maze.sizeZ - 1].transform.position, Quaternion.identity, null);
        }
        else
        {            
            p.transform.position = new Vector3(maze.Cells[0, 0].posX, 0.5f, maze.Cells[0, 0].posZ);
            p.transform.LookAt(maze.path[1].transform);
            p.transform.Rotate(-25.565f, 0, 0);

            GameObject.FindGameObjectWithTag("Finish").transform.position = maze.Cells[maze.sizeX - 1, maze.sizeZ - 1].transform.position;
        }

        Timer timer = FindObjectOfType<Timer>();
        timer.SwapActive();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            XRSettings.enabled = true;
            Debug.Log("Changed VRSettings.enabled to:" + XRSettings.enabled);
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void NextLevel()
    {
        Time.timeScale = 0;
        mazeCompleted += 1;
        //Handle remaining time
        Timer timer = FindObjectOfType<Timer>();
        timer.SwapActive();
        float temp = timer.curTime;
        timer.SetTimer(temp);
        //Reset Maze
        Destroy(maze.gameObject);

        //Adjust Goal

        //Adjust Player
     

        Start();

    }

    public IEnumerator SwapScene(Scene scene, Scene oldScene)
    {
        Debug.Log("oom");
        int i = 0;
        while (i ==0)
        {
            i++;
            yield return null;
        }
        SceneManager.SetActiveScene(scene);
        SceneManager.UnloadSceneAsync(oldScene);
        yield break;
    }
}
