using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour
{
    // reference to bird
    public GameObject bird;
    //ref to bird spawn 
    public GameObject birdspawn;
    // multiplyer of score
    public int multiplier = 2;
    //ref to text 
    public Text scoreText;
    public Text endGameText;
    //score value
    public float score;
    //ref to canvases
    public GameObject endGameCanvas;
    public GameObject gameCanvas;
    public GameObject startGamecanvas;
    //ref to Pipe Spawner
    public PipeSpawner pipeSpawner;
    //payed bool
    public bool hasPlayed = false;
    void Start()
    {
        //reset position of bird
        bird.transform.position = birdspawn.transform.position;
        //reset score
        score = 0;
        // set canvases
        if (!hasPlayed)
        {
            startGamecanvas.SetActive(true);
            Time.timeScale = 0;
        }
        gameCanvas.SetActive(false);
        endGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pipeSpawner.gameStarted)
        {
            // adding points
            score += multiplier * Time.deltaTime;
        }
        // displaying score
        scoreText.text = Mathf.Floor(score).ToString();
    }
    //events called on death
    public void DeathEvents()
    {
        CanvasChanger();
        endGameText.text = scoreText.text;
        hasPlayed = true;
    }
    //switch canvas
    public void CanvasChanger()
    {
        if(gameCanvas.activeSelf)
        {
            gameCanvas.SetActive(false);
            endGameCanvas.SetActive(true);
        }else
        {
            gameCanvas.SetActive(true);
            endGameCanvas.SetActive(false);
        }
    }
    // play again button function
    public void Restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    // Start the game function
    public void ButtonStart()
    {
        pipeSpawner.gameStarted = true;
        Time.timeScale = 1;
        startGamecanvas.SetActive(false);
        gameCanvas.SetActive(true);
        endGameCanvas.SetActive(false);
    }
}
