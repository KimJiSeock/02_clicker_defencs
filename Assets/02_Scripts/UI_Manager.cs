using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager : MonoBehaviour
{

    public Image hpBar,enemyHpBar,enemyHpBar2; //HP �� ǥ��

    public GameObject optionWindow,atkUpWindow,defUpWindow;

    public TextMeshProUGUI moneyTxt,scoreTxt,bulletCountTxt,bulletRecycleTimeText,atkUpPrice,repiarPrice,playTime;

    public Button atkUpBtn, rePairBtn;

    float playTimeCount;
    void Start()
    {
        hpBar.fillAmount = 1;
    }
    void Update()
    {
        playTimeCount += Time.deltaTime;
        HpBarUpdate();
        TextUpdate();
        BtnCheck();
    }

    public void TextUpdate() //�ؽ�Ʈ ����
    {
        moneyTxt.text = "Money : " + Tower.tower.money.ToString(); //�� ���� ��ȭ�� ǥ��
        scoreTxt.text = "Score : " + Tower.tower.score.ToString(); //�� ������ ǥ��
        bulletCountTxt.text = (AtkShoot.atkShoot.bulletObjPool.Count + " / " + AtkShoot.atkShoot.maxBullet).ToString(); //���� źȯ / �ִ�źȯ ǥ��
        bulletRecycleTimeText.text = AtkShoot.atkShoot.timecount.ToString("F1"); //���������� ���� �ð�
        atkUpPrice.text = "Money : -" + Upgrade._up.atkUpPrice.ToString();
        repiarPrice.text = "Money : -" + Upgrade._up.repairPrice.ToString();
        playTime.text = "Time : " + playTimeCount.ToString("N1");
    }
    public void HpBarUpdate() //Hp�� ����
    {
        float a = Tower.tower.towerHP / Tower.tower.towerMaxHP;
        hpBar.fillAmount = a;
    }
    public void Btn_OptionOn()//�ɼ� �� + �Ͻ�����
    {
        optionWindow.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Btn_OptionExit()//�ɼ� ���� + �Ͻ����� ����
    {
        optionWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    public void BtnCheck()
    {
        if (Tower.tower.money < Upgrade._up.atkUpPrice * (Upgrade._up.atkLevel + 1))
        {
            atkUpBtn.interactable = false;
        }
        else atkUpBtn.interactable = true;

        if (Tower.tower.money < Upgrade._up.repairPrice)
        {
            rePairBtn.interactable = false;
        }
        else rePairBtn.interactable = true;
    }

}
