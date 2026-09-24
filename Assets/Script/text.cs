using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class text : MonoBehaviour
{
    public GameData Gamedata;//ゲーム中のデータの保管場所
    public TextMeshProUGUI GameSceces;//シーンの判定
    public TextMeshProUGUI Operation;//操作方法
    public input inputScript;//入力キーの確認cs
    private string key;//入力キーの取得
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        inputScript = GetComponent<input>();
        switch (Gamedata.GameScenes)
        {
            case 1:
                GameSceces.text = "移動方法";
                Operation.text = "前　：Wキー　　右：Dキー\r\n後ろ ：Sキー　　 左：Aキー\r\n椅子の近くでQキー：プログラミング\r\nベットの近くでQキー：セーブ &進行度更新\r\nRキーでタイトルに戻る";
                break;
            case 2:
                GameSceces.text = "入力方法";
                Operation.text = "表示されている文字が黒色に変わると入力された判定になります。\r\n基本はキーボードと一緒ですが「|」と「￥」はTabキーで入力できるようにしています。\r\n終了するばあいは、Escキーで戻ります。";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        key = inputScript.Input();
        if (key != "NULL")
        {
            if(key=="r" || key == "R")
            {
                if (Gamedata.GameScenes == 1)
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
}
