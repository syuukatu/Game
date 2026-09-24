using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    public camera1 camerScript;
    public TextMeshProUGUI savetext;
    private GameObject Player;//プレイヤー
    public Vector3 Playerpos;//プレイヤー座標
    public Vector3 Playerrotati;//プレイヤー向き
    public SaveDate SaveDateScript;//データセーブするcs
    public GameData Gamedata;//ゲーム中のデータの保管場所
    public TextAsset Game1textFile1;//タイトル
    public TextAsset Game1textFile2;//プレイヤー
    public TextAsset Game1textFile3;//メインカメラ
    public TextAsset Game1textFile4;//敵
    public TextAsset Game1textFile5;//リザルト
    void Start()
    {
        camerScript = GameObject.Find("Main Camera").GetComponent<camera1>();
        Player = GameObject.FindGameObjectWithTag("Player");
        savetext.gameObject.SetActive(false);
        SaveDateScript = GetComponent<SaveDate>();
    }
    public void Date()
    {
        savetext.gameObject.SetActive(true);
        savetext.text = "セーブ";
    }
    public void Sitatalltimes()
    {
        savetext.gameObject.SetActive(false);
    }
    public void Date2()
    {
        if(Gamedata.Input== Gamedata.Model && Gamedata.playefrg == true)
        {
            Gamedata.k++;
            Gamedata.playefrg = false;
        }
        // Debug.Log("保存する座標：" + Player.transform.position);
        Debug.Log(Gamedata.Playerfrg);
        Playerpos = Player.transform.position;
        Playerrotati = Player.transform.eulerAngles;
        int i = 2;
        Gamedata.Memory4(Playerpos,Playerrotati,i);
        SaveDateScript.Save();
        SceneManager.LoadScene(1);
    }
}
