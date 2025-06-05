using UnityEngine;
using UnityEngine.UI;


public class LevelText : MonoBehaviour
{
    private Text levelText;
    private Level level;
    
    private void Awake()
    {
        levelText = GetComponent<Text>();
        level = FindObjectOfType<Level>();
        UpdateLevelText();
    }
    
    private void OnEnable()
    {
        // 구독
        level.onLevelUpAction += UpdateLevelText;
    }
    
    private void OnDisable()
    {
        // 구독 취소
        level.onLevelUpAction -= UpdateLevelText;
    }
    
    private void UpdateLevelText()
    {
        levelText.text = $"Level: {level.GetLevel()}";
    }
}