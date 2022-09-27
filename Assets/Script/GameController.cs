using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValue;
    public Vector3 spawnValue2;
    public Vector3 spawnValue3;
    public GameObject hazard;
    public GameObject hazard2;
    public GameObject hazard3;
    public float spawnWait;
    public float spawnWait2;
    public float spawnWait3;
    public float waveWait;
    public Text scoretext;
    public Text restartText;
    public Text gameOverText;

    private float waveNumber;
    private float level;
    private int hazardCount;
    private int hazardCount2;
    private int hazardCount3;
    private bool gameOver;
    private bool restart;
    private int score;
    void Start()
    {
        new WaitForSeconds(20); //Menunggu sebelum mulai. Kalau mau pakai tombol saja, pakai 'public void WaveStart()', lalu atur di tombolnya.
        StartCoroutine(SpawnWaves());
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        updateScore();
    }
    void Update()
    {
        //Untuk sementara, ini tidak dipakai.
    }

    IEnumerator SpawnWaves()
    {
        level = 1;
        waveNumber = 1;
        while (true)
        {
            while (level == 1)
            {
                hazardCount = (int)waveNumber;
                hazardCount2 = (int)waveNumber - 2;
                if (waveNumber == 5)
                {
                    Vector3 spawnPosition = new Vector3(476.45f, 30.93f, 510.8f);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard3, spawnPosition, spawnRotation);

                }
                if (waveNumber > 5) //Game selesai pada wave 5
                {
                    hazardCount = 0;
                    hazardCount2 = 0;
                    hazardCount3 = 0;
                    new WaitForSeconds(20);
                    level = 2;
                }
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(480f, 550f), 0, 470f);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }

                for (int i = 0; i < hazardCount2; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(480f, 550f), 0, 550f);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard2, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait2);
                }

                yield return new WaitForSeconds(waveWait);

                waveNumber++; //Wave berikutnya.
            }
            if (gameOver)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }
    }
    void updateScore()
    {
        scoretext.text = "Score " + score;
    }
    public void Addscore(int newscorevalue)
    {
        score += newscorevalue;
        updateScore();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    //PENTING!!! Di script musuh ketika mati, tambahkan ini:
    //
    //
    //public int scoreValue;
    //public int damageValue;
    //private GameController gameController;
    //private GameController playerHealth;
    //
    // void Start()
    //{
    //    GameObject gameControllerObject = GameObject.FindWithTag("GameController");       //Kalau script ini dipakai di playernya, tagnya ganti supaya sama. Kalau mau gampang, tambah 'empty object' dan tagnya 'GameController'
    //    GameObject playerHealthObject = GameObject.FindWithTag("Player");
    //    if (gameControllerObject != null)
    //    {
    //        gameController = gameControllerObject.GetComponent<GameController>();
    //    }
    //    if (gameControllerObject = null)
    //    {
    //    Debug.Log("Cannot find 'GameController' script");
    //    }
    //    if (playerHealthObject != null)
    //    {
    //        playerHealth = playerHealthObject.GetComponent<GameController>();
    //    }
    //    if (playerHealthObject = null)
    //    {
    //    Debug.Log("Cannot find 'PlayerHealth' script");
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //   if (other.tag == "Player")
    //    {
    //        gameController.DecreaseHealth(damageValue);           //Ini menggunakan public float. Nanti damage-nya diganti di Unity.
    //        new WaitForSeconds(0,5f);
    //    }
    //    gameController.Addscore(scoreValue);                      //Tambahkan ini kalau musuhnya mati. Aku taruh ini disini sementara, berati ketika kena apapun, akan kasih nilai. Bagusnya pakai 'if () {}'.
    //}
}