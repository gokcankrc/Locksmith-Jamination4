using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthTransform;
    [SerializeField] private SpriteRenderer healthSprite;
    private Vector3 pivot;
    
    // Start is called before the first frame update
    void Awake()
    {
        var healthClass = GetComponentInParent<HealthBaseClass>();
        healthClass.onHealthChange += UpdateHealthBar;
    }

    private void Start()
    {
        pivot = Vector3.right * (healthSprite.bounds.min.x - transform.position.x);
    }

    private void UpdateHealthBar(float health, float maxHealth, bool damaged)
    {
        // might wanna lossy scale this later
        /*
        var lossyScale = healthTransform.lossyScale;
        var xSize = health / healthMax;
        xSize = xSize / lossyScale.x;
        var ySize = 1 / lossyScale.x;
        */
        var scale = new Vector2(health / maxHealth, 1);
        ScaleAround(healthTransform.gameObject, pivot, scale);
    }

    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;
 
        Vector3 C = A - B; // diff from object pivot to desired pivot/origin
 
        float RS = newScale.x / target.transform.localScale.x; // relataive scale factor
 
        // calc final position post-scale
        Vector3 FP = B + C * RS;
 
        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }
}
