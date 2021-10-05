using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    public float gravityScale, planetRadius, gravityMinRange, gravityMaxRange;
    private Transform target;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        float gravitationalPower = gravityScale;
        float dist = Vector2.Distance(obj.transform.position, transform.position);

        if (dist > (planetRadius * gravityMinRange))
        {
           float min = planetRadius + gravityMinRange;
           gravitationalPower = (((min + gravityMaxRange) - dist / gravityMaxRange) * gravitationalPower);
        }

        Vector2 planetPosition = transform.position;
        Vector2 dir = (transform.position - obj.transform.position) * gravityScale;
        obj.GetComponent<Rigidbody2D>().AddForce(dir);

        if (obj.CompareTag("Orbiter"))
        {
           

            obj.transform.up = Vector2.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime * 90f);
        }
    }

}
