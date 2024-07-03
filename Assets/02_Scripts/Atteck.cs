using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atteck : MonoBehaviour
{
    public static Atteck atteck;
    Rigidbody2D atkRb;


    public int atk = 1;

    private void Awake()
    {
        atteck = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        atkRb = GetComponent<Rigidbody2D>();
      

    }

    // Update is called once per frame
    void Update()
    {
            AtkMove();
    }

    void AtkMove() //포탄이 날아가는 함수
    {

        if (atkRb.velocity.x == 0) //x축 벨로시티가 0이면 날아가게
        {
            float aX = Mathf.Abs(AtkShoot.atkShoot.transform.position.x - AtkShoot.atkShoot.atkVector.x);
            float aY = Mathf.Clamp(AtkShoot.atkShoot.atkVector.y, 0f, 10f);


            atkRb.AddForce(new Vector2(aX, aY * 2.3f), ForceMode2D.Impulse);
        }
       
    }

}
