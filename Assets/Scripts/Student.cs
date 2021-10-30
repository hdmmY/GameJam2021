using UnityEditor;
using UnityEngine;

public enum StudentTag
{
    Anime,               // 动漫社 - 二次元 - 中二 福瑞控 亚文化BL社团
    Poetry,              // 淫诗社团 - 道貌岸然
    Shandong,            // 倒装 山东帮派 煎饼 社团 日常无厘头 
    FantasiticBeast,     // 面包虫 搭关卡 养苍蝇 奇怪宠物饲养者
    Chef,                // DIY 厨师火锅
    Wasteland,           // 衣服破破烂烂 - 废土 袜子
    AntiIntellectualism, // 不良- 邪教 - 反智 中医 
    OCD,                 // 强迫症 洁癖
    Gothic,              // 摇滚 哥特 视觉 重金属
    Patriotism           // 战狼 小粉红 
}

[CreateAssetMenu(menuName = "ScriptableObjects/Student", order = 1)]
public class Student : ScriptableObject
{
    public GameObject StudentGO;

    public StudentTag Tag;

}
