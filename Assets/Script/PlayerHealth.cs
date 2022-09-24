using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public static float damage;

    private float health;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        damage = 0f;
        health = 100f;
        healthBarSlider = GetComponent<Slider>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>();
            }
            if (gameControllerObject = null)
            {
            Debug.Log("Cannot find 'GameController' script");
            }
    }
    public void DecreaseHealth(int newDamageValue)
    {
        damage = newDamageValue;
        health -= newDamageValue;
        if (health < 1)
        {
            Destroy(gameObject);
            gameController.GameOver();
        }
    }
    void ShowHealthBar()
    {
        healthBarSlider.value = 1 - damage / 100;
    }
}
