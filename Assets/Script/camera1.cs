using StarterAssets;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class camera1 : MonoBehaviour
{
    private ThirdPersonController playerScript;//ThirdPersonController.cs 移動プログラム
    public GameObject Player;//プレイヤー
    public TextMeshProUGUI returntext;//タイトル戻る方法表示
    public TextMeshProUGUI karitext;//進捗度表示
    public TextMeshProUGUI operationtext;//操作方法
   [SerializeField]
    private float maussensitivity = 1f; // マウス感度
    Vector2 PlayerRotation1;//視点移動
    public float cameraSmoothTime = 0.1f;
    private float yaw;
    private float pitch;
    private float smoothSpeed = 5f;
    private float time;//経過時間
    public RaycastHit hit;//オブジェとの判定
    private Camera cam;
    private isu isuScript;//isu.cs 移動プログラム
    private Bed bedScript;//bed.cs 移動プログラム
    private GameObject isu;//椅子オブジェ
    private GameObject bed;//椅子オブジェ
    Vector3 isupos;//椅子オブジェの座標
    Vector3 bedpos;//ベットオブジェクトの座標
    public GameData Gamedata;//ゲーム中のデータの保管場所
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerScript = Player.GetComponent<ThirdPersonController>();
        cam = GetComponent<Camera>();
        isu = GameObject.Find("椅子");
        isuScript = isu.GetComponent<isu>();
        isupos = isu.transform.position;
        bed = GameObject.Find("bed");
        bedScript = bed.GetComponent<Bed>();
        if (Gamedata.Playerfrg == true)
        {
            Player.transform.position =Gamedata.Playerpos;
            Player.transform.eulerAngles = Gamedata.Playerrotati;
            yaw = Player.transform.eulerAngles.y;
        }else
        {
            yaw = transform.eulerAngles.y;
            pitch = transform.eulerAngles.x;
        }
        //Debug.Log(Player.transform.position);
        //Debug.Log(Player.transform.eulerAngles);
        bedpos = bed.transform.position;
        //PlayerCoordinates.y += 1.5f;
        //transform.position = PlayerCoordinates;
        returntext.text = "Rキー:戻る";
        operationtext.text = "Oキー:操作方法";
        time = 0f;
        //karitext.text = (Gamedata.k+1) + "日目";
        //karitext.gameObject.SetActive(true);
        //Debug.Log("読み込む座標：" + Gamedata.Playerpos);
        //Debug.Log("Start直後：" + Player.transform.position);
    }

    void Update()
    {
        if (time > 3f)
        {
            karitext.gameObject.SetActive(false);
        }
        else
        {
            karitext.text = (Gamedata.k + 1) + "日目";
            karitext.gameObject.SetActive(true);
            time += Time.deltaTime;
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Return();
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            Operation();
        }
        // カメラ位置をプレイヤーの頭へ
        transform.position = Player.transform.position + Vector3.up * 1.5f;

        // 停止中のみ視点を動かす
        if (!playerScript.IsMoving && playerScript.Speed == 0)
        {
            Vector2 mouse = Mouse.current.delta.ReadValue();

            yaw += mouse.x * maussensitivity;
            pitch -= mouse.y * maussensitivity;

            pitch = Mathf.Clamp(pitch, -60f, 60f);

            Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
        }
        else
        {
            // 移動中はプレイヤーの向きを基準にする
            yaw = Player.transform.eulerAngles.y;

            Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
        }
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 10f);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "椅子")
            {
                if ((-1.5f <= isupos.x - transform.position.x && isupos.x- transform.position.x <= 1.5f) && (-0.2f <= isupos.z - transform.position.z && isupos.z-transform.position.z <= 0.2f))
                {
                    isuScript.SitDown();//キー入力じゃないと反応しない
                    if (Keyboard.current.qKey.wasPressedThisFrame)
                    {
                        isuScript.Mode1();
                    }
                }
                else
                {
                    isuScript.Sitatalltimes();
                }
            }
            else if (hit.collider.gameObject.name == "bed")
            {
                if ((-1.45f <= bedpos.x- transform.position.x  && bedpos.x-transform.position.x <= 1.45f) && (- 1.95f <= bedpos.z - transform.position.z && bedpos.z- transform.position.z <= 1.95f))
                {
                    bedScript.Date();//キー入力じゃないと反応しない
                    if (Keyboard.current.qKey.wasPressedThisFrame)
                    {
                        bedScript.Date2();
                    }
                }
                else
                {
                    bedScript.Sitatalltimes();
                }
            }
            else
            {
                isuScript.Sitatalltimes();
                bedScript.Sitatalltimes();
            }
        }
        //Debug.Log(transform.position);
        //Debug.Log("Update：" + Player.transform.position);
        //Debug.Log("当たった：" + hit.collider.gameObject.name);
    }
    public void Return()
    {
        Gamedata.Adresu = null;
        Gamedata.k = 0;
        Gamedata.mozi = 0;
        Gamedata.Input = null;
        SceneManager.LoadScene(0);
    }
    public void Operation()
    {
        Gamedata.GameScenes = 1;
        int i = 0;
        Gamedata.Memory4(Player.transform.position, Player.transform.eulerAngles, i);
        SceneManager.LoadScene(3);
    }
}
