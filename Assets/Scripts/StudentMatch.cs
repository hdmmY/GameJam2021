using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StudentMatch
{
    public Student Student1;
    public Student Student2;

    public List<StudentTag> MatchResult()
    {
        var result = new List<StudentTag>();

        for (int i = 0; i < Student1.Tag.Count; i++)
        {
            for (int j = 0; j < Student2.Tag.Count; j++)
            {
                if (Student1.Tag[i] == Student2.Tag[j])
                {
                    result.Add(Student1.Tag[i]);
                }
            }
        }

        return result;
    }

    public string ShowEnding(StudentTag tag)
    {
        if(Student1.Id < Student2.Id)
        {
            var tmp = Student2;
            Student2 = Student1;
            Student1 = tmp;
        }

        return EndingData[Student1.Id, Student2.Id];
    }

    public static Sprite GetTagSprite(StudentTag tag)
    {
        switch (tag)
        {
            case StudentTag.Pet: return Resources.Load<Sprite>("标签/下辈子");
            case StudentTag.Insect: return null;
            case StudentTag.Shandong: return null;
            case StudentTag.Anime: return null;
            case StudentTag.WarWolf: return null;
            case StudentTag.Scheming: return null;
            case StudentTag.LeftHand: return null;
            case StudentTag.SuperPower: return null;
            case StudentTag.KOL: return null;
            case StudentTag.Rich: return null;
            case StudentTag.Dressing: return null;
        }
        return null;
    }



    private static string[,] EndingData = new string[8,8]
    {
        {
            "",
            "",
            "", 
            "",
            "",
            "",
            "",
            "",
        },

        {
            "看着左思迁油腻的样子，王紫萱不知不觉中被触了变身，代表月亮消灭了左思迁。然后自己跟着小蛇到草丛中去抓也老鼠去了",
            "",
            "", 
            "",
            "",
            "",
            "",
            "",
        },

        {
            "李富贵的正气压强太大，连王紫萱体内查克拉都无法抵御，小蛇、蜥蜴都离开了她，她感觉失去了人生的意义，不知道下辈子要投胎干什么了，只能发呆在那里无聊地转笔",
            "李富贵捧着左思迁最新装订成册的淫秽诗刊，读着读着时不时一拍大腿，喊出声“好诗好诗，思迁兄真是才思泉涌，吾辈楷模“。左思迁有些感动，遇到了知己。他背包中拿出一套新衣服和一卷纸递给李富贵。下一秒两人黑框眼镜+中山装+白围巾迎风而立",
            "", 
            "",
            "",
            "",
            "",
            "",
        },

        {
            "王紫萱带着自己的小蛇、小蜥蜴和张宠爱的小猫咪在午后的草地上愉快的分享猫粮。王紫萱的小蛇还表演了“全身僵硬”，成为一根逗猫棒，张宠爱也像小猫一样在草地上蹦起来。蹦着蹦着她伸出的9条尾巴，红色的光围绕着她的全身...",
            "张宠爱看到左思迁的大油头非常难受，就控制猫猫飞到左思迁头上去舔他头发，要破坏他的发型。可是左思迁使用了“金刚牌”发胶，猫猫舌头被划伤了。张宠爱哭泣着离开了地球，回往自己的母星",
            "", 
            "",
            "",
            "",
            "",
            "",
        },

        {
            "梁小声看到王紫萱也带着自己的宠物笼子，很快乐地就开始搭了乐高迷宫，把自己的小蚂蚁miumiu放在了入口，招呼着让王紫萱也来玩。王紫萱拿出来了自己的小蛇。小蛇把小蚂蚁miumiu吃掉了。。。梁小声减了一条命",
            "梁小声头上总是飞着一只苍蝇，那是他的宠物concon。左思迁的油头也特别招苍蝇，两个人展开了决斗。决斗项目是比谁更招苍蝇",
            "", 
            "",
            "",
            "",
            "",
            "",
        },

        {
            "王紫萱和庞光大没什么共同话题，两个人都挺无聊的。不约而同，王紫萱和庞光大都开始转她的笔，用他们最熟练左手。接着他们聊了很多跟发达的右脑相关的话题，比如他们俩在幼儿园时都是的格子班级“量子波动阅读”大王",
            "庞光大为了示好，拿出了煎饼卷大葱递给左思迁。左思迁说“这个饼掉渣会弄脏我的衣服。”庞光大自顾自吃了起来，饼渣四溅。庞光大灵活得jie",
            "", 
            "",
            "",
            "",
            "",
            "",
        },

        {
            "杜筱眉一直觉得王紫萱酷酷的，想和她一起玩。于是从自己GUCCI书包中拿出了自己最喜欢的大蒜项链戴在了王紫萱脖子上。王紫萱瞬间脸色发青，全身爆出紫色的血管，无力地挣扎到“蒜你狠！～～”然后化为灰烬",
            "两个精致的人类，美妆大佬遇到一起先是去李佳琦直播间一起抢购了一年用的化妆品，然后找了一个安静角落相互给对方化妆。杜筱眉梳了一个大油头，能粘住苍蝇，左思迁扮了个烈焰红唇机车妹，给自己带来了十首新诗创作思路",
            "李富贵和杜筱眉都各自大谈特谈自己收到的最新礼物，虽然杜筱眉对手表以及李富贵对包包都一点不感兴趣，但他们聊得非常开心，感到非常满足", 
            "",
            "",
            "庞光大边走着边打了一个嗝，那满嘴蒜味让杜筱眉感到迷醉。杜筱眉说“哥，想吃东西了这会儿，你也饿了估计”。庞光大从他的小背包中拿出了一辆煎饼车。“有蒜吗你这？”，“必须的啊那是”。～～空气中都的弥漫着血糖升高的气息",
            "",
            "",
        },

        {
            "贾任英知道王紫萱身上的蜥蜴会吃面包虫，所以就拿出5道杠的正气之光袖标镇住王紫萱。两个人就这样僵持着，直到校车也走了，天也黑子，王紫萱的小蜥蜴跑去抓蚊子吃了。贾任英松了一口气，心想“都这么晚了，刷一会儿抖音再回家”",
            "左思迁一副远离女同学的样子离贾任英远远的，但是却在手机上一直在聊天，斗图，互换了很多自定义的搞笑聊天表情。新收集的自定义表情让他们觉得这一次春游没有白来",
            "李富贵和贾任英抬头挺胸走在山间小路上，即使中午有点闷热，他们依然穿着厚厚的外套，袖标迎风飘扬。两个人注视着远方，仿佛所有其他人都还沉浸在自己的童年，只有他们在规划着国家的未来", 
            "",
            "梁小声和贾任英拎着瓶瓶罐罐和一套乐高来到一个无人凉亭。 他们一拍即合的商量好计划，然后全程无尿点的拼出了一个乐高版尼拉塞克神庙。他们相识一笑，梁小声将蚂蚁miumiu，贾任英把面包虫miamia放在了关卡入口...",
            "",
            "",
            "",
        },
    };
}


