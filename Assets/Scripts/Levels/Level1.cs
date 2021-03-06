﻿using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {

    //Record de valores
    public static float HighScore;
    public static int eneCount;
    public bool finish;
    private float tmp;
    
    private int _enemyPick;

    public GameObject en1, en2, en3;
    
    private int NextEnemySpawnTime = 0;
    private int EnemySpawnRate = 5;

    private void Start()
    {
        gameManager.setMultiply(Levels.One);
        Picker();
        NextEnemySpawnTime = (int)Time.time + EnemySpawnRate;
        
    }

    void Update()
    {
        tmp = UIManager.scoreNumber;
        gameManager.scTemp = tmp;
        
        if((int)Time.time == NextEnemySpawnTime){
 
            Picker();
            NextEnemySpawnTime = (int)Time.time + EnemySpawnRate;
        }

        if (eneCount >= 20)
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        Level2.blocked = false;
        if (HighScore == 0)
        {
            HighScore = tmp;
            UIManager.scoreNumber = 0;
            
        }else if (tmp > HighScore)
        {
            HighScore = tmp;
            UIManager.scoreNumber = 0;
        }
        else
        {
            UIManager.scoreNumber = 0;
        }

        gameManager.lvlPass = true;
    }

    private void Picker() {
        _enemyPick = UnityEngine.Random.Range(0, 3);

        switch (_enemyPick) {
            case 0:
                spawnEnemy(en1);
                break;
            case 1:
                spawnEnemy(en2);
                break;
            case 2:
                spawnEnemy(en3);
                break;
        }
    }

    public void spawnEnemy(GameObject enemy)
    {

        Vector2 bottom = new Vector2(10f, -4.3f);
        Vector2 top = new Vector2(10f, 4.3f);

        GameObject oneEnemy = (GameObject)Instantiate(enemy);
        oneEnemy.transform.position = new Vector2(top.x, UnityEngine.Random.Range(top.y, bottom.y));

        nextEnemy();
    }

    public void nextEnemy()
    {
        int nextTime = UnityEngine.Random.Range(1000, 0);
    }


}
