using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public static GameManager I;

    public Player Player => player;

    private void Awake()
    {
        I = this;
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
