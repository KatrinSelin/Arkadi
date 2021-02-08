using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject spawnie;
    public Transform target;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        time += Time.deltaTime;
        if (time >= 2f) {

            time = 0;
            GameObject clone = Instantiate(spawnie, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            Destroy(clone, 3);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject clone = Instantiate(spawnie, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            Destroy(clone, 3);
        }
        
    }

  
    
}
