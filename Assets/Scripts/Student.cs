using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum StudentTag
{
    Pet,              // 宠物
    Insect,           // 昆虫
    Shandong,         // 山东
    Anime,            // 二次元    
    WarWolf,          // 战狼
    Scheming,         // 正人君子同好会
    LeftHand,         // 左撇子
    SuperPower,       // 超能力者
    KOL,              // 网红
    Rich,             // 有钱
    Dressing          // 打扮
}

[CreateAssetMenu(menuName = "ScriptableObjects/Student", order = 1)]
public class Student : ScriptableObject
{
    public GameObject StudentGO;

    public string Prefix;

    public string Name;

    public List<StudentTag> Tag;

}
