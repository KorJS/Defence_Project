using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [System.Serializable]
    public class PathSettings
    {
        public Transform[] topPaths;
        public Transform[] bottomPaths;
        public Transform[] rightPaths;
    }

    [SerializeField]
    public PathSettings paths;

    public float moveSpeed = 0f;
    public float rotSpeed = 0f;

    void OnEnable()
    {
        // 부모 객체 생성하고 패치 설정
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MovePath());
        }
    }

    IEnumerator MovePath()
    {
        int pathIndex = 0;

        while (pathIndex < paths.topPaths.Length)
        {
            Vector3 dir = paths.topPaths[pathIndex].position - transform.position;
            Quaternion q = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * rotSpeed);
            // 이동
            transform.Translate(0f, 0f, Time.deltaTime * moveSpeed);

            // 거리 같아지면 다음으로 이동
            if (Vector3.Distance(transform.position, paths.topPaths[pathIndex].position) < 1f)
            {
                pathIndex++;
            }

            yield return null;
        }
    }
}