using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Floater : MonoBehaviour
{
    public WaterSurface targetSurface = null;
    public float depth = 0.0f;

    // Internal search params
    WaterSearchParameters searchParameters = new WaterSearchParameters();
    WaterSearchResult searchResult = new WaterSearchResult();

    // Update is called once per frame
    void Update()
    {
        if (targetSurface != null)
        {
            // Build the search parameters
            searchParameters.startPosition = searchResult.candidateLocation;
            searchParameters.targetPosition = gameObject.transform.position;
            searchParameters.error = 0.01f;
            searchParameters.maxIterations = 8;

            // Do the search
            if (targetSurface.FindWaterSurfaceHeight(searchParameters, out searchResult))
            {
                // Debug.Log(searchResult.height);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, searchResult.height - depth, gameObject.transform.position.z);
            }
            else Debug.LogError("Can't Find Height");
        }
    }
}