using System;using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class PopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private float moveSpeedY;
    private float moveSpeedX;
    

    private static PopUpColorEnum[] _popUpColorEnums = Enum.GetValues(typeof(PopUpColorEnum)).Cast<PopUpColorEnum>().ToArray();
    
    // TODO; Can make these static somehow.
    [SerializeField] private Color friendHitColor;
    [SerializeField] private Color enemyHitColor;
    [SerializeField] private Color friendHealColor;
    [SerializeField] private Color enemyHealColor;
    [SerializeField] private Color expGain;

    
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public PopUp Create(Vector3 position, string popupText, PopUpColorEnum colorEnum)
    {
        position = new Vector3(position.x, position.y, 0);
        Transform damagePopupTransform = Instantiate(transform, position, Quaternion.identity);
        PopUp damagePopup = damagePopupTransform.GetComponent<PopUp>();
        damagePopup.Setup(popupText, colorEnum);
        return damagePopup;
    }


    public void Setup(string popupText, PopUpColorEnum colorEnum)
    {
        var color = DetermineColor(colorEnum);
        // Added randomization cuz why not
        // Also made it so that they are instantiated from start
        moveSpeedY = 0.8f + Random.Range(0f, 0.2f);
        moveSpeedX = Random.Range(-0.4f, 0.4f);
        textMesh.SetText(popupText);
        textMesh.color = color;
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

    private Color DetermineColor(PopUpColorEnum colorEnum)
    {
        switch (colorEnum)
        {
            case PopUpColorEnum.EnemyHeal:
                return enemyHealColor;
            case PopUpColorEnum.EnemyHit:
                return enemyHitColor;
            case PopUpColorEnum.ExpGot:
                Debug.Log("DetermineColor() in PopUp.cs is not finished yet.");
                break;
            case PopUpColorEnum.FriendHeal:
                return friendHealColor;
            case PopUpColorEnum.FriendHit:
                return friendHitColor;
        }
        Debug.Log("DetermineColor() in PopUp.cs gave default value. never should happen.");
        return Color.magenta;
    }

    private void Update()
    {
        var pos = transform.position;
        pos += new Vector3(moveSpeedX, moveSpeedY) * Time.deltaTime;
        pos = pos + - pos.z * Vector3.forward + Vector3.back * 100;
        transform.position = pos;

        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

public enum PopUpColorEnum
{
    FriendHit, FriendHeal, EnemyHit, EnemyHeal, ExpGot
}
