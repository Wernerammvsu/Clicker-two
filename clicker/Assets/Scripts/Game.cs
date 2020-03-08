using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text scoreText;
    private int score=0;
    private int bonus = 1;
    [Header("Shop")]
    public GameObject shopPanel;
    public int[] shopCosts;
    public int[] shopBonus;
    public Text[] shopButtonText;
    public void shopPanelAction()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void shopButton_fairy(int index)
    {
        if (score >= shopCosts[0])
        { 
        bonus += shopBonus[index];
        score -= shopCosts[index];
            shopBonus[index] *= 2;
            shopCosts[index] *= 2;
            shopButtonText[index].text = "buy fairy's pollen \n" + shopCosts[index];
        }
        else
        {
            Debug.Log("Insufficient funds");
        }
    }
    public void ClickHere() {
        score += 1+bonus;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:  " + score;
    }
}
