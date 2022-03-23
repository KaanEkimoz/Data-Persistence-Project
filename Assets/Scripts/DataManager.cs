using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentPlayerName;
    public int HighScore;
    public string HighPlayerName;
    public TMP_InputField inputField;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        
    }
    public void SetPlayerName()
    {
        currentPlayerName = inputField.text;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (inputField == null)
        {
            inputField = GameObject.Find("IF_PlayerName").GetComponent<TMP_InputField>();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighPlayerName;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighPlayerName = HighPlayerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            HighPlayerName = data.HighPlayerName;
        }
    }
}
