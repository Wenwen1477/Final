IEnumerator FlashHurtSprite()
{
    for (int i = 0; i < 3; i++) // ��о�Ժ 3 ����
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.3f); // �ҧŧ
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1f); // ��Ѻ�繻á��
        yield return new WaitForSeconds(0.1f);
    }
}
