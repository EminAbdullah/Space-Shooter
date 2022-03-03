using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject Astroid;
    public int TotalMeteor;
    public float meteorSpawnTime;

    public Text scoreText;
    public Text gameOverText, restartText,quitText;
    public int score;

    private bool gameOver, restart,quit;

    void SpawnValues()
    {
        StartCoroutine(RandomSpawn());

    }
    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        quit = false;
        gameOver = false;
        restart = false;
        SpawnValues();
    }
    void Update()
    {
        if (restart == true && Input.GetKeyDown(KeyCode.R))
        {
        
            SceneManager.LoadScene("SampleScene");
            
        }
        if (quit==true && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    IEnumerator RandomSpawn()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            
            for (int i = 0; i < TotalMeteor; i++)
            {
                
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(Astroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(meteorSpawnTime);
                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    quitText.text = "Press 'Q' for Quit";
                    quit = true;
                    restart = true;
                    break;
                    
                }
            }
            if (gameOver)
            {
                break;
            }
            yield return new WaitForSeconds(3);
        }
      
    }
    public void Score()
    {
        score+=10;
        scoreText.text = "SCORE : " + score.ToString();

    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }
  
}
