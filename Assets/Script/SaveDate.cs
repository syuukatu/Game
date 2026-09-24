using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class SaveData
{
    public string Adresu;//データのアドレス
    public string time;//最終プレイ時間
    public int k;//csの進捗
    public int mozi;//文字数
    public string Input;//入力したデータ
    public string Model;//お手本のデータ
    public Vector3 Playerpos;//プレイヤー座標
    public Vector3 Playerrotati;//プレイヤー回転度
}
public class SaveDate : MonoBehaviour
{
    //public Sourcecode SourcecodeScript;//ソースコードcs
    private int i=0;//16進数の変数でアドレスとして使用
    private byte[] key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");//鍵(暗号化に使う32バイト)
    private byte[] iv = Encoding.UTF8.GetBytes("1234567890123456");//初期化ベクトル(暗号化に使う16バイト)
    string folderName;//データのアドレス
    public GameData Gamedata;//ゲーム中のデータの保管場所
    public static string Encrypt(string json, byte[] key, byte[] iv)
    {
        using (Aes aes = Aes.Create())//AES暗号オブジェクト作成
        {
            aes.Key = key;//AES暗号の鍵の設定
            aes.IV = iv; // AES暗号の初期化ベクトル(IV)を設定

            ICryptoTransform encryptor = aes.CreateEncryptor();// 暗号化を行うオブジェクトを作成

            using (MemoryStream ms = new MemoryStream()) // 暗号化したデータを一時的に保存するメモリ
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) // メモリへ暗号化しながら書き込むストリーム
                {
                    using (StreamWriter sw = new StreamWriter(cs))// 文字列を書き込むためのストリーム
                    {
                        sw.Write(json);// 書き込まれる途中で自動的に暗号化される
                    }
                }
                return Convert.ToBase64String(ms.ToArray());  // 暗号化されたバイト列をBase64文字列に変換して返す
            }
        }
    }
    private void Start()
    {
        //SourcecodeScript = GetComponent<Sourcecode>();
    }
    public string Save()
    {
        if (Gamedata.adresu == true)
        {
            folderName = Gamedata.Adresu;
        }
        else
        {
            folderName = null;
        }
        if (folderName == null)
        {
            Debug.Log("保存中1");
            folderName = Gamedata.Adresu;
            // string folderPass = Path.Combine(Application.persistentDataPath, folderName);//仮でファイルパス生成
            string folderPass = Path.Combine(Path.GetDirectoryName(Application.dataPath), folderName);//exeファイルのファイパス生成
            Debug.Log(folderName);
            if (!Directory.Exists(folderPass))
            {
                Directory.CreateDirectory(folderPass);//フォルダー生成
                Debug.Log(folderPass);
                string filePath = Path.Combine(folderPass, "save.json");//保存textなどの保存
                SaveData data = new SaveData();
                data.Adresu = folderName;
                data.k = Gamedata.k;
                data.mozi = Gamedata.mozi;
                data.Input = Gamedata.Input;
                data.Input = data.Input.Replace("\r", "[CR]").Replace("\n", "[LF]\n");
                data.Model = Gamedata.Model;
                data.Model = data.Model.Replace("\r", "[CR]").Replace("\n", "[LF]\n");
                data.time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                //Debug.Log(data.time);

                string json = JsonUtility.ToJson(data, true);//JSON形式の文字列に変換
                //string Aes = Encrypt(json, key, iv);//
                //Debug.Log(Aes);
                //Debug.Log(Aes.Length);
                //File.WriteAllText(filePath, Aes);//書き込んで保存される
                File.WriteAllText(filePath, json);//書き込んで保存される    
            }
        }
        else
        {
            Debug.Log("保存中2");
            string folderPass = Path.Combine(Path.GetDirectoryName(Application.dataPath), folderName);//exeファイルのファイパス生成
            string filePath = Path.Combine(folderPass, "save.json");//保存textなどの保存
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            data.Adresu = folderName;
            data.k = Gamedata.k;
            data.mozi = Gamedata.mozi;
            data.Input = Gamedata.Input;
            data.Input = data.Input.Replace("\r", "[CR]").Replace("\n", "[LF]\n");
            data.Model = Gamedata.Model;
            data.Model = data.Model.Replace("\r", "[CR]").Replace("\n", "[LF]\n");
            data.time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            json = JsonUtility.ToJson(data, true);//JSON形式の文字列に変換
            //string Aes = Encrypt(json, key, iv);//
            //Debug.Log(Aes);
            //Debug.Log(Aes.Length);
            //File.WriteAllText(filePath, Aes);//書き込んで保存される
            File.WriteAllText(filePath, json);//書き込んで保存される
        }
        //Debug.Log((Path.GetDirectoryName(Application.dataPath)));
        return folderName;
    }
    public void Load(int i)
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Application.dataPath),$"0x{i:X2}","save.json");
        string json = File.ReadAllText(filePath); // JSONファイルの内容を文字列として読み込む
        SaveData data = JsonUtility.FromJson<SaveData>(json);// JSON文字列をSaveData型のオブジェクトに変換
        Gamedata.Memory3(data);
    }
    public SaveData Data(int i)
    {
        string folderName = $"0x{i:X2}";
        string folderPath = Path.Combine(Path.GetDirectoryName(Application.dataPath),folderName);
        string filePath = Path.Combine(folderPath, "save.json");
        if (!File.Exists(filePath))
        {
            return null;
        }
        string json = File.ReadAllText(filePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data;
    }
    public void Delete(int i)
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Application.dataPath), $"0x{i:X2}");
        if (Directory.Exists(filePath))
        {
            Directory.Delete(filePath, true);
        }
    }
}
