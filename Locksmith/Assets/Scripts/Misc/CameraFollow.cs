using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private PlayerEntity player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.PlayerAlive) return;
        var difference = player.transform.position - transform.position;
        transform.position += difference * 0.15f;
        transform.position += Vector3.back * 500 - Vector3.forward * transform.position.z; 
    }
}
