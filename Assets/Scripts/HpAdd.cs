using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpAdd : MonoBehaviour
{
    public int countAddHp = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHp>(out PlayerHp hp))
        {
            if(hp.CurrentHp == hp.StartHp)
            {
                return;
            }

            hp.AddHp(countAddHp);
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
