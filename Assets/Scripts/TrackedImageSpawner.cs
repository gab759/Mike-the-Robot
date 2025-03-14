using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImageSpawner : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject trackedImagePrefab;

    private readonly Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private void OnEnable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }

    private void OnDisable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            if (!spawnedPrefabs.ContainsKey(trackedImage.referenceImage.name))
            {
                // Instancia el prefab y ajusta su rotación
                GameObject newPrefab = Instantiate(trackedImagePrefab, trackedImage.transform.position, Quaternion.identity);
                newPrefab.transform.rotation = Quaternion.Euler(0, 90, 0); // Ajusta la rotación según necesites

                spawnedPrefabs[trackedImage.referenceImage.name] = newPrefab;
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out GameObject prefab))
            {
                prefab.transform.position = trackedImage.transform.position;
                prefab.transform.rotation = trackedImage.transform.rotation * Quaternion.Euler(0, 0, 90);
            }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out GameObject prefab))
            {
                Destroy(prefab);
                spawnedPrefabs.Remove(trackedImage.referenceImage.name);
            }
        }
    }
}