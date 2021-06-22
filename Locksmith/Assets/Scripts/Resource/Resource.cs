using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceTypeSO resource;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        if (tag == Tags.AllyTag)
        {
            ResourceManager.Instance.AddResource(resource, 1);
            Destroy(this.gameObject);
        }
    }
}
