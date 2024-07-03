using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    Animator anim;
    Rigidbody2D enemyRb;
    float atkDelay = 2f; //���� ���ݼӵ�
    float timecount = 0; //���ݽð� üũ�� ����
    public float enemySpeed; //���� �̵� �ӵ�
    public float enemyHpCount;// ���� ���� Hp �ǰ� �� �����Ǵ� ��ġ
    //public int enemyHp; //���� �ִ� Hp ���׷��̵�� �����Ǵ� ��ġ
    public bool enemyHitCount; //�ǰ� ���� ������ ���� ����

    Image hpbar;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyHpCount = Tower.tower.enemyMaxHP;
        anim = GetComponent<Animator>();

    }
   
    // Update is called once per frame
    void Update()
    {
        EnemyMove();
   
        EnemyDestroy();
    }
    void EnemyMove()
    {
        if (enemyHitCount == false)
        {
            enemyRb.velocity = Vector2.left * enemySpeed * Time.deltaTime;

        }
         else StartCoroutine(EnemyRemove());
    }
    void EnemyDestroy()
    {
        if(enemyHpCount <= 0)
        {
            Tower.tower.money += 100;
            Tower.tower.score += ((int)Tower.tower.enemyMaxHP * 10);
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Contains("Bullet"))
        {
            Debug.Log("���� ����");

            enemyHpCount -= Atteck.atteck.atk;
            enemyHitCount = true;
            anim.SetTrigger("Hit");
            enemyRb.AddForce(Vector2.right * enemySpeed * Time.deltaTime, ForceMode2D.Impulse);

            //AtkShoot.atkShoot.bulletObjPool.Add(collision.gameObject);
            collision.rigidbody.velocity = Vector2.zero;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name.Contains("Tower"))
        {
            OnEnemyAtteck();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Tower"))
        {
            OnEnemyAtteck();
        

        }
    }

   
    private void OnEnemyAtteck()
    {
            timecount += Time.deltaTime;

            if(timecount > atkDelay)
            {
                Debug.Log("���� ��");
                anim.SetTrigger("Atk");
                Tower.tower.towerHP -= enemyHpCount;
                timecount = 0;
            }
        
    }

    IEnumerator EnemyRemove()
    {
        
        yield return new WaitForSeconds(0.04f);
        enemyHitCount = false;
        
    }
    

}
