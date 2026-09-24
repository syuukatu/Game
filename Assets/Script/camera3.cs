using UnityEngine;
using TMPro;

public class camera3 : MonoBehaviour
{
    public TextMeshProUGUI Modotext;//タイトル戻る方法表示
    public SaveDate SaveDateScript;//データセーブするcs
    public GameObject buttonPrefab;//セーブデータのボタンのプレハブ
    public GameObject textPrefab;//テキストのプレハブ
    public Transform contentTransform;
    public SaveData a;//セーブデータの情報表示用の仮データ
    public int i;//カウント変数
    public bool j=false;//セーブデータの有無のフラグ
    public input inputScript;//入力キーの確認cs
    private string key;//入力キーの取得
    public GameData Gamedata;//ゲーム中のデータの保管場所
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }
    void Start()
    {
        SaveDateScript = GetComponent<SaveDate>();
        for (int i = 0; i < 0xFF; i++)
        {
            a = SaveDateScript.Data(i);
            if (a != null)
            {
                GameObject button = Instantiate(buttonPrefab, contentTransform);
                button.name = "Data_" + i;
                button.GetComponentInChildren<TMP_Text>().text = a.time + "   日数:" + a.k;
                j = true;
            }
        }
        if (j == false)
        {
            GameObject text = Instantiate(textPrefab, contentTransform);
            text.GetComponentInChildren<TMP_Text>().text = "セーブデータがありません。";
        }
        Modotext.text = "モード:選択";
    }

    // Update is called once per frame
    void Update()
    {
        key = inputScript.Input();
        if (key== "CtrlD" && Gamedata.delete==false)
        {
            Modotext.text = "モード:削除";
            Gamedata.ModoChange();
        }
        else if(key == "CtrlD" && Gamedata.delete == true)
        {
            Modotext.text = "モード:選択";
            Gamedata.ModoChange();
        }
    }
}
