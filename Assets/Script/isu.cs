using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class isu : MonoBehaviour
{
    public camera1 camerScript;
    public TextMeshProUGUI sittext;
    //public Button sittextbutton;
    private GameObject Player;//プレイヤー
    public Vector3 Playerpos;//プレイヤー座標
    public Vector3 Playerrotati;//プレイヤー向き
    public GameData Gamedata;//ゲーム中のデータの保管場所

    void Start()
    {
        camerScript = GameObject.Find("Main Camera").GetComponent<camera1>();
        Player = GameObject.FindGameObjectWithTag("Player");
        sittext.gameObject.SetActive(false);
    }
    public void SitDown()
    {
        sittext.gameObject.SetActive(true);
        sittext.text = "座る";
    }
    public void Sitatalltimes()
    {
        sittext.gameObject.SetActive(false);
    }
    public void Mode1()
    {
        Playerpos = Player.transform.position;
        Playerrotati = Player.transform.eulerAngles;
        int i = 1;
        Gamedata.Memory4(Playerpos, Playerrotati, i);
        SceneManager.LoadScene(2);
    }
}
