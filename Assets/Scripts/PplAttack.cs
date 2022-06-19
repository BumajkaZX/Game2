using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PplAttack : MonoBehaviour
{

    public GameObject[] ppl = null;
    [ContextMenu("Attack")]
    public  void IsAttack()
    {
        for (int i = 0; i < ppl.Length; i++)
        {
            ppl[i].GetComponent<Animator>().SetBool("_attack", true);
        }
    }
}
