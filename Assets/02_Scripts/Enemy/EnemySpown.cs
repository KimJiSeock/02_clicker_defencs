using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{

    public GameObject enemyGround;
    public GameObject enemySky;
    public GameObject spownSpotGround;
    public GameObject spownSpotSky;

    public float spownTime;
    public int levelPlusTime = 10;
    public float enemyMaxHP = 2f;
    void Start()
    {
        StartCoroutine(OnEnemySpown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemySpownCount()
    {
        int ranA = Random.Range(0, 10);
        if (ranA < 8)
        {
            GameObject spawnEnemy = Instantiate(enemyGround, spownSpotGround.transform.position, Quaternion.identity);
            spawnEnemy.GetComponent<Enemy>().enemyHpCount = enemyMaxHP;
            Instantiate(spawnEnemy);
        }
        else
        {
            GameObject spawnEnemy = Instantiate(enemySky, spownSpotSky.transform.position, Quaternion.identity);
            spawnEnemy.GetComponent<Enemy>().enemyHpCount = enemyMaxHP;
            Instantiate(spawnEnemy);
        }
        
    }

    IEnumerator OnEnemySpown()
    {
        while(true)
        {
            EnemySpownCount();
            yield return new WaitForSeconds(spownTime);
        }

    }

}
