using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AtkShoot : MonoBehaviour
{
    public static AtkShoot atkShoot;
    public GameObject prefebAtk;
    // Start is called before the first frame update
    public Vector2 atkVector;
    

    public int maxBullet; //내 탄환 최대 소지수량
    public float reRoadTime;// 탄환 재생성 시간
    public float timecount = 0f;// 재생성 초기화용 변수

    public List<GameObject> bulletObjPool;
    public List<GameObject> recycleBullet;
    private void Awake()
    {
        atkShoot = this;
    }
    void Start()
    {
        bulletObjPool = new List<GameObject>();
        for(int i = 0; i < maxBullet; i++)//오브젝트풀링으로 탄환 생성
        {
            GameObject bullet = Instantiate(prefebAtk);
            bulletObjPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        AtkCreate();
        ReRoadBullet();
       
    }

    public void AtkCreate()
    {
        if (Input.GetMouseButtonDown(0)) //클릭 했을 경우
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)// UI가 아닌 화면을 클릭 시
            {
                atkVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (bulletObjPool.Count > 0)
                {
                    GameObject bullet = bulletObjPool[0];
                    GameObject reBullet = bullet;
                    bullet.SetActive(true);
                    bulletObjPool.Remove(bullet);
                    recycleBullet.Add(bullet);

                    bullet.transform.position = transform.position;
                }
                else Debug.Log("탄환 부족!");

            }
        }
    }

    void ReRoadBullet()//탄환의 재장전
    {//오브젝트풀링으로 생성된 탄환을 다른 리스트에 담고 딜레이를 주고 원래 리스트로 넘겨서 탄환 재생성
        if(bulletObjPool.Count < maxBullet)
        {
            timecount -= Time.deltaTime;
            if(timecount <= 0)
            {
                bulletObjPool.Add(recycleBullet[0]);
                recycleBullet.Remove(recycleBullet[0]);
                timecount = reRoadTime;
            }
        }
    }
}
    


