using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerEntity player;
    public PlayerEntity Player => player;

    public static GameManager Instance;
    public static bool PlayerAlive => Instance.player != null;

    public bool isPaused;

    [SerializeField] private bool debugDisplay;
    [SerializeField] private GameObject debugCanvas;

    public bool resetCraftedGatesOnStart;
    public bool resetInventoryOnStart;
    
    public List<CraftingRecipe> craftingRecipes;
    public List<GateSO> craftedGates;


    private void Awake()
    {
        Instance = this;
        if (debugDisplay) debugCanvas.SetActive(true);
    }

}
