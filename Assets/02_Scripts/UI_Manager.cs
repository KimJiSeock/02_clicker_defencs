using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager : MonoBehaviour
{

    public Image hpBar,enemyHpBar,enemyHpBar2; //HP 바 표시

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

    public void TextUpdate() //텍스트 갱신
    {
        moneyTxt.text = "Money : " + Tower.tower.money.ToString(); //내 현제 재화의 표시
        scoreTxt.text = "Score : " + Tower.tower.score.ToString(); //내 점수의 표시
        bulletCountTxt.text = (AtkShoot.atkShoot.bulletObjPool.Count + " / " + AtkShoot.atkShoot.maxBullet).ToString(); //현제 탄환 / 최대탄환 표시
        bulletRecycleTimeText.text = AtkShoot.atkShoot.timecount.ToString("F1"); //재장전까지 남은 시간
        atkUpPrice.text = "Money : -" + Upgrade._up.atkUpPrice.ToString();
        repiarPrice.text = "Money : -" + Upgrade._up.repairPrice.ToString();
        playTime.text = "Time : " + playTimeCount.ToString("N1");
    }
    public void HpBarUpdate() //Hp바 갱신
    {
        float a = Tower.tower.towerHP / Tower.tower.towerMaxHP;
        hpBar.fillAmount = a;
    }
    public void Btn_OptionOn()//옵션 온 + 일시정지
    {
        optionWindow.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Btn_OptionExit()//옵션 오프 + 일시정시 해제
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
