using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class title : MonoBehaviour
{
    public int i;//カウント変数
    public bool j;//ファイルアドレスのフラグ
    public GameData Gamedata;//ゲーム中のデータの保管場所
    public TextMeshProUGUI error;//エラーテキスト
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        error.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        while(i < 0xFF)
        {
            string folderName = $"0x{i:X2}";
            Debug.Log(folderName);
            string folderPass = Path.Combine(Path.GetDirectoryName(Application.dataPath), folderName);
            if (!Directory.Exists(folderPass))
            {
                Gamedata.Memory2(folderName);
                j= true;
                break;
            }
            i++;
        }
        if (j == true)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            error.gameObject.SetActive(true);
            error.text = "データが多すぎます、セーブデータを消してください。";
        }
    }
}
