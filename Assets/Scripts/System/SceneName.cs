using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// シーンの名前を定数化して使いまわせるようにするクラス。
/// シーン名の変更があったときはここを変更する。
/// 最大ステージ数の変更もここで行う。
/// </summary>
public class SceneName : MonoBehaviour
{
    //タイトルシーン
    public const string TITLE = "TitleScene";    
    
    //ステージセレクトシーン
    public const string STAGESELECT = "StageSelectScene"; 

    //ステージシーン(この定数にプラスでステージナンバーを記述してください)
    public const string STAGE = "Stage";
}
