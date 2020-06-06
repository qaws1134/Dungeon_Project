using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    private PlayerCtrl player;
    private Transform target;

    float xMax, xMin, yMax, yMin;

    [SerializeField]
    Tilemap tilemap;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<PlayerCtrl>();

        //현재 타일맵에서 타일 좌표가 가장 낮은것과 높은것의 Vector3을 찾음
        //지금은 전체 맵에서만 판단 
        //CellToWorld는 타일맵의 좌표를 월드 좌표계로 변환
        //tilemap.cellBounds는 셀크기로 Tilemap의 경계를 반환한다는 의미
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetLimits(minTile, maxTile);
        player.SetLimits(minTile, maxTile);
    }
    //모든 Update 함수가 호출된 후 호출됨.
    //주로 오브젝트를 따라가게 설정한 카메라에 사용
    private void LateUpdate()
    {
        //
        float minClamp = Mathf.Clamp(target.position.x, xMin, xMax);
        float maxClamp = Mathf.Clamp(target.position.y, yMin, yMax);

        transform.position = new Vector3(minClamp, maxClamp, -10);
    }

    // 카메라의 이동범위를 정합니다.
    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
