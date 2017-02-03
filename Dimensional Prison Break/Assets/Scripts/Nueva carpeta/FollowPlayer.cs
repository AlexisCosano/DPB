using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    /// <summary>
    /// Player al que estem seguint ara mateix
    /// </summary>
    public Transform player;
    
    //float last_angle = 0.0f;
    //public int x = 10;
    //public int y = 10;
    //public int z = 10;

    /// <summary>
    /// Distancia incial amb el player
    /// </summary>
    private Vector3 offset;

    private Vector3 position;

    // Use this for initialization
    void Start()
    {
       // transform.position = new Vector3(player.transform.position.x + x, player.transform.position.y + y, player.transform.position.z + z);
        //transform.LookAt(player.transform);
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        position.x = player.transform.position.x - offset.x;
        transform.position = position;

       /* if (Input.GetButtonDown("Fire2"))
        {
            last_angle += 45.0f;
            transform.RotateAround(player.transform.position, Vector3.up, 45.0f);
            transform.LookAt(player.transform);
            offset = player.transform.position - transform.position;
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            last_angle -= 45.0f;
            transform.RotateAround(player.transform.position, Vector3.up, -45.0f);
            transform.LookAt(player.transform);
            offset = player.transform.position - transform.position;
        }*/
    }
}
