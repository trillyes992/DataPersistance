using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class StartMenuManager : MonoBehaviour
{

    //ID需要考虑输入类型以及长度限制
    public static StartMenuManager Instance;

    public static string ID;
    public static string HighScoreID;
    public static int HighScore = 0;
    
    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        try
        {
            LoadInfo();
        }
        catch
        {
            Debug.Log("空ID.");
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

        public static void LoadScene()
    {
        if(ID!=null)
        {
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }
        else
        {
            FindObjectOfType<Text>().text = "请先建立ID";
        }
        
    }

    [System.Serializable]
    public class SaveData
    {
        //需要保存的数据成员
        public string IDdata;
        public string HighScoreIDData;
        public int HighScoreData;
    }
    public static void SaveInfo()
    {

        if(ID != "")
        {   
            SaveData data = new SaveData();
            
            data.IDdata = ID;
            
            data.HighScoreData = HighScore;
            data.HighScoreIDData = HighScoreID;

            string json = JsonUtility.ToJson(data);
        
            File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);

            
        }
        
        else
        {
                FindObjectOfType<Text>().text = "ID无效！";
        }
    }
    public static void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            ID = data.IDdata;
            HighScore = data.HighScoreData;
            HighScoreID = data.HighScoreIDData;
            if (ID!="")
            {
                FindObjectOfType<Text>().text = "欢迎你，" + ID;
            }
            
        }
        else
        {
            FindObjectOfType<InputField>().text = "请新建ID...";
        }
    }

    


    //Next:要让SavaInfo得到复用，
    //那么我不知道将要保存的数据的类型和数量
    //让它只对SaveData类作用

}
