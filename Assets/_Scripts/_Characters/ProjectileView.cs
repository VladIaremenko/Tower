﻿using System.Collections.Generic;
using Tower.Assets._Scripts._Enemy;
using UnityEngine;

namespace Tower.Assets._Scripts._Characters
{
    public class ProjectileView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private float _speed;
        private Vector3 _direction;

        private void OnEnable()
        {
            RefreshTarget();
        }

        private void RefreshTarget()
        {
            var target = GetClosestItem(_charactersViewModel.Enemies, _charactersViewModel.Player.position);
            _direction = (target.position - transform.position).normalized;
        }

        private void FixedUpdate()
        {
            transform.position += _direction * _speed * Time.fixedDeltaTime;
        }

        private Transform GetClosestItem(List<Transform> items, Vector3 origin)
        {
            float prevDistance = float.MaxValue;
            Transform closestItem = null;

            foreach (var item in items)
            {
                float dist = Vector3.Distance(origin, item.transform.position);

                if (!item.gameObject.activeInHierarchy)
                {
                    continue;
                }

                if (dist < prevDistance)
                {
                    closestItem = item;
                    prevDistance = dist;
                }
            }

            return closestItem;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}