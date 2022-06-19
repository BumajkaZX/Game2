using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySp : MonoBehaviour
{
    [SerializeField]
    GameObject gameO = null;

    public Transform P0 = null;
    public Transform P1 = null;
    public Transform P2 = null;
    public Transform P3 = null;
    [Range(0, 1)]
    public float t;
    public float speed = 0;
    [SerializeField]
    ParticleSystem BigSplash1 = null;
    
    public void TransFR(Transform P0n, Transform P1n, Transform P2n, Transform P3n)
    {
        P0 = P0n;
        P1 = P1n;
        P2 = P2n;
        P3 = P3n;
      
    }
    void Update()
    {
        if (t <= 1)
        {
            transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
            transform.rotation = Quaternion.LookRotation(Bezier.GetFirstFerivative(P0.position, P1.position, P2.position, P3.position, t));
        }
        if (gameO.transform.position.y <= -7)
            Destroy(gameO);


    }
    private void FixedUpdate()
    {
        
        if (t <= 1)
        {
            t += Time.deltaTime * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
            GetComponent<Rigidbody>().isKinematic = true;
        if (collision.gameObject.layer == 11)
        {
     
            ParticleSystem b = Instantiate(BigSplash1, collision.contacts[0].point, Quaternion.identity);
          
            
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }
 

}

