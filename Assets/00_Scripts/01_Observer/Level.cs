using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    private int expToLevelUp = 100;
    // private UnityEvent onLevelUp; -- Inspector에서 callback을 등록할 수 있다.
    private int exp =0;
    
    // public delegate void CallbackType();
    // public event CallbackType onLevelUpAction; -- 아래 한 줄과 같은 역할
    public event Action onLevelUpAction;
    
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            GainExp(10);
        }
    }
    
    public void GainExp(int _exp)
    {
        int previousLevel = GetLevel();
        exp += _exp;
        if(GetLevel() > previousLevel)
        {
            if(onLevelUpAction != null)
            {
                onLevelUpAction();
            }
            // 위 3줄은 onLevelUpAction?.Invoke(); 와 같은 동작을 한다.
        }
    }
    
    public int GetExp()
    {
        return exp;
    }
    
    public int GetLevel()
    {
        return exp / expToLevelUp;
    }
}