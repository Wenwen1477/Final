IEnumerator FlashHurtSprite()
{
    for (int i = 0; i < 3; i++) // กระพริบ 3 ครั้ง
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.3f); // จางลง
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1f); // กลับเป็นปรกติ
        yield return new WaitForSeconds(0.1f);
    }
}
