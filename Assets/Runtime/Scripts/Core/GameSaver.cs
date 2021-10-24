using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SaveGameData
{
    public int LastScore;
    public int HighestScore;
    public int TotalCherriesCollected;
    public int TotalPeanutsCollected;
}

public class AudioPreferences
{
    public float MainVolume = 1;
    public float MusicVolume = 1;
    public float SFXVolume = 1;
}

public class GameSaver : MonoBehaviour
{
    private string SaveGameFilePath => $"{Application.persistentDataPath}/saveGame.json";
    private string AudioPreferencesFilePath => $"{Application.persistentDataPath}/preferences.json";

    public SaveGameData CurrentSave { get; private set; }
    public AudioPreferences AudioPreferences { get; private set; }

    private bool IsLoaded => CurrentSave != null && AudioPreferences != null;

    public void SaveGame(SaveGameData saveData)
    {
        CurrentSave = saveData;
        SaveGameDataToFile(SaveGameFilePath, CurrentSave);
    }

    public void LoadGame()
    {
        if (IsLoaded)
        {
            return;
        }

        CurrentSave = LoadGameDataFromFile(SaveGameFilePath) ?? new SaveGameData();
        AudioPreferences = LoadAudioPreferencesFromFile(AudioPreferencesFilePath) ?? new AudioPreferences();
    }

    public void SaveAudioPreferences(AudioPreferences preferences)
    {
        AudioPreferences = preferences;
        SaveAudioPreferencesToFile(AudioPreferencesFilePath, AudioPreferences);
    }

    public void DeleteAllData()
    {
        File.Delete(SaveGameFilePath);
        File.Delete(AudioPreferencesFilePath);
        CurrentSave = null;
        AudioPreferences = null;
        LoadGame();
    }

    private void SaveGameDataToFile(string filePath, SaveGameData data)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(stream))
        using (JsonWriter jsonWriter = new JsonTextWriter(writer))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, data);
        }
    }

    private SaveGameData LoadGameDataFromFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
        using (StreamReader reader = new StreamReader(stream))
        using (JsonReader jsonReader = new JsonTextReader(reader))
        {
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<SaveGameData>(jsonReader);
        }
    }

    private void SaveAudioPreferencesToFile(string filePath, AudioPreferences data)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(stream))
        using (JsonWriter jsonWriter = new JsonTextWriter(writer))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, data);
        }
    }

    private AudioPreferences LoadAudioPreferencesFromFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
        using (StreamReader reader = new StreamReader(stream))
        using (JsonReader jsonReader = new JsonTextReader(reader))
        {
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<AudioPreferences>(jsonReader);
        }
    }
}