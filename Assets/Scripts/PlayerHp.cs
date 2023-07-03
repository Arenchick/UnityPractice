using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [Range(1, 10)]
    public int StartHp = 10;
    public int CurrentHp;

    public TextMeshProUGUI countHpText;
    public Image HpBar;

    private void Start()
    {
        CurrentHp = StartHp;
        countHpText.text = CurrentHp + "/" + StartHp;
    }

    public void SetDamage(int damage)
    {
        CurrentHp -= damage;
        countHpText.text = CurrentHp + "/" + StartHp;

        if (CurrentHp <= 0)
        {
            // Destroy(gameObject);
            Debug.Log("Fail!");
        }

        HpBar.fillAmount = Mathf.Clamp01((float)CurrentHp / StartHp);
    }

    public void AddHp(int countHp)
    {
        CurrentHp += countHp;
        CurrentHp = Mathf.Clamp(CurrentHp, 0, StartHp);
        countHpText.text = CurrentHp + "/" + StartHp;
        HpBar.fillAmount = Mathf.Clamp01((float)CurrentHp / StartHp);
    }

}
