using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Vector3 spawnValue;
    public GameObject hazard;
    public GameObject hazard2;
    public GameObject hazard3;
    public float spawnWait;
    public float spawnWait2;
    public float spawnWait3;
    public float waveWait;

    private float waveNumber;
    private int hazardCount;
    private int hazardCount2;
    private int hazardCount3;
    void Start()
    {
        new WaitForSeconds(20); //Menunggu sebelum mulai. Kalau mau pakai tombol saja, pakai 'public void WaveStart()', lalu atur di tombolnya.
        StartCoroutine(SpawnWaves());
    }
    void Update()
    {
        //Untuk sementara, ini tidak dipakai.
    }

    IEnumerator SpawnWaves()
    {
        waveNumber = 1;
        hazardCount = (int)waveNumber; //Berapa musuh mau muncul. Untuk sementara, jumlahnya sesuai nomor wave.
        hazardCount2 = (int)waveNumber - 1; //-1 berarti muncul di wave 2. -2 berarti muncul di wave 3. -3 berarti muncul di wave 4. dst.
        hazardCount2 = (int)waveNumber - 4;
        //Kalau suatu saat jumlah musuh tidak nambah pada wave berikutnya, scriptnya beda. Gunakan 'if (waveNumber > (nomor wave - 1)) {hazardCount = (angka)}'. Panggil Aku (Neckar) kalau ada masalah.
        if (waveNumber > 14) //Game selesai pada wave 15. Bisa diganti.
        {
            hazardCount = 0;
            hazardCount2 = 0;
            hazardCount3 = 0;
            new WaitForSeconds(500); // Saya belum tahu cara menghentikan game ketika musuh terakhir mati. Untuk sementara pakai ini.
            //Saya belum tahu cara menghentikan game.
        }
        for (int i = 0; i < hazardCount; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValue.x, spawnValue.y, spawnValue.z);
            //Ini muncul dari satu tempat. Kalau mau lebih random di axis x, gunakan 'Random.Range(-spawnValue.x, spawnValue.x)'. Sama untuk z.
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait); //tunggu hingga fungsi ini mulai lagi.
        } //ini semua untuk jenis musuh pertama.
        for (int i = 0; i < hazardCount2; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValue.x, spawnValue.y, spawnValue.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait2); // tunggu hingga fingsi ini mulai lagi khusus untuk musuh kedua.
        } //ini semua untuk jenis musuh kedua.
        for (int i = 0; i < hazardCount3; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValue.x, spawnValue.y, spawnValue.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait3); // tunggu hingga fingsi ini mulai lagi khusus untuk musuh ketiga.
        } //ini semua untuk jenis musuh ketiga.
        yield return new WaitForSeconds(waveWait);

        //PENTING!!! Semua 'for' akan dilakukan secara bergantian, jadi jenis musuh pertama muncul dulu, lalu jenis kedua, dst.
        //Saya kurang tahu bila ada cara gampang, jadi sementara coba pakai script berbeda untuk setiap musuh.
        //Untuk script berbeda, gunakan 'waveWait' yang berbeda dan atur supaya kompak.

        waveNumber++; //Wave berikutnya.
    }
}
