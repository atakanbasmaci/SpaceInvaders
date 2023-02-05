using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    private int enemyCounter = 0;
    [SerializeField] private Text enemyCounterText;
    // Start is called before the first frame update

    public void UpdateEnemyUI()
    {
        enemyCounter++;

        enemyCounterText.text = enemyCounter + " x";
    }
}
