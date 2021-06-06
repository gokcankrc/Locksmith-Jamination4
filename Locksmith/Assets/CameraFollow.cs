using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var difference = player.transform.position - transform.position;
        transform.position += difference * 0.05f;
        transform.position += Vector3.back * 5 - Vector3.forward * transform.position.z; 
    }
}
