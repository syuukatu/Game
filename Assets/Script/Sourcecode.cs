using JetBrains.Annotations;
using System.Collections;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sourcecode : MonoBehaviour
{
    public TextAsset Game1textFile1;//タイトル
    public TextAsset Game1textFile2;//プレイヤー
    public TextAsset Game1textFile3;//メインカメラ
    public TextAsset Game1textFile4;//敵
    public TextAsset Game1textFile5;//リザルト
    public TextMeshProUGUI screen;//ソースコード(カンペ)
    public TextMeshProUGUI input;//ソースコード(入力)
    public TextMeshProUGUI Operation;//操作方法
    public int i=0;//文字数
    public bool resume=false;
    public int count;//作ったソースコード数
    public string date;//入力の判断するために圧縮した文字データ
    private char[] date2;//圧縮したのと判別するためにchra[]に変換
    private string key;//入力キーの取得
    private char[] key2;//変換後のキー入力されたキーの名前
    public input inputScript;//入力キーの確認cs
    public GameData Gamedata;//ゲーム中のデータの保管場所
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        //Debug.Log(Gamedata.k);
        //Debug.Log(Gamedata.Adresu);
        Gamedata.GameScenes = 2;
        count = Gamedata.k;
        resume = Gamedata.resume;
        inputScript = GetComponent<input>();
        Text();
        if (Gamedata.Input ==Gamedata.Model)
        {
            resume = true;
        }
        else
        {
            resume = false;
        }
        //Debug.Log(date);
        //Debug.Log(Gamedata.Input);
        //Debug.Log(resume);
        InputData();
        Mozisuu();
        date = date.Replace("\r\n", "\n").Replace("\n", "\n").Replace("\r", "\n").Replace(" ", "␣");
        date2= date.ToCharArray();
        screen.text = date;
    }

    void Update()
    {
        key = inputScript.Input();
        key2 = key.ToCharArray();
        if (key != "NULL")
        {
            if (key == "\u001B")
            {
                input.text = input.text.Replace("\r\n", "\n").Replace("\n", "\n").Replace(" ", "␣");
                if (input.text == date)
                {
                    resume = false;
                    //Debug.Log(count);
                }
                else
                {
                    resume = true;
                }
                inputScript.Finished();
            }
            else if(key== "CtrlShift")
            {
                Gamedata.Memory5(input, i);
                SceneManager.LoadScene(3);
            }
            else if (key2.Length == 2)
            {
                if (date2[i] == key2[0] && date2[i + 1] == key2[1])//二文字の場合の処理
                {
                    Mozi2();//処理だけの関数をよびだす
                }
            }
            else
            {
                if (date2[i] == key2[0])//1文字の場合の処理
                {
                    Mozi1();//処理だけの関数をよびだす
                }
            }
        }
    }
    public void Text()
    {
        //Debug.Log(count);
        switch (count)
        {
            case 0:
                date = Game1textFile1.text;
                break;
            case 1:
                date = Game1textFile2.text;
                break;
            case 2:
                date = Game1textFile3.text;
                break;
            case 3:
                date = Game1textFile4.text;
                break;
            case 4:
                date = Game1textFile5.text;
                break;
        }
    }
    public void InputData()
    {
        if (resume != true)
        {
            input.text = Gamedata.Input;
        }
        else
        {
            input.text = null;
        }
    }
    public void Mozisuu()
    {
        if (resume != true)
        {
            i = Gamedata.mozi;
        }
        else
        {
            i = 0;
        }
    }
    public void Mozi2()
    {
        float scroll = inputScript.Scrollbar.value;
        input.text += key;
        i += 2;
        inputScript.Scrollbar.value = scroll;
    }
    public void Mozi1()
    {
        float scroll = inputScript.Scrollbar.value;
        input.text += key;
        i += 1;
        inputScript.Scrollbar.value = scroll;
    }
}
