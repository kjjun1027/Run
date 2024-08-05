using UnityEngine;

public class StageSceneController : MonoBehaviour
{
    public Transform mapSpawnPoint; // 맵이 배치될 위치
    public Transform characterSpawnPoint; // 캐릭터가 배치될 위치

    private string stageName;

    private void Start()
    {
        // PlayerPrefs에서 스테이지 이름을 불러옴
        stageName = PlayerPrefs.GetString("SelectedStage", "Unknown");

        // 스테이지에 따른 맵과 캐릭터 로드 및 배치
        LoadStage(stageName);
    }

    private void LoadStage(string stageName)
    {
        // 맵 로드
        GameObject mapPrefab = LoadMap(stageName);
        if (mapPrefab != null)
        {
            Instantiate(mapPrefab, mapSpawnPoint.position, Quaternion.identity);
        }

        // 캐릭터 로드
        GameObject characterPrefab = LoadCharacter(stageName);
        if (characterPrefab != null)
        {
            Instantiate(characterPrefab, characterSpawnPoint.position, Quaternion.identity);
        }
    }

    private GameObject LoadMap(string stageName)
    {
        // 스테이지 이름에 따라 맵 프리팹 로드
        string mapPath = $"Maps/{stageName}Map"; // 예: Maps/TutorialMap
        GameObject mapPrefab = Resources.Load<GameObject>(mapPath);

        if (mapPrefab == null)
        {
            Debug.LogWarning($"Map prefab not found for stage: {stageName}");
        }

        return mapPrefab;
    }

    private GameObject LoadCharacter(string stageName)
    {
        // 스테이지 이름에 따라 캐릭터 프리팹 로드
        string characterPath = $"Characters/Character{stageName}"; // 예: Characters/CharacterTutorial
        GameObject characterPrefab = Resources.Load<GameObject>(characterPath);

        if (characterPrefab == null)
        {
            Debug.LogWarning($"Character prefab not found for stage: {stageName}");
        }

        return characterPrefab;
    }
}