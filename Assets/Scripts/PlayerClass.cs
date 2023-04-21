using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour
{
    public Text textStats;
    public int LVL = 1;
    public float HP = 100.0f;
    public float SpeedMult = 1.0f;
    public float DamageMult = 1.0f;
    public float XP = 0.0f;
    public float XPToNextLVL = 10;
    public int SkillPoint = 0;
    public float MaxHP = 100.0f;
    public int armor = 0;
    public int arrow = 0;
    public int gold = 0;
    private void GameOver()
    {
        SceneManager.LoadScene(1);
        HP = MaxHP;
    }
    private void Update()
    {
        textStats.text = $"Level: {LVL} \nXP: {XP}/{XPToNextLVL} \nSkill Points: {SkillPoint} \nHP: {HP}/{MaxHP} \nArmor: {armor} \nSpeedMult: {SpeedMult} \nDamageMult: {DamageMult}\nArrows:{arrow}\nGold:{gold}";
        if (HP == 0)
        {
            GameOver();
        }
        if(XP >= XPToNextLVL)
        {
            LvlUp();
            XP = XP - XPToNextLVL;
            XPToNextLVL = XPToNextLVL + XPToNextLVL * 2.75f;
        }
    }

    private void LvlUp()
    {
        LVL++;
        if (LVL % 5 == 0)
        {
            SkillPoint += 2;
        }
        else
        {
            SkillPoint++;
        }
    }
}
