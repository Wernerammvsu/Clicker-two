using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Game : MonoBehaviour
{
    private Save sv = new Save();
    public Text scoreText;
    private int score=0;
    private int bonus = 0;
    [Header("Shop")]
    public GameObject shopPanel;
    public int[] shopCosts;
    public int[] shopBonus;
    public Text[] shopButtonText;
    public Button[] shopButtons;
    int num = 0;
    private int countPowerUp, nectarBonus = 1;  //колличество купленных улучшений
    public float[] bonusTime;
    public void shopPanelAction() //Скрывает панель магазина
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void shopButton_fairy(int index) //addBobus пыльца феи
    {
        if (score >= shopCosts[index] )
        { 
        bonus += shopBonus[index];
        score -= shopCosts[index];
            shopBonus[index] *= 2;
            shopCosts[index] *= 2;
            num++;
            shopButtonText[index].text = "buy fairy's pollen \n" + shopCosts[index];
        }
        else
        {
            Debug.Log("Insufficient funds");
        }
    }
    public void ClickHere()  //OnClick при нажатии увеличивает счёт
    {
        score += 1+bonus;
        
    }

    IEnumerator BonusPerSec()
    {
        while(true)
        {
            score += (countPowerUp * nectarBonus);
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator nectarTime(float time, int index)
    {
        shopButtons[index].interactable = false;
        if (index == 0)
        {
            nectarBonus *= 10;
            yield return new WaitForSeconds(time);
            nectarBonus /= 10;
        }
        shopButtons[index].interactable = true;
    }
    public void BuyPowerUp(int index)
    {
        if (score >= shopCosts[index])
        {
            countPowerUp++;
            score -= shopCosts[index];
        }
        else
        {
            Debug.Log("Insufficient funds");
        }
    }
    public void startBonusTimer(int index) //старт бонуса от нектара
    {
        StartCoroutine(nectarTime(bonusTime[index], index));
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BonusPerSec());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:  " + score;
    }
    private void OnApplicationQuit()
    {
        sv.score = score;
        sv.levelOfScore = new int[num];
        PlayerPrefs.SetString("sv", JsonUtility.ToJson(sv));
    }
}
[Serializable]
public class Save
{
    public int score;
    public int[] levelOfScore;
}