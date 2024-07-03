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
    

    public int maxBullet; //�� źȯ �ִ� ��������
    public float reRoadTime;// źȯ ����� �ð�
    public float timecount = 0f;// ����� �ʱ�ȭ�� ����

    public List<GameObject> bulletObjPool;
    public List<GameObject> recycleBullet;
    private void Awake()
    {
        atkShoot = this;
    }
    void Start()
    {
        bulletObjPool = new List<GameObject>();
        for(int i = 0; i < maxBullet; i++)//������ƮǮ������ źȯ ����
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
        if (Input.GetMouseButtonDown(0)) //Ŭ�� ���� ���
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)// UI�� �ƴ� ȭ���� Ŭ�� ��
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
                else Debug.Log("źȯ ����!");

            }
        }
    }

    void ReRoadBullet()//źȯ�� ������
    {//������ƮǮ������ ������ źȯ�� �ٸ� ����Ʈ�� ��� �����̸� �ְ� ���� ����Ʈ�� �Ѱܼ� źȯ �����
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
    


