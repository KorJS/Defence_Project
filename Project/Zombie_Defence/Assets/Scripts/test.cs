using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [System.Serializable]
    public class PathSettings
    {
        public Transform[] top_paths;
        public Transform[] bottom_paths;
        public Transform[] right_paths;
    }

    [SerializeField]
    public PathSettings paths;

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
        int path_index = 0;

        while (path_index < paths.top_paths.Length)
        {
            // 이동
            transform.LookAt(paths.top_paths[path_index]);
            transform.Translate(0f, 0f, Time.deltaTime * 10f);

            // 거리 같아지면 다음으로 이동
            if (Vector3.Distance(transform.position, paths.top_paths[path_index].position) < 1f)
            {
                path_index++;
            }

            yield return null;
        }
    }
}