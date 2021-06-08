using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerManager player;
    public PlayerManager Player => player;

    public static GameManager Instance;

    public bool isPaused;

    [SerializeField] private bool debugDisplay;
    [SerializeField] private GameObject debugCanvas;

    public List<CraftingRecipe> craftingRecipes;
    public List<GateSO> craftedGates;


    private void Awake()
    {
        Instance = this;
        if (debugDisplay) debugCanvas.SetActive(true);
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
