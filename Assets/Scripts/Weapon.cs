using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera cam;
    public ParticleSystem particlePrefab;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 100, Color.red);

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo))
            {
                Debug.Log("Ray = " + hitInfo.collider.name);
                if (hitInfo.transform.TryGetComponent<Enemy>(out var enemy))
                {
                    var q = Quaternion.LookRotation(-cam.transform.forward);
                    var pr = Instantiate(particlePrefab, hitInfo.point, q);
                    enemy.SetDamage(3);
                }

            }
            animator.SetTrigger("Fire");
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Start reload");
            animator.SetTrigger("Reload");
        }


    }
}
