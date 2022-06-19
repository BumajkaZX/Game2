using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    GameObject sprit;
    Rigidbody rb;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
       
    }
    // Update is called once per frame
    void Update()
    {
        //Vector2 v2Vel = rb.velocity;
        float speed = rb.velocity.magnitude;

        if (speed > 0.5)
        {
            sprit.GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            sprit.GetComponent<Animator>().SetBool("Run", false);
            StartCoroutine(del());
        }
        
    }
    IEnumerator del()
    {
        yield return new WaitForSeconds(10.5f);
        sprit.GetComponent<Animator>().SetBool("Watch", true);

    }
}
