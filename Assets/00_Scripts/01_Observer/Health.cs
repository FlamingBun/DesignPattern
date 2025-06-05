using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int fullHealth = 100;
    private int damagePerSecond = 1;
    private int currentHealth = 0;
    public Text healthText;
    private void Awake()
    {
        ResetHealth();
        StartCoroutine(TakeDamage());
    }
    
    private void OnEnable()
    {
        // 구독
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }
    
    private void OnDisable()
    {
        // 구독 취소
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }
    
    public float GetHealth()
    {
        return currentHealth;
    }
    
    private void ResetHealth()
    {
        currentHealth = fullHealth;
    }
    
    private IEnumerator TakeDamage()
    {
        while(currentHealth > 0)
        {
            currentHealth -= damagePerSecond;
            healthText.text = $"HP : {currentHealth}";
            yield return new WaitForSeconds(1f);
        }
    }
}