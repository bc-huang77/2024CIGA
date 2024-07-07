
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalEnums", menuName = "Custom/Global Enums")]
public class GlobalEnums : ScriptableObject
{
    public enum SoundSource
    {
        Event,
        Cave,
        Ice,
        Water,
        Woods,
        Music_title, //
        Music_cave,
        Music_final,
        Music_ice,
        Music_sea,
        Music_woods,
        Chilun,  // 11
        Mushroom,
        Xuanwo, //
        Bigger,
        Draw,
        Rotate,
        Smaller,
        Through,  //18
        Upside_down,   
        Hurt,
        Jump,
        Jump_water,  
        Moving,
        Button_enter,
        Button_exit,
        Button_over,
        Stopall,
        Grass, 
        Sand,
        Under_the_sea,
        Cg,

    }
}
// public class SoundSource { public static SoundSource instance; // AudioManager 的单例 // 私有构造函数，防止通过 new 关键字创建实例 private SoundSource() { } public List<AudioClip> SoundEffects;
//     public List<AudioClip> BackgroundMusics = new List<AudioClip>{};


//     // 公有静态方法，用于获取单例实例
//     public static SoundSource GetInstance()
//     {
//         // 如果实例不存在，则创建新的实例
//         if (instance == null)
//         {
//             instance = new SoundSource();
//         }

//         return instance;
//     } 
// }