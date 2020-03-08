using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text scoreText;
    private int score=0;
    public GameObject shopPanel;

    public void shopPanelAction()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void ClickHere() {
        score += 1;
        scoreText.text = "Score:  " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
