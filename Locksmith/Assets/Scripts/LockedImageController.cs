using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedImageController : MonoBehaviour
{
    public GateSO gateType;
    public GameObject lockedImage;

    private void Update()
    {
        if (gateType.isCrafted)
        {
            lockedImage.gameObject.SetActive(false);
        }
    }
}
