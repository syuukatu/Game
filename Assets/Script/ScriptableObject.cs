using System.Collections;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    public string Adresu;//データのアドレス
    public bool adresu;//アドレスの判断
    public int k;//csの進捗
    public int mozi;//文字数
    public string Input;//入力したデータ
    public string Model;//お手本のデータ
    public string time;//最終プレイ時間
    public bool resume ;//途中かの判断する変数
    public Vector3 Playerpos;//プレイヤー座標
    public Vector3 Playerrotati;//プレイヤー向き
    public bool Playerfrg=false;//プレイヤー座標フラグ
    public bool delete=false;//データ削除モードかの確認フラグ
    public bool playefrg=false;//プレイしたかのフラグ
    public int GameScenes;//シーンの判定
    public void Memory(Sourcecode SourcecodeScript)
    {
        k = SourcecodeScript.count;
        mozi = SourcecodeScript.i;
        Input = SourcecodeScript.input.text;
        resume= SourcecodeScript.resume;
        Model = SourcecodeScript.date;
        playefrg = true;
    }
    public void Memory2(string folderName)
    {
        Adresu = folderName;
    }
    public void Memory3(SaveData data)
    {
        Adresu=data.Adresu;
        adresu = true;
        k = data.k;
        time = data.time;
        if (data.Model == data.Input )
        {
            mozi = 0;
            Input = null;
            Model = null;
        }
        else
        {
            mozi = data.mozi;
            Input = data.Input;
            Model = data.Model;
        }
    }
    public void Memory4(Vector3 pos, Vector3 rotati,int i)
    {
        switch (i) 
        {
            case 1:
                rotati.y = 90;
                break;
            case 2:
                rotati.y = -90;
                break;
            default:
                break;
        }

        Playerpos = pos;
        Playerrotati = rotati;
        Playerfrg = true;
    }
    public void Memory5(TextMeshProUGUI input,int i)
    {
        mozi = i;
        Input = input.text;
    }
    public void ModoChange()
    {
        if (delete == false)
        {
            delete = true;
        }else if (delete == true)
        {
            delete=false;
        }
    }
}
public class NewMonoBehaviourScript : MonoBehaviour
{
}
