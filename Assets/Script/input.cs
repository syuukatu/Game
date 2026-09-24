using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class input : MonoBehaviour
{
    [SerializeField] public Scrollbar Scrollbar;
    [SerializeField] private float speed = 0.5f;
    public SaveDate SaveDateScript;//データセーブするcs
    public GameData Gamedata;//ゲーム中のデータの保管場所
    public Sourcecode SourcecodeScript;//ソースコードcs
    string folderName;//データのアドレス
    void Start()
    {
        SaveDateScript = GetComponent<SaveDate>();
        SourcecodeScript = FindFirstObjectByType<Sourcecode>();
        //EventSystem.current.SetSelectedGameObject(Scrollbar.gameObject);
    }

    void Update()
    { }
    public string Input()
    {
        if (Keyboard.current.upArrowKey.isPressed && Gamedata.GameScenes==2)
        {
            Scrollbar.value += 1 * speed * Time.deltaTime;
        }
        if (Keyboard.current.downArrowKey.isPressed && Gamedata.GameScenes == 2)
        {
            Scrollbar.value += -1 * speed * Time.deltaTime;
        }
        if(Keyboard.current.dKey.wasPressedThisFrame &&(Keyboard.current.leftCtrlKey.isPressed || Keyboard.current.rightCtrlKey.isPressed) && Gamedata.GameScenes == 4)
        {
            return "CtrlD";
        }
        else if((Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed) && (Keyboard.current.leftCtrlKey.isPressed || Keyboard.current.rightCtrlKey.isPressed) && Gamedata.GameScenes == 2)
        {
            return "CtrlShift";
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "A";
        }
        else if (Keyboard.current.bKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "B";
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "C";
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "D";
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "E";
        }
        else if (Keyboard.current.fKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "F";
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "G";
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "H";
        }
        else if (Keyboard.current.iKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "I";
        }
        else if (Keyboard.current.jKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "J";
        }
        else if (Keyboard.current.kKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "K";
        }
        else if (Keyboard.current.lKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "L";
        }
        else if (Keyboard.current.mKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "M";
        }
        else if (Keyboard.current.nKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "N";
        }
        else if (Keyboard.current.oKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "O";
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "P";
        }
        else if (Keyboard.current.qKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "Q";
        }
        else if (Keyboard.current.rKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "R";
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "S";
        }
        else if (Keyboard.current.tKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "T";
        }
        else if (Keyboard.current.uKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "U";
        }
        else if (Keyboard.current.vKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "V";
        }
        else if (Keyboard.current.wKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "W";
        }
        else if (Keyboard.current.xKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "X";
        }
        else if (Keyboard.current.yKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "Y";
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "Z";
        }
        else if (Keyboard.current.digit1Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "!";
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "\"";
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "#";
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "$";
        }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "%";
        }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "&";
        }
        else if (Keyboard.current.digit7Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "'";
        }
        else if (Keyboard.current.digit8Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "(";
        }
        else if (Keyboard.current.digit9Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return ")";
        }
        else if (Keyboard.current.periodKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return ">";
        }
        else if (Keyboard.current.commaKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "<";
        }
        else if (Keyboard.current.slashKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "?";
        }
        else if (Keyboard.current.oem2Key.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "_";
        }
        else if ((Keyboard.current.semicolonKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed)) || Keyboard.current.numpadPlusKey.wasPressedThisFrame)
        {
            return "+";
        }
        else if (Keyboard.current.quoteKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "*";
        }
        else if (Keyboard.current.backslashKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "}";
        }
        else if (Keyboard.current.quoteKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "`";
        }
        else if (Keyboard.current.rightBracketKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "{";
        }
        else if (Keyboard.current.minusKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "=";
        }
        else if (Keyboard.current.equalsKey.wasPressedThisFrame && (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed))
        {
            return "~";
        }
        else if ((Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed) && Keyboard.current.backslashKey.wasPressedThisFrame)
        {
            return "|";
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            return "a";
        }
        else if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            return "b";
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            return "c";
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            return "d";
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            return "e";
        }
        else if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            return "f";
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            return "g";
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            return "h";
        }
        else if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            return "i";
        }
        else if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            return "j";
        }
        else if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            return "k";
        }
        else if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            return "l";
        }
        else if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            return "m";
        }
        else if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            return "n";
        }
        else if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            return "o";
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            return "p";
        }
        else if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            return "q";
        }
        else if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            return "r";
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            return "s";
        }
        else if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            return "t";
        }
        else if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            return "u";
        }
        else if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            return "v";
        }
        else if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            return "w";
        }
        else if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            return "x";
        }
        else if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            return "y";
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            return "z";
        }
        else if (Keyboard.current.digit1Key.wasPressedThisFrame || Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            return "1";
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame || Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            return "2";
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame || Keyboard.current.numpad3Key.wasPressedThisFrame)
        {
            return "3";
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame || Keyboard.current.numpad4Key.wasPressedThisFrame)
        {
            return "4";
        }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame || Keyboard.current.numpad5Key.wasPressedThisFrame)
        {
            return "5";
        }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame || Keyboard.current.numpad6Key.wasPressedThisFrame)
        {
            return "6";
        }
        else if (Keyboard.current.digit7Key.wasPressedThisFrame || Keyboard.current.numpad7Key.wasPressedThisFrame)
        {
            return "7";
        }
        else if (Keyboard.current.digit8Key.wasPressedThisFrame || Keyboard.current.numpad8Key.wasPressedThisFrame)
        {
            return "8";
        }
        else if (Keyboard.current.digit9Key.wasPressedThisFrame || Keyboard.current.numpad9Key.wasPressedThisFrame)
        {
            return "9";
        }
        else if (Keyboard.current.digit0Key.wasPressedThisFrame || Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            return "0";
        }
        else if (Keyboard.current.periodKey.wasPressedThisFrame || Keyboard.current.numpadPeriodKey.wasPressedThisFrame)
        {
            return ".";
        }
        else if (Keyboard.current.commaKey.wasPressedThisFrame)
        {
            return ",";
        }
        else if (Keyboard.current.slashKey.wasPressedThisFrame || Keyboard.current.numpadDivideKey.wasPressedThisFrame)
        {
            return "/";
        }
        else if (Keyboard.current.oem2Key.wasPressedThisFrame)
        {
            return "\\";//バックスラッシュキー
        }
        else if (Keyboard.current.semicolonKey.wasPressedThisFrame)
        {
            return ";";
        }
        else if (Keyboard.current.numpadMultiplyKey.wasPressedThisFrame)
        {
            return "*";
        }
        else if (Keyboard.current.minusKey.wasPressedThisFrame || Keyboard.current.numpadMinusKey.wasPressedThisFrame)
        {
            return "-";
        }
        else if (Keyboard.current.quoteKey.wasPressedThisFrame)
        {
            return ":";
        }
        else if (Keyboard.current.quoteKey.wasPressedThisFrame)
        {
            return "@";
        }
        else if (Keyboard.current.rightBracketKey.wasPressedThisFrame)
        {
            return "[";
        }
        else if (Keyboard.current.backslashKey.wasPressedThisFrame)
        {
            return "]";
            //JISキーボードだと特殊キーが違う可能性あり
        }
        else if (Keyboard.current.equalsKey.wasPressedThisFrame)
        {
            return "^";
        }
        else if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            return "\b";
        }
        else if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame)
        {
            return "\n";
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            return "␣";
        }
        else if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            return "|";
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)//ESCキーでGame1に戻る(Game2の終了)
        {
            return "\u001B";
        }
        else
        {
            return "NULL";
        }
    }
    public void Finished()
    {
        Gamedata.Memory(SourcecodeScript);
        //folderName=SaveDateScript.Save();
        SceneManager.LoadScene(1);
    }
}
