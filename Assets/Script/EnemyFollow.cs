using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public int scoreValue;
    public int damageValue;
    private GameController gameController;
    private PlayerHealth playerHealth;
    void Start()
    {
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");       //Kalau script ini dipakai di playernya, tagnya ganti supaya sama. Kalau mau gampang, tambah 'empty object' dan tagnya 'GameController'
            GameObject playerHealthObject = GameObject.FindWithTag("Player");
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>();
            }
            if (gameControllerObject = null)
            {
            Debug.Log("Cannot find 'GameController' script");
            }
            if (playerHealthObject != null)
            {
                playerHealth = playerHealthObject.GetComponent<PlayerHealth>();
            }
            if (playerHealthObject = null)
            {
            Debug.Log("Cannot find 'PlayerHealth' script");
            }
    }
    void Update()
    {
        enemy.SetDestination(Player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            playerHealth.DecreaseHealth(damageValue);          //Ini menggunakan public float. Nanti damage-nya diganti di Unity.
            new WaitForSeconds(0.5f);
        }
    }
}
