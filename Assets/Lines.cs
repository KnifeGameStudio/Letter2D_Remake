using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lines : MonoBehaviour
{
    public int i;
    public String line1 = "有什么值得回忆的吗？家？如果可以的话，我们都不会想要出生在这样的家庭里吧";
    public String line2 = "从小学的时候就把我关在家里做题，每天一套。说什么考上重点初中，重点高中，赢在起跑线上？";
    public String line3 = "喜欢看书，小说，散文，随便写的生活记录或者想法也喜欢看！或许是因为被家长关着，只能用这种方法体验生活了吧。只不过偷偷买的书被他们发现，现在都被仍在地上";
    public String line4 = "后来慢慢喜欢上了写东西。网络上认识的朋友鼓励我去网络文学平台上写小说试试看， 没想到居然很受欢迎！去年写了一个中篇小说“蝴蝶之梦”，讲的是游戏世界里面的人们拥有了自我想要逃出来的事，居然还获得了“电光文库”秋季最佳新人奖。奖牌被我悄悄藏在了椅子下面。那个故事，或多或少在说我自己吧";
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    
    // Start is called before the first frame update
    void Start()
    {
        if (i == 0)
        {
            text1.text = "";
            text2.text = "";
            text3.text = "";
            text4.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
