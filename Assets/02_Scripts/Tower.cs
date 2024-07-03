using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public static Tower tower;
    
    public float towerMaxHP = 100;
    public float towerHP;
    public float enemyMaxHP = 2f;

    public int money;
    public int score;

    public int levelPlusTime=10;

    private void Awake()
    {
        tower = this;
    }
    void Start()
    {
        towerHP = towerMaxHP;
    }
    void Update()
    {
        HpCheck();
        GameLvPlus();
        //GameOver();
    }

    void GameLvPlus()
    {
        float timecount = 0;
        timecount += Time.deltaTime;
        if (timecount >= levelPlusTime)
        {
            enemyMaxHP *= 2;
            timecount = 0;
        }
    }
    void GameOver()
    {
        if(towerHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    void HpCheck()
    {
        if(towerHP > towerMaxHP)
        {
            towerHP = towerMaxHP;
        }
    }
   
}
