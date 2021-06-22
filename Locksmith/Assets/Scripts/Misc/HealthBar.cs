using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthTransform;
    private HealthBaseClass healthClass;
    private int healthMax => healthClass.maxHealth;
    private float health => healthClass.health;
    
    // Start is called before the first frame update
    void Awake()
    {
        healthClass = GetComponentInParent<HealthBaseClass>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // might wanna lossy scale this later
        /*
        var lossyScale = healthTransform.lossyScale;
        var xSize = health / healthMax;
        xSize = xSize / lossyScale.x;
        var ySize = 1 / lossyScale.x;
        */
        var xSize = health / healthMax;
        healthTransform.localScale = new Vector2(xSize, 1);
    }
}
