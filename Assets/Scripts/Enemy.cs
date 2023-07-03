using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Damage = 3;
    public float DamageTimeOut = 2;

    public int StartHp = 10;
    public int CurrentHp;

    public Image HpBar;

    private NavMeshAgent agent;
    private PlayerHp playerHp;

    private float _damageTime;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHp = FindObjectOfType<PlayerHp>();
    }

    private void Start()
    {
        CurrentHp = StartHp;
    }

    private void Update()
    {
        agent.SetDestination(playerHp.transform.position);

        if (Time.time - _damageTime >= DamageTimeOut)
        {
            if (Vector3.Distance(transform.position, playerHp.transform.position) <= agent.stoppingDistance)
            {
                playerHp.SetDamage(Damage);
                _damageTime = Time.time;
            }
        }

    }

    public void SetDamage(int damage)
    {
        CurrentHp -= damage;

        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
        }

        HpBar.fillAmount = Mathf.Clamp01((float)CurrentHp / StartHp);

    }
}
