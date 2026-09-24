using UnityEngine;
using UnityEngine.SceneManagement;

public class back1 : MonoBehaviour
{
    public GameData Gamedata;//ゲーム中のデータの保管場所
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        Gamedata.delete = false;
        SceneManager.LoadScene(0);
    }
}
