using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public static Upgrade _up;
    public int atkLevel, atkUpPrice;//���ݷ� ���� ����/����
    public int repairPrice, repairTower;
   
    private void Awake()
    {
        _up = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtkUpgrade()
    {

        Tower.tower.money -= atkUpPrice * (atkLevel + 1);
        atkLevel++;
        Atteck.atteck.atk++;
    }
   
    public void RepairTower()
    {
        Tower.tower.money -= repairPrice;
        Tower.tower.towerHP += repairTower;
    }

}
