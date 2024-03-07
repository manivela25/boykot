using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject[] Hazard;
    public int SpawnCount;
    public float SpawnWait;
    public float StartSpawn;
    public float WaveWait;

    public Text ScoreText;
    public Text GameOverText;
    public Text RestartText;
    public Text QuitText;
    public int Score;

    private bool GameOver;
    private bool Restart;

    void Update()
    {
        if (Restart == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Application.Quit();
            }
        }
    }
    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(StartSpawn);
        while (true)
        { 
            
            for (int i = 0; i < SpawnCount; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion SpawnRotation = Quaternion.identity;
                //Coroutine
                //1.IEnumerator döndürmek zorundadır.
                //2. En az 1 adet yeild ifadesi bulunmak zorundadır.
                //3.Coroutinler çağırlırken mutlaka StartCorountine metoduyla çağrılmalıdır.

                Instantiate(Hazard[Random.Range(0,Hazard.Length)], SpawnPosition, SpawnRotation);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
            if (GameOver == true)
            {
                RestartText.text = "Tekrar denemek için 'T' ye basınız";
                QuitText.text = "Çıkmak için 'C' ye basınız";
                Restart = true;
                break;
            }
        }
    
    }
    public void UpdateScore()
    {
        Score += 10;
        ScoreText.text = "Yok edilen: " + Score;
    }
    public void gameOver()
    {
        GameOverText.text = "Oyun Bitti";
        GameOver = true;
    }
    void Start()
    {
        
        GameOverText.text = "";
        RestartText.text = "";
        QuitText.text = "";
        GameOver = false;
        Restart = false;
        StartCoroutine(SpawnValues());
    }

 
}
