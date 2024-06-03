using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is currently completely useless,
// and does not serve a real function at the moment at all.
// This would have been used for spawning in enemies
// at an increasing rate.
// This does satisfy some requirements but unfortunately 
// it does not really hold much of a purpouse for the game.
// This would have been the backbone for the difficulty scaling
// with the player.

public class GM_AI : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;

    private float basicEnemyCost = 20;
    private float heavyEnemyCost = 60;


    public int Difficulty = 0; //Game Diffiulty as a whole, selected in menu
    private double BossPointScaling; //Factor by which points are multiplied by (UPPON BOSS FIGHT)
    
    public float GMPointTimer = 5f;     //TIMER when the GameMasterAI(GMAI) gets points
    public float GMSpendingTimer = 7f;  //TIMER when the GMAI starts spending points
    public float DifficultyScaling;     //TIMER "more time = more difficulty" time frame
    
    private double DifficultyStage = 1; //what ups the difficulty after the timeframe

    private double[] PointSelection = {10,12,13,14,15}; //raw point score amount that can be given, array for variation
    private double selectedPointAmount; //raw amount of points selected for the GMAI

    private double CurrentPoints; //the current amount of points that the GMAI has

    private void Start()
    {
        // Start the coroutines to run the timers independently
        StartCoroutine(RunTimer1());  //Timer for when GameMasterAI gets points
        StartCoroutine(RunTimer2());  //Timer for when GameMasterAI gets points
        StartCoroutine(RunTimer3());  //Timer for when Difficulty scales

        if(Difficulty == -1)        //Difficulty Level 1
        {
            BossPointScaling = .8;         //Factor by which points are multiplied by
            DifficultyScaling = 150;    //"more time = more difficulty" time frame
        }

        if(Difficulty == 0)         //Difficulty Level 2
        {
            BossPointScaling = 1;          //Factor by which points are multiplied by
            DifficultyScaling = 120;    //"more time = more difficulty" time frame
        }

        if(Difficulty == 1)         //Difficulty Level 3
        {
            BossPointScaling = 1.2;        //Factor by which points are multiplied by
            DifficultyScaling = 90;    //"more time = more difficulty" time frame
        }

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.T))
        {
            display();
        }
    }

    IEnumerator RunTimer1()
    {
        while (true)
        {
            yield return new WaitForSeconds(GMPointTimer);
            GivePoints();
        }
    }

    IEnumerator RunTimer2()
    {
        while (true)
        {
            yield return new WaitForSeconds(GMSpendingTimer);
            SpendPoints();
            SpendPoints();
            SpendPoints();
            SpendPoints();
        }
    }

    IEnumerator RunTimer3()
    {
        while (true)
        {
            yield return new WaitForSeconds(DifficultyScaling);
            Function3();
        }
    }

    void GivePoints()
    {
        int randomPosition = Random.Range(0, 5); //Retrieve an array item at a fixed position (0 to 4)

        double selectedPointValue = PointSelection[randomPosition];  //Retrieve the point value at the random index

        CurrentPoints += selectedPointValue * DifficultyStage; //Give points based on other difficulty values
        Debug.Log("Function1 called. Points given.");
    }

    void SpendPoints()
    {
        //Randomises positions for spawns
        int randomSpawn = Random.Range(0, 4);
        GameObject selectedSpawn = null;
        switch (randomSpawn)
        {
        case 0:
            selectedSpawn = Spawn1;
            break;
        case 1:
            selectedSpawn = Spawn2;
            break;
        case 2:
            selectedSpawn = Spawn3;
            break;
        case 3:
            selectedSpawn = Spawn4;
            break;
        }

        if(CurrentPoints > heavyEnemyCost)
        {
            return;
        }

        //Code to spend points
        if(CurrentPoints > basicEnemyCost)
        {
            Instantiate(EnemyPrefab, selectedSpawn.transform.position, transform.rotation);
            CurrentPoints -= basicEnemyCost;
        }
        Debug.Log("Function2 called. Enamies Spawned");
    }

    void Function3()
    {
        DifficultyStage += .1;
        Debug.Log("Function3 called.");
    }

    void display()
    {
        Debug.Log("Current points:" + CurrentPoints);
    }
}
