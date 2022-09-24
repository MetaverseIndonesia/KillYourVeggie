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
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        updateScore();
        new WaitForSeconds(20); //Menunggu sebelum mulai. Kalau mau pakai tombol saja, pakai 'public void WaveStart()', lalu atur di tombolnya.
        StartCoroutine(SpawnWaves());
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
                hazardCount = (int)waveNumber; //Berapa musuh mau muncul. Untuk sementara, jumlahnya sesuai nomor wave.
                hazardCount2 = (int)waveNumber - 1; //-1 berarti muncul di wave 2. -2 berarti muncul di wave 3. -3 berarti muncul di wave 4. dst.
                hazardCount3 = (int)waveNumber - 4;
                //Kalau suatu saat mau jumlah musuh tidak nambah pada wave berikutnya, scriptnya beda. Gunakan 'if (waveNumber > (nomor wave - 1)) {hazardCount = (angka)}'. Panggil Aku (Neckar) kalau ada masalah.
                if (waveNumber > 14) //Game selesai pada wave 15. Bisa diganti.
                {
                    hazardCount = 0;
                    hazardCount2 = 0;
                    hazardCount3 = 0;
                    new WaitForSeconds(180); // Saya belum tahu cara menghentikan level ketika musuh terakhir mati. Untuk sementara pakai ini.
                                             //Saya belum tahu cara menghentikan game.
                    level = 2;
                }
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(spawnValue.x, spawnValue.y, spawnValue.z);
                    //Ini muncul dari satu tempat. Kalau mau lebih random di axis x, gunakan 'Random.Range(-spawnValue.x, spawnValue.x)'. Sama untuk z.
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }

                for (int i = 0; i < hazardCount2; i++)
                {
                    Vector3 spawnPosition = new Vector3(spawnValue2.x, spawnValue2.y, spawnValue2.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard2, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait2);
                }

                for (int i = 0; i < hazardCount3; i++)
                {
                    Vector3 spawnPosition = new Vector3(spawnValue3.x, spawnValue3.y, spawnValue3.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard3, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait3);
                }
                yield return new WaitForSeconds(waveWait);

                //PENTING!!! Semua 'for' akan dilakukan secara bergantian, jadi jenis musuh pertama muncul dulu, lalu jenis kedua, dst.
                //Saya kurang tahu bila ada cara gampang, jadi sementara coba pakai script berbeda untuk setiap musuh.
                //Untuk script berbeda, gunakan 'waveWait' yang berbeda dan atur supaya kompak.

                waveNumber++; //Wave berikutnya.
            }
            waveNumber = 1;
            while (level == 2)
            {
                //tambahkan script level 2 disini. Copy-Paste kalau mau sama.
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
    //private GameController gameController;
    //
    // void Start()
    //{
    //    GameObject gameControllerObject = GameObject.FindWithTag("GameController");       //Kalau script ini dipakai di playernya, tagnya ganti supaya sama. Kalau mau gampang, tambah 'empty object' dan tagnya 'GameController'
    //    if (gameControllerObject != null)
    //    {
    //        gameController = gameControllerObject.GetComponent<GameController>();
    //    }
    //    if (gameControllerObject = null)
    //    {
    //    Debug.Log("Cannot find 'GameController' script");
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //   if (other.tag == "Player")
    //    {
    //        gameController.GameOver();
    //    }
    //    gameController.Addscore(scoreValue);
    //}
}