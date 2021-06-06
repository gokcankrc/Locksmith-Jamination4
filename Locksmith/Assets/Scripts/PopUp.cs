using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public PopUp Create(Vector3 position, string popupText)
    {
        position = new Vector3(position.x, position.y, 0);
        Transform damagePopupTransform = Instantiate(transform, position, Quaternion.identity);
        PopUp damagePopup = damagePopupTransform.GetComponent<PopUp>();
        damagePopup.Setup(popupText);
        return damagePopup;
    }


    public void Setup(string popupText)
    {
        textMesh.SetText(popupText);
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

    private void Update()
    {
        float moveSpeedY = 2f;
        float moveSpeedX = 1f;
        transform.position += new Vector3(moveSpeedX, moveSpeedY) * Time.deltaTime;

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
