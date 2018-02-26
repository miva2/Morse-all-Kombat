using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{

    public float speed;
    public Vector3 offset;
    public float maxTravelDistance = 100;

    private int damage;
    private float travelledDistance = 0;

    // Use this for initialization
    void Start()
    {

    }

    public void Initialize(int sign, int damage)
    {
        speed *= sign;
        transform.position += new Vector3(offset.x * sign, offset.y, offset.z);
        this.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0) * Time.deltaTime;
        travelledDistance += speed * Time.deltaTime;
        if(travelledDistance > maxTravelDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PlayerScript.TAG_PLAYER)
        {
            collision.gameObject.GetComponent<PlayerScript>().DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}