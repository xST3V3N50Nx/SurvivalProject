using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    private float health, thirst, hunger;

    public bool playerDead;
    //Functions
    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {

        //Thirst and Hunger increase
        if(!playerDead)
        {
            thirst += thirstIncreaseRate * Time.deltaTime;
            hunger += hungerIncreaseRate * Time.deltaTime;
        }

        //Change to reduce HP over time
        if (thirst >= maxThirst)
            Die();
        if (thirst >= maxHunger)
            Die();

    }

    public void Die()
    {
        //Player Death Event(Change to HP)
        playerDead = true;
        print("You Have Died From Malnutrition");
    }

}
