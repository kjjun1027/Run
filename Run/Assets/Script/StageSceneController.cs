using UnityEngine;

public class StageSceneController : MonoBehaviour
{
    public Transform mapSpawnPoint; // ���� ��ġ�� ��ġ
    public Transform characterSpawnPoint; // ĳ���Ͱ� ��ġ�� ��ġ

    private string stageName;

    private void Start()
    {
        // PlayerPrefs���� �������� �̸��� �ҷ���
        stageName = PlayerPrefs.GetString("SelectedStage", "Unknown");

        // ���������� ���� �ʰ� ĳ���� �ε� �� ��ġ
        LoadStage(stageName);
    }

    private void LoadStage(string stageName)
    {
        // �� �ε�
        GameObject mapPrefab = LoadMap(stageName);
        if (mapPrefab != null)
        {
            Instantiate(mapPrefab, mapSpawnPoint.position, Quaternion.identity);
        }

        // ĳ���� �ε�
        GameObject characterPrefab = LoadCharacter(stageName);
        if (characterPrefab != null)
        {
            Instantiate(characterPrefab, characterSpawnPoint.position, Quaternion.identity);
        }
    }

    private GameObject LoadMap(string stageName)
    {
        // �������� �̸��� ���� �� ������ �ε�
        string mapPath = $"Maps/{stageName}Map"; // ��: Maps/TutorialMap
        GameObject mapPrefab = Resources.Load<GameObject>(mapPath);

        if (mapPrefab == null)
        {
            Debug.LogWarning($"Map prefab not found for stage: {stageName}");
        }

        return mapPrefab;
    }

    private GameObject LoadCharacter(string stageName)
    {
        // �������� �̸��� ���� ĳ���� ������ �ε�
        string characterPath = $"Characters/Character{stageName}"; // ��: Characters/CharacterTutorial
        GameObject characterPrefab = Resources.Load<GameObject>(characterPath);

        if (characterPrefab == null)
        {
            Debug.LogWarning($"Character prefab not found for stage: {stageName}");
        }

        return characterPrefab;
    }
}