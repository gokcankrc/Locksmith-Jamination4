using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private Color friendHitColor;
    [SerializeField] private Color enemyHitColor;
    [SerializeField] private Color friendHealColor;
    [SerializeField] private Color enemyHealColor;
    [SerializeField] private Color expGainColor;
    // [SerializeField] public float outlineWidth;
    // [SerializeField] public Color outlineColor;
    
    public static Color FriendHitColor;
    public static Color EnemyHitColor;
    public static Color FriendHealColor;
    public static Color EnemyHealColor;
    public static Color ExpGainColor;
    // public static float OutlineWidth;
    // public static Color OutlineColor;
    
   
    public static PopUpManager I;

    void Awake()
    {
        I = this;
        FriendHitColor = friendHitColor;
        EnemyHitColor = enemyHitColor;
        FriendHealColor = friendHealColor;
        EnemyHealColor = enemyHealColor;
        ExpGainColor = expGainColor;
        // OutlineWidth = outlineWidth;
        // OutlineColor = outlineColor;
    }
}
