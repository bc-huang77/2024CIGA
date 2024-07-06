using System;
using UnityEngine;

namespace GrayCity.Control.Movement._Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _anim;
        [SerializeField] private SpriteRenderer _sprite;

        [Header("Settings")]
        [SerializeField, Range(0.1f, 2f)] private float _walkAnimationSpeedModifier = 0.7f;
        [SerializeField] private ScriptableStats _stats;  //主要是为了获取输入阈值

        private PlayerMovement _player;
        
        private bool BouncingTriggered = false;

        private void Awake()
        {
            _player = GetComponentInParent<PlayerMovement>();
        }

        private void OnEnable()
        {
            _player.Jumped += OnJumped;
            _player.GroundedChanged += OnGroundedChanged;
        }

        private void OnDisable()
        {
            _player.Jumped -= OnJumped;
            _player.GroundedChanged -= OnGroundedChanged;
        }

        private void Update()
        {
            if (_player == null) return;

            HandleSpriteFlip();
            HandleWalkSpeed();

            if (_player.IsClimbing)
            {
                _anim.SetBool(WalkKey, false);
                _anim.SetBool(IdleKey, false);
                _anim.SetBool("Climb", true);
                
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    _anim.SetBool("Climbing",true); 
                }
                else
                {
                    _anim.SetBool("Climbing", false);
                }
            }else
            {
                _anim.SetBool("Climb", false);
            }

            if (_player.IsFlowing)
            {
                
            }
            else
            {
                
            }


            if (_player.IsBouncing && !BouncingTriggered)
            {
                //只触发一次trigger
                _anim.SetTrigger("Bounce");
                BouncingTriggered = true;
            }
            else if (!_player.IsBouncing && BouncingTriggered)
            {
                BouncingTriggered = false;
            }

        }

        private void HandleSpriteFlip()
        {
            if (_player.FrameInput.x != 0)
            {
                _sprite.flipX = _player.FrameInput.x < 0;
            }
        }
        
        //处理走路动画及其速度
        private void HandleWalkSpeed()
        {
            var inputStrength = Mathf.Abs(_player.FrameInput.x);
            float threshold = 0; //输入阈值
            if (_stats.SnapInput)
            {
                threshold = _stats.VerticalDeadZoneThreshold;
            }
            
            
            if (inputStrength > threshold)
            {
                _anim.SetFloat(WalkSpeedKey, _walkAnimationSpeedModifier * inputStrength); //设置动画的速度
                _anim.SetBool(WalkKey, true);
                _anim.SetBool(IdleKey, false);
            }
            else
            {
                _anim.SetBool(WalkKey, false);
                _anim.SetBool(IdleKey, true);
            }
        }
        
        
        //处理跳跃时逻辑
        private void OnJumped()
        {
            _anim.SetTrigger(JumpKey);
            _anim.ResetTrigger(GroundedKey);
        }
        
        
        //处理落地状态改变时逻辑
        private void OnGroundedChanged(bool grounded, float impact)
        {
            if (grounded)
            {
                _anim.SetTrigger(GroundedKey);
            }
        }


        private static readonly int GroundedKey = Animator.StringToHash("Grounded");
        private static readonly int WalkSpeedKey = Animator.StringToHash("WalkSpeed");
        private static readonly int JumpKey = Animator.StringToHash("Jump");
        private static readonly int WalkKey = Animator.StringToHash("Walk");
        private static readonly int IdleKey = Animator.StringToHash("Idle");
    }
}
