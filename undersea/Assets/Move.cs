using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    float go;
    public int health = 100;
    public float speed = 1f;
    private Rigidbody2D rb;
    public int DNA;
    public GameObject otherObjectToDestroy; // Reference to another object to destroy
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mv();
    }

    void Mv()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(hor, ver).normalized;
        transform.position += moveVector * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("醱給馬雖脾");
        health -= 2;

        if (collision.CompareTag("DNA"))
        {
            Destroy(collision.gameObject);
            DNA += 1;
        }

        if (collision.CompareTag("Agi"))
        {
            Destroy(collision.gameObject);
            if (otherObjectToDestroy != null)
            {
                Destroy(otherObjectToDestroy);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("醱給馬雖脾");
        health -= 1;
    }
}

