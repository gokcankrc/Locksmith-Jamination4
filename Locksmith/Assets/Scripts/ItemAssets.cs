using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite objectASprite;
    public Sprite objectBSprite;
    public Sprite objectCSprite;
    public Sprite objectDSprite;
    public Sprite objectESprite;
    public Sprite objectFSprite;
    public Sprite objectGSprite;
    public Sprite objectHSprite;

}
