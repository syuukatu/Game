using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoad : MonoBehaviour
{
    public SaveDate SaveDateScript;//データセーブするcs
    public GameData Gamedata;//ゲーム中のデータの保管場所
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveDateScript = GetComponent<SaveDate>();
    }

    public void Load()
    {
        string text = transform.name;
        text = text.Remove(0, 5);
        int Adresu = int.Parse(text);
        if (Gamedata.delete == false)
        {
            SaveDateScript.Load(Adresu);
            SceneManager.LoadScene(1);
        }
        else if (Gamedata.delete == true)
        {
            SaveDateScript.Delete(Adresu);
            Destroy(gameObject);
        }
    }
}
