using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        // 1. 타겟을 구한다.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length == 0) return;
        GameObject target = targets[0];
        float minDistance = float.MaxValue;
        // 1-1. 가장 가까운 타켓을 찾는다.
        foreach (GameObject enemy in targets)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                // 타켓 변경
                minDistance = distance;
                target = enemy;
            }
        }
        // 2. 방향을 구한다.
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        direction.y = 0;

        // 3. 속도에 맞게 이동한다.
        transform.position += direction * Time.deltaTime * _speed;
    }
}
