using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    private int _amount;

    void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _amount = EnemyManager.I.CurrentlyActiveEnemies.Count();
        _tmp.text = "Enemy amount: " + _amount;
        _tmp.text += "\n Enemy spawner: " + EnemyManager.I.gameObject;;
    }
}
