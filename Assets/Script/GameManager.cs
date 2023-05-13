using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int enemiesCount = 0;
    private int playerUnitCount = 0;

    [SerializeField] private TextMeshProUGUI gameOverText; 

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        playerUnitCount = GameObject.FindGameObjectsWithTag("Player").Length;

        if (enemiesCount == 0)
        {
            GameOver("You Win!");
        }
        else if (playerUnitCount == 0)
        {
            GameOver("You Lose!");
        }
    }

    private void Unit_OnAnyUnitDead(object sender, System.EventArgs e)
    {
        Unit unit = sender as Unit;
        if (unit.IsEnemy())
        {
            enemiesCount--;
        }
        else
        {
            playerUnitCount--;
        }
        Debug.Log("GameManager::Unit_OnAnyUnitDead() enemiesCount=" + enemiesCount + " playerUnitCount=" + playerUnitCount);
    }

    private void GameOver(string text)
    {
        gameOverText.text = text;
        gameOverText.gameObject.SetActive(true);
    }
}
