﻿using Configs.EnemyConfig;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image _image;
        
    public event UnityAction<float> OnDamaged;
    public event UnityAction OnDead;
        
    private float _health;
    private Sequence _currentSequenceDamage;

    public void Initialize(Sprite sprite, float health)
    {
        _health = health;
        _image.sprite = sprite;
        DamageEnemyAnimation();
    }

    private void DamageEnemyAnimation() {
        _currentSequenceDamage = DOTween.Sequence()
            .AppendCallback(() => transform.localScale = new Vector3(1, 1, 1))
            .Append(transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f))
            .Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f))
            .SetAutoKill(false)
            .Pause();
    }

    public void DoDamage(float damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            OnDamaged?.Invoke(damage);
            OnDead?.Invoke();
            return;
        }
        _health -= damage;
        _currentSequenceDamage.Restart();
        OnDamaged?.Invoke(damage);
    }
    public float GetHealth()
    {
        return _health;
    }


}