using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text countdownText;
    public Text countLossText;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    float currentTime = 0f;
    float startingTime = 10f;

    private Mover mover;
    private BGScroller scroller;

    private bool gameOver;
    private bool restart;
    public bool timing = false;
    private bool win = false;
    public int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        countdownText.text = "";
        countLossText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        currentTime = startingTime;
    }

    void Update()
    {
        //currentTime -= 1 * Time.deltaTime;

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                SceneManager.LoadScene("SampleScene");

            }

        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.F))
        {
            //waveWait = waveWait * 0.1;
            //hazardCount = hazardCount * 5;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            timing = true;
            Debug.Log("Timing is now true");

            

            if (timing == true)
            {
                currentTime -= 1 * Time.deltaTime;
                //Debug.Log("-1");
                countdownText.text = currentTime.ToString("0");
                //Debug.Log("going");

                if (currentTime <= 0)
                {
                    currentTime = 0;
                    GameOver();
                    countLossText.text = "You gambled with your time and lost!";
                    audioSource.clip = clip2;
                    audioSource.Play();
                }

            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            timing = false;
            Debug.Log("Timing is now false");
        }


    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while(true){

            for (int i = 0; i < hazardCount; i++){

                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {

                restartText.text = "Press 'U' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;

        if(score >= 100)
        {
            winText.text = "You Win! Game made by Nick Hennessy";
            gameOver = true;
            restart = true;
            audioSource.clip = clip;
            audioSource.Play();
            win = true;
            countdownText.text = "";
            
        }

        if(gameOver == true && score < 100)
        {
            audioSource.clip = clip2;
            audioSource.Play();

        }
    }

    public void GameOver()
    {
        if (win == false)
        {
            gameOverText.text = "Game Over! Made by Nick Hennessy";
        }
        gameOver = true;
    }

//Made by Nick Hennessy
}
