using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    IEnumerator Start()
    {
        Health health = GetComponent<Health>();
        Level level = GetComponent<Level>();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log($"Exp: {level.GetExp()}, Level: {level.GetLevel()}, Health: {health.GetHealth()}");
        }
    }
}
